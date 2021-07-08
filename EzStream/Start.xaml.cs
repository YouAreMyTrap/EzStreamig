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
using EzStreaming.Scripts;

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
                Directory.CreateDirectory(dir + "/Data/Extensions");
                Directory.CreateDirectory(dir + "/Data/Channels");
                Directory.CreateDirectory(dir + "/Data/Channels");
                File.Create(dir + "/Data/Channels.txt").Dispose();
            }
            try
            {
                if (!File.Exists(dir + "/Data/ffmpeg.exe"))
                    using (WebClient wc = new WebClient())
                        wc.DownloadFileAsync(new Uri("https://github.com/YouAreMyTrap/EzStreamig/raw/main/ffmpeg.exe"), dir + "/Data/ffmpeg.exe");
                if (!File.Exists(dir + "/Data/youtube-dl.exe"))
                    using (WebClient wc = new WebClient())
                        wc.DownloadFileAsync(new Uri("https://github.com/YouAreMyTrap/EzStreamig/raw/main/youtube-dl.exe"), dir + "/Data/youtube-dl.exe");
                if (!File.Exists(dir + "/Data/Extensions/BotDiscord.exe"))
                    using (WebClient wc = new WebClient())
                        wc.DownloadFileAsync(new Uri("https://github.com/YouAreMyTrap/EzStreamig/raw/main/dist/BotDiscord.exe"), dir + "/Data/Extensions/BotDiscord.exe");
            }
            catch
            {
                MessageBox.Show("Error of download files, no problem i'm fixing");
                Functions.CheckFiles(dir);
            }
            if (EzStreaming.Properties.Settings.Default.StartVery) Functions.UpdateProgram();
            MainWindow win2 = new MainWindow();
            win2.Show();
            this.Close();

        }
    }
}
