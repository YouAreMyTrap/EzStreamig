using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using Microsoft.Win32;

namespace EzStream
{
    /// <summary>
    /// Lógica de interacción para NewAcc.xaml
    /// </summary>
    public partial class NewAcc : Window
    {
        private string video = "";
        private string audio = "";

        public NewAcc()
        {
            InitializeComponent();
       
        if (!Directory.Exists(Directory.GetCurrentDirectory() + "/Data"))
            Directory.CreateDirectory(Directory.GetCurrentDirectory() + "/Data");
            Directory.CreateDirectory(Directory.GetCurrentDirectory() + "/Data/Video");
            Directory.CreateDirectory(Directory.GetCurrentDirectory() + "/Data/Audio");
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Suport Format|*.mp4;*.gif;*.avi;*.mkv;*.m4v;*.raw;*.png;*.jpg";
            if (openFileDialog.ShowDialog() == true)
            { 
                video = openFileDialog.FileName;
                cb1.Content = System.IO.Path.GetFileName(video);
            }
            else
                cb1.IsChecked = false;
        }

        private void CheckBox2_Checked(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Suport Format|*.mp3;*.wav;*.acc;*.wma";
            if (openFileDialog.ShowDialog() == true)
            {
                audio = openFileDialog.FileName;
                cb2.Content = System.IO.Path.GetFileName(audio);

            }else
                cb2.IsChecked = false;
        }
        private void CheckBox_unchecked(object sender, RoutedEventArgs e)
        {
            cb1.Content = "Video";
        }
        private void CheckBox2_unchecked(object sender, RoutedEventArgs e)
        {
            cb2.Content = "Audio";
        }
        string GetPlatform(string name)
        {
            switch (name)
            {
                case "Twitch":
                    return "rtmp://live-fra.twitch.tv/app/";
                case "Youtube":
                    return "rtmp://a.rtmp.youtube.com/live2/";
                case "Facebook":
                    return "rtmp://a.rtmp.youtube.com/live2/";
                default:
                    return "rtmp://live-api-s.facebook.com:443/rtmp/";

            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Channel_Name.Text != "Channel Name" && !Channel_Name.Text.Contains(" ") && stream_key.Text != "Stream_Key")
            {
                //copy video to folder video
                if ((bool)cb1.IsChecked)

                {   //check if not is gif
                    if (System.IO.Path.GetExtension(video) != ".gif")
                        File.Copy(video, Directory.GetCurrentDirectory() + "/Data/Video/" + Channel_Name.Text + System.IO.Path.GetExtension(video));
                    else //Convert gif to mp4 for suport on ffmpeg
                    {
                        System.Diagnostics.Process process = new System.Diagnostics.Process();
                        System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                        startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                        startInfo.WorkingDirectory = Directory.GetCurrentDirectory() + "/Data/";
                        startInfo.FileName = "cmd.exe";
                        startInfo.Arguments = "/C" + $" ffmpeg -f gif -i {video} -c:v libx264 {Directory.GetCurrentDirectory() + "/Data/Video/" + Channel_Name.Text}.mp4";
                        process.StartInfo = startInfo;
                        process.Start();
                        video = Directory.GetCurrentDirectory() + "/Data/Video/" + Channel_Name.Text + ".mp4";
                    }
                    //copy music to folder music
                    if ((bool)cb2.IsChecked)
                        File.Copy(audio, Directory.GetCurrentDirectory() + "/Data/Audio/" + Channel_Name.Text + System.IO.Path.GetExtension(audio)); 

                    //Set music or no in bat
                    string input = "";
                    if ((bool)cb2.IsChecked) 
                        input = $"ffmpeg -stream_loop -1 -i {"./Audio/" + Channel_Name.Text + System.IO.Path.GetExtension(audio)} -stream_loop -1 -i {"./Video/" + Channel_Name.Text + System.IO.Path.GetExtension(video)} -c:v {Codec_sel.Text} -preset fast -b:v {bittrate.Text} -bufsize {bittrate.Text} -b:a 128k -flvflags no_duration_filesize -pix_fmt yuv420p -r {fps.Text} -f flv {GetPlatform(Plarfomr_sel.Text) + stream_key.Text}";
                    else
                        input = $"ffmpeg -stream_loop -1 -i {"./Video/" + Channel_Name.Text + System.IO.Path.GetExtension(video)} -c:v {Codec_sel.Text} -preset fast -b:v {bittrate.Text} -bufsize {bittrate.Text} -b:a 128k -flvflags no_duration_filesize -pix_fmt yuv420p -r {fps.Text} -f flv {GetPlatform(Plarfomr_sel.Text) + stream_key.Text}";
                    
                    //Create and Write bat
                    File.Create(Directory.GetCurrentDirectory() + "/Data/" + Channel_Name.Text + ".bat").Dispose();
                    using (TextWriter tw = new StreamWriter(Directory.GetCurrentDirectory() + "/Data/" + Channel_Name.Text + ".bat"))
                    { 
                        tw.WriteLine("Title " + Channel_Name.Text);
                        tw.WriteLine(input);
                        }
                    MessageBox.Show("DONE");
                }
            }
            else
            {
                MessageBox.Show("Please set correct values");
            }

        }
    

    }
}
