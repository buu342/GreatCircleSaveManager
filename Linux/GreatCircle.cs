using System;
using System.Linq;

using System.IO;
using System.Collections.Generic;
using System.Reflection.Emit;
using Org.BouncyCastle.Cms;
using Org.BouncyCastle.Crypto.Engines;

namespace GreatCircleSaveManager
{
    public class GreatCircle
    {
        public static string steamPath = Utilities.GetGamePath();
        public const string GameName = "Indiana Jones and the Great Circle";

        public const int SteamGameID = 2677660;
        public static string SteamSavePath = "";
        public static string GameKey = "SUKHOTHAI";
        public static string BnetSavePath = Path.Combine(Utilities.GetGamePath(), "Saved Games", "id Software", "GreatCircle", "base", "savegame");

        public static GreatCircleSavePathCollection Saves;

        public static void EnumerateSaves() {
            Saves = new GreatCircleSavePathCollection();

            if (!string.IsNullOrEmpty(steamPath)) {
                SteamSavePath = Path.Combine(steamPath, "userdata");
                if (Directory.Exists(SteamSavePath)) {
                    foreach (var steamId3 in Directory.GetDirectories(SteamSavePath, "*.*", SearchOption.TopDirectoryOnly)) {
                        foreach (var single in Directory.GetDirectories(steamId3, "*.*", SearchOption.TopDirectoryOnly)) {
                            if (Path.GetFileNameWithoutExtension(single) == SteamGameID.ToString())
                                Saves.Add(new GreatCircleSavePath(Utilities.Id3ToId64(Path.GetFileNameWithoutExtension(steamId3)), GreatCircleSavePlatform.Steam));
                        }
                    }
                }
            }
        }
	}
}
