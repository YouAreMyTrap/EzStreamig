using EzStream;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Net;
using AutoUpdaterDotNET;
using System.Reflection;

namespace EzStreaming
{
    /// <summary>
    /// Lógica de interacción para Start.xaml
    /// </summary>
    public partial class Start : Window
    {
        public Start()
        {
            //MessageBox.Show(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            string dir = System.IO.Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
            if (!Directory.Exists(dir + "/Data"))
            {
                Directory.CreateDirectory(dir + "/Data");
                Directory.CreateDirectory(dir + "/Data/Video");
                Directory.CreateDirectory(dir + "/Data/Audio");
                Directory.CreateDirectory(dir + "/Data/Channels");
                File.Create(dir + "/Data/Channels.txt").Dispose();
            }
            if (!Directory.Exists(dir + "/Data/Channels"))
                Directory.CreateDirectory(dir + "/Data/Channels");
            try
            {
                using (WebClient wc = new WebClient())
                {
                    if (!File.Exists(dir + "/Data/ffmpeg.exe"))
                        wc.DownloadFileAsync(new Uri("https://github.com/YouAreMyTrap/EzStreamig/raw/main/ffmpeg.exe"), dir + "/Data/ffmpeg.exe");
                    if (!File.Exists(dir + "/Data/youtube-dl.exe"))
                        wc.DownloadFileAsync(new Uri("https://github.com/YouAreMyTrap/EzStreamig/raw/main/youtube-dl.exe"), dir + "/Data/youtube-dl.exe");
                }
            }
            catch
            {
                MessageBox.Show("Error of download files, no problem i'm fixing");
                if (CreateMD5(dir + "/Data/ffmpeg.exe") != "6FF3B9C74BE96F064CAA17191E0718AF")
                {
                    File.Delete(dir + "/Data/ffmpeg.exe");
                    using (WebClient wc = new WebClient())
                        wc.DownloadFileAsync(new Uri("https://github.com/YouAreMyTrap/EzStreamig/raw/main/ffmpeg.exe"), dir + "/Data/ffmpeg.exe");
                }
                if (CreateMD5(dir + "/Data/youtube-dl.exe") != "7D71FBDEE51BA630BA2D669FBB583425")
                {
                    File.Delete(dir + "/Data/youtube-dl.exe");
                    using (WebClient wc = new WebClient())
                        wc.DownloadFileAsync(new Uri("https://github.com/YouAreMyTrap/EzStreamig/raw/main/youtube-dl.exe"), dir + "/Data/youtube-dl.exe");
                }
            }
            if (EzStreaming.Properties.Settings.Default.StartVery)
                AutoUpdater.Start("https://github.com/YouAreMyTrap/EzStreamig/raw/main/update.xml");
            MainWindow win2 = new MainWindow();
            win2.Show();
            this.Close();

        }

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
    }
}
