using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

using ICSharpCode.SharpZipLib.Zip;
using ICSharpCode.SharpZipLib.Core;

namespace GreatCircleSaveManager
{
    public enum GreatCircleSavePlatform
    {
        Steam,
    }

    public class GreatCircleSavePath
    {
        public string Identifier;
        public string FullPath;
        public GreatCircleSavePlatform Platform;
        public bool Encrypted = true;

        public static string gamePath = Utilities.GetGamePath();
        public static string SteamSavePath = Path.Combine(gamePath, "userdata");

        public GreatCircleSavePath(string id, GreatCircleSavePlatform platform, bool encrypted = true) {
            Identifier = id;
            Platform = platform;
            Encrypted = encrypted;

            if (Identifier == "savegame.unencrypted")
            {
                Encrypted = false;
                FullPath = Path.Combine(SteamSavePath + ".unencrypted", Utilities.Id64ToId3(Identifier), GreatCircle.SteamGameID.ToString(), "remote");
            }
            else if (platform == GreatCircleSavePlatform.Steam)
                FullPath = Path.Combine(SteamSavePath, Utilities.Id64ToId3(Identifier), GreatCircle.SteamGameID.ToString(), "remote");
        }

        public string[] GetAbsolutePaths() => Directory.GetFiles(FullPath, "*.*", SearchOption.AllDirectories);

        public string[] GetRelativePaths() => GetAbsolutePaths().Select(single => single.Replace(FullPath, "").Substring(1)).ToArray();

        public bool Exists() => Directory.Exists(FullPath);

        public void Compress(string filename) {
            using (var fsOut = File.Create(filename))
            using (var zs = new ZipOutputStream(fsOut)) {
                zs.SetLevel(3);
                foreach (var single in GetAbsolutePaths()) {
                    if (single.EndsWith("-BACKUP"))
                        continue;

                    byte[] fileData = File.ReadAllBytes(single);
                    string relPath = single.Replace(FullPath, "").Substring(1);
                     if (Platform == GreatCircleSavePlatform.Steam && Encrypted)
                        fileData = Crypto.DecryptAndVerify($"{Identifier}{GreatCircle.GameKey}{Path.GetFileName(single)}", fileData);

                    var fi = new FileInfo(single);
                    var entryName = ZipEntry.CleanName(relPath);
                    var ze = new ZipEntry(entryName);
                    ze.Size = fileData.Length;
                    ze.DateTime = fi.LastWriteTime;
                    zs.PutNextEntry(ze);
                    var buffer = new byte[4096];
                    using (var dataIn = new MemoryStream(fileData)) {
                        StreamUtils.Copy(dataIn, zs, buffer);
                    }
                    zs.CloseEntry();
                }
            }
        }

        public void Decompress(string filename) {
            using (Stream fsIn = File.OpenRead(filename))
            using (var zf = new ZipFile(fsIn)) {

                foreach (ZipEntry ze in zf) {
                    if (!ze.IsFile)
                        continue;

                    string entryFileName = ze.Name;

                    var fullZipToPath = Path.Combine(FullPath, entryFileName);
                    var directoryName = Path.GetDirectoryName(fullZipToPath);
                    if (directoryName.Length > 0) {
                        Directory.CreateDirectory(directoryName);
                    }

                    var buffer = new byte[4096];
                    using (var zs = zf.GetInputStream(ze))
                    using (MemoryStream dataOut = new MemoryStream()) {
                        StreamUtils.Copy(zs, dataOut, buffer);

                        byte[] fileData = dataOut.ToArray();
                        if (Platform == GreatCircleSavePlatform.Steam && Encrypted)
                            fileData = Crypto.EncryptAndDigest($"{Identifier}{GreatCircle.GameKey}{Path.GetFileName(entryFileName)}", fileData);

                        File.WriteAllBytes(fullZipToPath, fileData);
                    }

                }
            }
        }

        public void Transfer(GreatCircleSavePath dst) {
            List<Tuple<string, byte[]>> srcFiles = new List<Tuple<string, byte[]>>();

            // read from source
            string srcAAD;
            if (Platform == GreatCircleSavePlatform.Steam)
                srcAAD = GreatCircle.GameKey;
            else
                throw new Exception("Unsupported source platform specified!");
            foreach (var single in GetAbsolutePaths()) {
                if (Encrypted)
                    srcFiles.Add(new Tuple<string, byte[]>(single.Replace(FullPath, "").Substring(1), Crypto.DecryptAndVerify($"{Identifier}{srcAAD}{Path.GetFileName(single)}", File.ReadAllBytes(single))));
                else
                    srcFiles.Add(new Tuple<string, byte[]>(single.Replace(FullPath, "").Substring(1), File.ReadAllBytes(single)));
            }

            // copy to destination
            string dstAAD;
            if (dst.Platform == GreatCircleSavePlatform.Steam)
                dstAAD = GreatCircle.GameKey;
            else
                throw new Exception("Unsupported destination platform specified!");
            foreach (var single in srcFiles) {
                Directory.CreateDirectory(Path.GetDirectoryName(Path.Combine(dst.FullPath, single.Item1)));
                if (dst.Encrypted)
                    File.WriteAllBytes(Path.Combine(dst.FullPath, single.Item1), Crypto.EncryptAndDigest($"{dst.Identifier}{dstAAD}{Path.GetFileName(single.Item1)}", single.Item2));
                else
                    File.WriteAllBytes(Path.Combine(dst.FullPath, single.Item1), single.Item2);
            }
        }

        public static void Transfer(GreatCircleSavePath src, GreatCircleSavePath dst) => src.Transfer(dst);
    }
}
