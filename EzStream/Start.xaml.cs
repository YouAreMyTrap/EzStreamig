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


namespace EzStreaming
{
    /// <summary>
    /// Lógica de interacción para Start.xaml
    /// </summary>
    public partial class Start : Window{
        public Start(){

            if (!Directory.Exists(Directory.GetCurrentDirectory() + "/Data")){
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + "/Data");
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + "/Data/Video");
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + "/Data/Audio");
                File.Create(Directory.GetCurrentDirectory() + "/Data/Channels.txt").Dispose();
            }
            if (!File.Exists(Directory.GetCurrentDirectory() + "/Data/ffmpeg.exe"))
                using (WebClient wc = new WebClient())
                    wc.DownloadFileAsync(new Uri("https://github.com/YouAreMyTrap/EzStreamig/raw/main/ffmpeg.exe"), Directory.GetCurrentDirectory() + "/Data/ffmpeg.exe");

            AutoUpdater.Start("https://github.com/YouAreMyTrap/EzStreamig/raw/main/update.xml");
            MainWindow win2 = new MainWindow();
            win2.Show();
            this.Close();

        }
    }
}
