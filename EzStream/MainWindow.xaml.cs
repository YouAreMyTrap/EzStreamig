using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using Microsoft.Win32;
using System.Diagnostics;
using System.Net;
using AutoUpdaterDotNET;

namespace EzStream
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public class Channel { public string Channels { get; set; } public string start { get; set; } }
        public string[] vs = Directory.GetFiles(Directory.GetCurrentDirectory() + "/Data/", "*.bat", SearchOption.AllDirectories);
        public List<string> ChannelsAutoRun = new List<string>();
        Dictionary<string, int> CurrentStreaing = new Dictionary<string, int>();
        private string video = "";
        private string audio = "";

        void GetChannels()
        {
            foreach(string x in vs)
                this.lbox.Items.Add(new Channel { Channels = System.IO.Path.GetFileNameWithoutExtension(x), start = (EzStreaming.Properties.Settings.Default.AutoRunCh_bool && ChannelsAutoRun.Contains(System.IO.Path.GetFileNameWithoutExtension(x))) ? "/data/2.png" : "/data/1.png" });
        }

        public MainWindow()
        {
            InitializeComponent();
            AutoRun.IsChecked = EzStreaming.Properties.Settings.Default.AutoRun_bool;
            AutoRun2.IsChecked = EzStreaming.Properties.Settings.Default.AutoRunCh_bool;
            tbMultiLine.Text = File.ReadAllText(Directory.GetCurrentDirectory() + "/Data/Channels.txt");
            if (EzStreaming.Properties.Settings.Default.AutoRunCh_bool){ 
                AutoRunChannels();
                autostart_button_edit.Visibility = Visibility.Visible;
            }
            GetChannels();
        }

        private void btn1_Click(object sender, RoutedEventArgs e){
            Button button = sender as Button;
            Channel chn = button.DataContext as Channel;

            if (chn.start == "/data/1.png"){ 
                chn.start = "/data/2.png";
                LoadStream(chn.Channels);
            }
            else{
                chn.start = "/data/1.png";
                StopStreaming(chn.Channels);
            }
            this.lbox.Items.Refresh();
        }
        private void StopStreaming(string channel){
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.WorkingDirectory = Directory.GetCurrentDirectory() + "/Data/";
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C" + $"taskkill /F /T /PID {CurrentStreaing[channel]}";
            startInfo.UseShellExecute = false;
            startInfo.CreateNoWindow = true;
            process.StartInfo = startInfo;
            process.Start();
            CurrentStreaing.Remove(channel);
            //process.Kill();
        }
        private void AutoRunChannels(){
            ChannelsAutoRun = File.ReadAllLines(Directory.GetCurrentDirectory() + "/Data/Channels.txt").ToList();
            foreach (string x in ChannelsAutoRun)
                LoadStream(x);
        }
        private void LoadStream(string channel){
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.WorkingDirectory = Directory.GetCurrentDirectory() + "/Data/";
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C" + $"{channel}.bat";
            process.StartInfo = startInfo;
            process.Start();
            CurrentStreaing.Add(channel, process.Id);
        }

        private void btn3_Click(object sender, RoutedEventArgs e){
            MessageBox.Show("Disabled");
        }
        private void CheckBox_Checked(object sender, RoutedEventArgs e){
            string applicationLocation = Directory.GetCurrentDirectory() + "/EzStreaming.exe";
            RegistryKey reg = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            if(AutoRun.IsChecked == true){ 
                reg.SetValue("EzStream", applicationLocation);
                EzStreaming.Properties.Settings.Default.AutoRun_bool = true;
            }
            else{
                reg.DeleteValue("EzStream", false);
                EzStreaming.Properties.Settings.Default.AutoRun_bool = false;
            }
            reg.Close();
            EzStreaming.Properties.Settings.Default.Save();
        }

        private void CheckBox_channels_Checked(object sender, RoutedEventArgs e){
            if (AutoRun2.IsChecked == true){
                if (!EzStreaming.Properties.Settings.Default.AutoRunCh_bool){ 
                   // Process.Start("notepad.exe", Directory.GetCurrentDirectory() + "/Data/Channels.txt");
                    EzStreaming.Properties.Settings.Default.AutoRunCh_bool = true;
                    autostart_button_edit.Visibility = Visibility.Visible;
                }
            }
            else { 
               EzStreaming.Properties.Settings.Default.AutoRunCh_bool = false;
                autostart_button_edit.Visibility = Visibility.Hidden;
                tbMultiLine.Visibility = Visibility.Hidden;
                autostart_button_save.Visibility = Visibility.Hidden;
            }
            EzStreaming.Properties.Settings.Default.Save();
        }
        #region newuser
        private void CheckBox_video_Checked(object sender, RoutedEventArgs e){
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Suport Format|*.mp4;*.gif;*.avi;*.mkv;*.m4v;*.raw;*.png;*.jpg";
            if (openFileDialog.ShowDialog() == true){
                video = openFileDialog.FileName;
                cb1.Content = System.IO.Path.GetFileName(video);
            }else
                cb1.IsChecked = false;
        }

        private void CheckBox_audio_Checked(object sender, RoutedEventArgs e){
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Suport Format|*.mp3;*.wav;*.acc;*.wma";
            if (openFileDialog.ShowDialog() == true){
                audio = openFileDialog.FileName;
                cb2.Content = System.IO.Path.GetFileName(audio);
            }else
                cb2.IsChecked = false;
        }
        private void CheckBox_video_unchecked(object sender, RoutedEventArgs e){
            cb1.Content = "Video";
        }
        private void CheckBox_audio_unchecked(object sender, RoutedEventArgs e){
            cb2.Content = "Audio";
        }
        string GetPlatform(string name){
            switch (name){
                case "Twitch":
                    return "rtmp://live.twitch.tv/app/";
                case "Youtube":
                    return "rtmp://a.rtmp.youtube.com/live2/";
                case "Facebook":
                    return "rtmp://live-api-s.facebook.com:443/rtmp/";
                case "Trovo":
                    return "rtmp://livepush.trovo.live/live/";
                default:
                    return "rtmp://live.twitch.tv/app/";
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e){
            var template = bgrided.Template;
            var progressBar = (ProgressBar)template.FindName("pgbarr", bgrided);
            progressBar.Foreground = new SolidColorBrush(Colors.Green);
            if (Channel_Name.Text != "Channel Name" && !Channel_Name.Text.Contains(" ") && stream_key.Text != "Stream_Key" && (bool)cb1.IsChecked && !File.Exists(Directory.GetCurrentDirectory() + "/Data/" + Channel_Name.Text + ".bat")){
                progressBar.Value = 10;
                Setvideo();
                progressBar.Value = 20;
                SetAudio();
                progressBar.Value = 30;
                switch (default_presets.Text){
                    case "MusicStreamer/MassStreamer by viri":
                        if ((bool)cb2.IsChecked)
                            fabric($"ffmpeg -stream_loop -1 -i {"./Audio/" + Channel_Name.Text + System.IO.Path.GetExtension(audio)} -stream_loop -1 -i {"./Video/" + Channel_Name.Text + System.IO.Path.GetExtension(video)} -c:v libx264 - preset veryfast -b:v 3000k -maxrate 3000k -bufsize 6000k -pix_fmt yuv420p -g 50 -c:a aac -b:a 160k -ac 2 -ar 44100 -f flv rtmp://live.twitch.tv/app/{stream_key.Text}");
                        else
                            fabric($"ffmpeg -stream_loop -1 -i {"./Video/" + Channel_Name.Text + System.IO.Path.GetExtension(video)} -c:v libx264 -preset veryfast -b:v 3000k -maxrate 3000k -bufsize 6000k -pix_fmt yuv420p -g 50 -c:a aac -b:a 160k -ac 2 -ar 44100 -f flv rtmp://live.twitch.tv/app/{stream_key.Text}");
                      break;
                    case "MusicStreamer/MassStreamer by viri - MOD GPU NVIDEA":
                        if ((bool)cb2.IsChecked)
                            fabric($"ffmpeg -stream_loop -1 -i {"./Audio/" + Channel_Name.Text + System.IO.Path.GetExtension(audio)} -stream_loop -1 -i {"./Video/" + Channel_Name.Text + System.IO.Path.GetExtension(video)} -c:v h264_nvenc -preset fast -b:v 3000k -maxrate 3000k -bufsize 6000k -pix_fmt yuv420p -g 50 -c:a aac -b:a 160k -ac 2 -ar 44100 -f flv rtmp://live.twitch.tv/app/{stream_key.Text}");
                        else
                            fabric($"ffmpeg -stream_loop -1 -i {"./Video/" + Channel_Name.Text + System.IO.Path.GetExtension(video)} -c:v h264_nvenc -preset fast -b:v 3000k -maxrate 3000k -bufsize 6000k -pix_fmt yuv420p -g 50 -c:a aac -b:a 160k -ac 2 -ar 44100 -f flv rtmp://live.twitch.tv/app/{stream_key.Text}");
                      break;
                    case "MusicStreamer/MassStreamer by viri - MOD GPU AMD":
                        if ((bool)cb2.IsChecked)
                            fabric($"ffmpeg -stream_loop -1 -i {"./Audio/" + Channel_Name.Text + System.IO.Path.GetExtension(audio)} -stream_loop -1 -i {"./Video/" + Channel_Name.Text + System.IO.Path.GetExtension(video)} -c:v h264_amf -b:v 3000k -maxrate 3000k -bufsize 6000k -pix_fmt yuv420p -g 50 -c:a aac -b:a 160k -ac 2 -ar 44100 -f flv rtmp://live.twitch.tv/app/{stream_key.Text}");
                        else
                            fabric($"ffmpeg -stream_loop -1 -i {"./Video/" + Channel_Name.Text + System.IO.Path.GetExtension(video)} -c:v h264_amf -b:v 3000k -maxrate 3000k -bufsize 6000k -pix_fmt yuv420p -g 50 -c:a aac -b:a 160k -ac 2 -ar 44100 -f flv rtmp://live.twitch.tv/app/{stream_key.Text}");
                      break;
                    case "GPU NVIDEA":
                      break;
                    case "GPU AMD":
                      break;
                    case "CPU":
                      break;
                    case "Custom":
                        if ((bool)cb2.IsChecked)
                            fabric($"ffmpeg -stream_loop -1 -i {"./Audio/" + Channel_Name.Text + System.IO.Path.GetExtension(audio)} -stream_loop -1 -i {"./Video/" + Channel_Name.Text + System.IO.Path.GetExtension(video)} -c:v {Codec_sel.Text} -preset fast -b:v {bittrate.Text} -bufsize {bittrate.Text} -b:a 128k -flvflags no_duration_filesize -pix_fmt yuv420p -r {fps.Text} -f flv {GetPlatform(Plarfomr_sel.Text) + stream_key.Text}");
                        else
                            fabric($"ffmpeg -stream_loop -1 -i {"./Video/" + Channel_Name.Text + System.IO.Path.GetExtension(video)} -c:v {Codec_sel.Text} -preset fast -b:v {bittrate.Text} -bufsize {bittrate.Text} -b:a 128k -flvflags no_duration_filesize -pix_fmt yuv420p -r {fps.Text} -f flv {GetPlatform(Plarfomr_sel.Text) + stream_key.Text}");
                      break;
                }
                progressBar.Value = 40;
                this.lbox.Items.Add(new Channel { Channels = Channel_Name.Text, start = "/data/1.png" });
                progressBar.Value = 50;
                Create_profile();
                progressBar.Value = 100;
            }
            else { 
                //MessageBox.Show("Please set correct values");
                progressBar.Foreground = new SolidColorBrush(Colors.Red);
                progressBar.Value = 100;
            }
        }
        void Setvideo(){
            if (System.IO.Path.GetExtension(video) != ".gif")
                File.Copy(video, Directory.GetCurrentDirectory() + "/Data/Video/" + Channel_Name.Text + System.IO.Path.GetExtension(video));
            else{ //Convert gif to mp4 for suport on ffmpeg
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                startInfo.WorkingDirectory = Directory.GetCurrentDirectory() + "/Data/";
                startInfo.FileName = "cmd.exe";
                startInfo.Arguments = "/C" + $" ffmpeg -f gif -i {video} -vf scale={Resolution.Text} -c:v libx264 -pix_fmt yuv420p {Directory.GetCurrentDirectory() + "/Data/Video/" + Channel_Name.Text}.mp4";
                startInfo.UseShellExecute = false;
                startInfo.CreateNoWindow = true;
                process.StartInfo = startInfo;
                process.Start();
                video = Directory.GetCurrentDirectory() + "/Data/Video/" + Channel_Name.Text + ".mp4";
                process.WaitForExit();
            }
        }
        void SetAudio(){
            //copy music to folder music
            if ((bool)cb2.IsChecked)
                File.Copy(audio, Directory.GetCurrentDirectory() + "/Data/Audio/" + Channel_Name.Text + System.IO.Path.GetExtension(audio));
        }
        
        void fabric(string input)
        {
            File.Create(Directory.GetCurrentDirectory() + "/Data/" + Channel_Name.Text + ".bat").Dispose();
            using (TextWriter tw = new StreamWriter(Directory.GetCurrentDirectory() + "/Data/" + Channel_Name.Text + ".bat"))
            {
                tw.WriteLine("Title " + Channel_Name.Text);
                tw.WriteLine("mode con:lines=1");
                tw.WriteLine("color 5A");
                tw.WriteLine(input);
            }
        }
        private void default_presets_DropDownClosed(object sender, EventArgs e){
            Custom.Visibility = Visibility.Hidden;
            extra.Visibility = Visibility.Hidden;
            switch (default_presets.Text){
                case "MusicStreamer/MassStreamer by viri":
                    Custom.Visibility = Visibility.Visible;
                    break;
                case "MusicStreamer/MassStreamer by viri - MOD GPU NVIDEA":
                    Custom.Visibility = Visibility.Visible;
                    break;
                case "MusicStreamer/MassStreamer by viri - MOD GPU AMD":
                    Custom.Visibility = Visibility.Visible;
                    break;
                case "GPU NVIDEA":
                    break;
                case "GPU AMD":
                    break;
                case "CPU":
                    break;
                case "Custom":
                    Custom.Visibility = Visibility.Visible;
                    extra.Visibility = Visibility.Visible;
                    break;
            }
        }
        #endregion
        void Create_profile()
        {
            Dictionary<string, string> profile = new Dictionary<string, string>()
            {
                { "default_presets", default_presets.Text },
                { "Name", Channel_Name.Text },
                { "Platform", Plarfomr_sel.Text },
                { "FPS", fps.Text },
                { "Codec", Codec_sel.Text },
                { "StreamKey", stream_key.Text },
                { "Bittrate", bittrate.Text },
                { "Preset", Preset.Text }
            };
            File.Create(Directory.GetCurrentDirectory() + "/Data/Channels/" + Channel_Name.Text + ".dic").Dispose();
            using (TextWriter tw = new StreamWriter(Directory.GetCurrentDirectory() + "/Data/Channels/" + Channel_Name.Text + ".dic"))
            {
                foreach (var entry in profile)
                    tw.WriteLine("[{0}: {1}]", entry.Key, entry.Value);
            }
        }

        private void autostart_button_save_Click(object sender, RoutedEventArgs e)
        {
            using (TextWriter tw = new StreamWriter(Directory.GetCurrentDirectory() + "/Data/Channels.txt"))
                tw.Write(tbMultiLine.Text);
        }

        private void autostart_button_edit_Click(object sender, RoutedEventArgs e)
        {
            if (tbMultiLine.Visibility == Visibility.Visible){
                tbMultiLine.Visibility = Visibility.Hidden;
                autostart_button_save.Visibility = Visibility.Hidden;
            }
            else{
                tbMultiLine.Visibility = Visibility.Visible;
                autostart_button_save.Visibility = Visibility.Visible;
            }
        }
    }
}
