# Indiana Jones and the Great Circle Save Manager

A program to make importing and exporting Indiana Jones and the Great Circle saves easier.


This is a fork of [GoobyCorp's original Doom Eternal Save Manager](https://github.com/GoobyCorp/DOOMSaveManager) and [Brunoanc's modified version for Linux](https://github.com/brunoanc/DOOMSaveManagerLinux). Both Doom Eternal and The Great Circle run on IDTech7, and despite being singleplayer games, the saves are encrypted using AES encryption, your Steam ID, and a secret key (which, for The Great Circle, is `SUKHOTHAI`).

You can use this program to unencrypt, re-encrypt, or transfer saves between local Steam users.

### Using with Windows

Launch the executable, and pick one of three options:
1) Export backup - Unencrypt the game save from a steam account and store it in a zip
2) Import backup - Encrypt a game save (stored in a zip file) into a steam account.
3) Transfer - Transfer the game save from one steam account to another. Basically, an automated version of option 1 and 2.

### Using with Linux

To use the Linux version of this program, you need [Wine](https://www.winehq.org/). Open a terminal in the folder with the downloaded executable and run `wine Indiana\ Jones\ and\ the\ Great\ Circle\ Save\ Manager.exe` (note, I tested using a 64-Bit wine prefix, I don't know if it works in a 32-Bit one but I don't see why it wouldn't). The console will ask you to provide the path for your Steam folder. This should be the same folder where you can find folders like `compatibilitytools.d`, and **not** an external game library. For me, this is `/home/buu342/.steam/steam/`. After providing the path, the program should launch and work like normal.

When I tried using my save in the Steam version of the game, after [Update 3](https://store.steampowered.com/news/app/2677660/view/502817574909640811), it would show save data properly (like the playtime, location, etc...) but it would not load the save due to it being "corrupt or incompatible". I had to switch my game to use Proton Hotfix instead of the default Proton, that let me load the save properly. If you are encountering the same issue, try that. If your save does not show playtime or location, then you probably did not convert it properly (if at all, since the program would have thrown an error during the conversion) or you might be mixing the save between game versions (I did not test this so this might be a problem).

### Using with an Alternative Version of the Game

As explained, the game save requires a Steam ID in order to encrypt/decrypt, and your alternative version will likely also be using a custom Steam ID. You'll have to figure this out on your own, as it varies from version to version. The ID is 17 digits, and has the format `76561198#########` (where the hashtags are your unique number). This is known as a SteamID64.

Once you have the SteamID64 figured out, copy it into an online Steam ID finder such as [steamid.io](https://steamid.io), and paste it there. This should give you a SteamID3, which should look like `[U:1:########]` (if your ID doesn't point to a valid user, then you'll need to find some other method of calculating this number. More info regarding converting IDs [here](https://gist.github.com/bcahue/4eae86ae1d10364bb66d)). Copy the numbers where the hashtags are, go to your `steam/userdata` folder, and then create a folder with those numbers as the name. Then inside that folder, create a folder with the name `2677660` (the game ID for The Great Circle), and then another folder inside that one called `remote`. Paste your game save (`GAME-SLOT#` and `PROFILE` folders) in there. The program should now be able to detect your "profile" to encrypt/decrypt the saves.

### Compiling from the Source Code

You can download prebuilt executable from the [releases](../../releases) page, but if you want to build the program yourself, then simply open the solution file in Microsoft Visual Studio 2022 and compile. This means that, to compile the program for Linux, you need to have a Windows machine.

When compiling the Linux version, you must ensure that the program compiles as a **console application**. This can be set in the solution's properties if it isn't for some reason.

### Other Notes

Below lies the original README.

---

![Main Form](https://ishr.ink/JACh5pLs)

![Transfer Form](https://ishr.ink/wODAQKya)

### Libraries Used:
[SharpZipLib](https://github.com/icsharpcode/SharpZipLib)
[BouncyCastle](http://www.bouncycastle.org/csharp/)