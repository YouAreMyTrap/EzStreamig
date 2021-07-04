using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Controls;

namespace Updater.Scripts
{
    public static class Functions
    {
        class Data
        {
            public string Dir;
            public string Output;
        }
        public static void CheckDirExist(string dir, TextBlock textBlock)
        {
            if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
            textBlock.Text = "Create: " + dir;
        }
        public static void CheckFileExist(string dir, TextBlock textBlock)
        {
            if (!File.Exists(dir)) File.Create(dir).Dispose();
            textBlock.Text = "Create: " + dir;
        }
        public static void DownalodFiles(string dir, string file, ProgressBar pgbar, TextBlock textBlock)
        {
            var directory = new Dictionary<string, Data>()
            {
                {"EzStreaming", new Data { Dir="Link", Output= dir +  @"\EzStreaming\EzStreaming.exe" } },
                {"FFMpeg",new Data { Dir="d", Output= dir + @"\EzStreaming\Data\ffmpeg.exe" }},
                {"youtube-dl",new Data { Dir="d", Output= dir + @"\EzStreaming\Data\youtube-dl.exe" }},
            };
            textBlock.Text = "Downloading: " + file;

            //System.Net.WebClient wc = new System.Net.WebClient();
            //wc.DownloadFileAsync(directory[file].Dir, directory[file].Output);
        }
    }
}
