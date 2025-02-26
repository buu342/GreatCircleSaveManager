using System;

using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

using Microsoft.Win32;

using ICSharpCode.SharpZipLib.Zip;
using ICSharpCode.SharpZipLib.Core;

namespace GreatCircleSaveManager
{
    public static class Utilities
    {
        public static string GetGamePath() {
            string gamePath;
            if (!String.IsNullOrEmpty(GreatCircle.steamPath))
                return GreatCircle.steamPath;
            if (!String.IsNullOrEmpty(GreatCircleSavePath.gamePath))
                return GreatCircleSavePath.gamePath;
            Console.Write("Enter the path to your Steam folder: ");
            gamePath = Console.ReadLine();
            if (!(Directory.Exists(Path.Combine(gamePath, "Saved Games")) || Directory.Exists(Path.Combine(gamePath, "userdata"))))
            {
                Console.WriteLine("ERROR: The specified directory is not valid.");
                System.Environment.Exit(1);
            }
            return gamePath;
        }

        public static byte[] RandomBytes(int size) {
            byte[] output = new byte[size];
            new Random().NextBytes(output);
            return output;
        }

        public static bool ByteArraysEqual(byte[] b1, byte[] b2) {
            return b1.SequenceEqual(b2);
        }

        public static ulong Id3ToId64(uint sid3) {
            return sid3 + 76561197960265728UL;
        }

        public static string Id3ToId64(string sid3) {
            return (ulong.Parse(sid3) + 76561197960265728UL).ToString();
        }

        public static ulong Id64ToId3(uint sid3) {
            return sid3 - 76561197960265728UL;
        }

        public static string Id64ToId3(string sid64) {
            return (ulong.Parse(sid64) - 76561197960265728UL).ToString();
        }

        public static string GetSavePathForId64(ulong sid64) {
            return Path.Combine(GreatCircle.SteamSavePath, (sid64 - 76561197960265728).ToString(), GreatCircle.SteamGameID.ToString(), "remote");
        }

        public static bool CheckUUID(string s) {
            Regex re = new Regex("^[0-9a-f]{8}-?[0-9a-f]{4}-?[0-9a-f]{4}-?[0-9a-f]{4}-?[0-9a-f]{12}$", RegexOptions.IgnoreCase);
            return re.IsMatch(s);
        }

        public static string Hexlify(byte[] data) {
            return BitConverter.ToString(data).Replace("-", "").ToUpper();
        }

        public static void PrintHex(byte[] data) {
            Console.WriteLine(Hexlify(data));
        }
    }
}