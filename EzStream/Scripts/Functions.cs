using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Windows;

namespace EzStreaming.Scripts
{
    public static class Functions
    {

        public static string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
        public static void CheckFiles(string dir, MaterialDesignThemes.Wpf.Snackbar snackbar = null)
        {
            
            if (!File.Exists(dir + "/Data/ffmpeg.exe") || CreateMD5(dir + "/Data/ffmpeg.exe") != "ED42CC33AED5FEEA6DE35EFC4B63247B")
            {
                if (snackbar != null) snackbar.MessageQueue.Enqueue("Fixing: ffmpeg");
                File.Delete(dir + "/Data/ffmpeg.exe");
                using (WebClient wc = new WebClient())
                    wc.DownloadFileAsync(new Uri("https://github.com/YouAreMyTrap/EzStreamig/raw/main/ffmpeg.exe"), dir + "/Data/ffmpeg.exe");
            }
            if (!File.Exists(dir + "/Data/youtube-dl.exe") || CreateMD5(dir + "/Data/youtube-dl.exe") != "A31C43FD4121A76EA00AA52BECE3FF69")
            {
                if (snackbar != null) snackbar.MessageQueue.Enqueue("Fixing: youtube-dl");
                File.Delete(dir + "/Data/youtube-dl.exe");
                using (WebClient wc = new WebClient())
                    wc.DownloadFileAsync(new Uri("https://github.com/YouAreMyTrap/EzStreamig/raw/main/youtube-dl.exe"), dir + "/Data/youtube-dl.exe");
            }
            if (!File.Exists(dir + "/Data/Extensions/BotDiscord.exe") || CreateMD5(dir + "/Data/Extensions/BotDiscord.exe") != "7ED5AB3C440FD4340AB30CDA19E8AC4C")
            {
                if (snackbar != null) snackbar.MessageQueue.Enqueue("Fixing: DiscordBot");
                File.Delete(dir + "/Data/Extensions/BotDiscord.exe");
                using (WebClient wc = new WebClient())
                    wc.DownloadFileAsync(new Uri("https://github.com/YouAreMyTrap/EzStreamig/raw/main/Discord%20Bot/dist/BotDiscord.exe"), dir + "/Data/Extensions/BotDiscord.exe");
            }
            if (!Directory.Exists(dir + "/Data")) Directory.CreateDirectory(dir + "/Data");
            if (!Directory.Exists(dir + "/Data/Video")) Directory.CreateDirectory(dir + "/Data/Video");
            if (!Directory.Exists(dir + "/Data/Audio")) Directory.CreateDirectory(dir + "/Data/Audio");
            if (!Directory.Exists(dir + "/Data/Extensions")) Directory.CreateDirectory(dir + "/Data/Extensions");
            if (!Directory.Exists(dir + "/Data/Channels")) Directory.CreateDirectory(dir + "/Data/Channels");
            if (!File.Exists(dir + "/Data/Channels.txt")) File.Create(dir + "/Data/Channels.txt").Dispose();
        }
        public static void UpdateProgram()
        {
            AutoUpdaterDotNET.AutoUpdater.Start("https://github.com/YouAreMyTrap/EzStreamig/raw/main/update.xml");
        }

        public static void fabric(string input, string dir, string channel)
        {
            File.Create(dir + "/Data/" + channel + ".bat").Dispose();
            using (TextWriter tw = new StreamWriter(dir + "/Data/" + channel  + ".bat"))
            {
                tw.WriteLine("Title " + channel);
                tw.WriteLine("mode con:lines=1");
                tw.WriteLine("color 5A");
                tw.WriteLine(":start");
                tw.WriteLine(input);
                tw.WriteLine("goto start");
            }
        }

    }
}
