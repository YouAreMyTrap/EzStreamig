using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.IO;
using Microsoft.Win32;
using MaterialDesignThemes.Wpf;
using System.Diagnostics;
using EzStreaming;
using EzStreaming.Scripts;
using System.Collections;

namespace EzStream
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string video, audio, dir = System.IO.Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
        public class Channel { public string Channels { get; set; } public string start { get; set; } }
        ArrayList ListChannels = new ArrayList();
        public string[] vs = Directory.GetFiles(System.IO.Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName) + "/Data/", "*.bat");
        public List<string> ChannelsAutoRun = new List<string>();
        Dictionary<string, Process> CurrentStreaming = new Dictionary<string, Process>();
        private Process DiscordBot = new Process();


        void GetChannels() => Array.ForEach(vs, x => ListChannels.Add(new Channel { Channels = System.IO.Path.GetFileNameWithoutExtension(x), start = (EzStreaming.Properties.Settings.Default.AutoRunCh_bool && ChannelsAutoRun.Contains(System.IO.Path.GetFileNameWithoutExtension(x))) ? "/data/2.png" : "/data/1.png" }));
            //foreach (string x in vs)
              //  this.lbox.Items.Add(new Channel { Channels = System.IO.Path.GetFileNameWithoutExtension(x), start = (EzStreaming.Properties.Settings.Default.AutoRunCh_bool && ChannelsAutoRun.Contains(System.IO.Path.GetFileNameWithoutExtension(x))) ? "/data/2.png" : "/data/1.png" });

        public MainWindow()
        {
            InitializeComponent();
            togglebutton_AutoRunEzStreaming.IsChecked = EzStreaming.Properties.Settings.Default.AutoRun_bool;
            togglebutton_StartVerify.IsChecked = EzStreaming.Properties.Settings.Default.StartVery;
            togglebutton_AutoRunChannels.IsChecked = EzStreaming.Properties.Settings.Default.AutoRunCh_bool;
            togglebutton_DiscordBot.IsChecked = EzStreaming.Properties.Settings.Default.Discord_bool;
            tbMultiLine.IsEnabled = EzStreaming.Properties.Settings.Default.AutoRunCh_bool;
            autostart_button_save.IsEnabled = EzStreaming.Properties.Settings.Default.AutoRunCh_bool;

            tbMultiLine.Text = File.ReadAllText(dir + "/Data/Channels.txt");

            if (EzStreaming.Properties.Settings.Default.Discord_bool) StartDiscord();
            if (EzStreaming.Properties.Settings.Default.AutoRunCh_bool) AutoRunChannels();
            GetChannels();
            lbox.ItemsSource = ListChannels;
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
            CurrentStreaming[channel].Kill();
        }
        private void AutoRunChannels(){
            ChannelsAutoRun = File.ReadAllLines(dir + "/Data/Channels.txt").ToList();
            ChannelsAutoRun.ForEach(x => LoadStream(x));
            //foreach (string x in ChannelsAutoRun)
              //  LoadStream(x);
        }
        private void LoadStream(string channel){
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.StartInfo.WorkingDirectory = dir + "/Data/";
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.Arguments = "/C" + $"{channel}.bat";
            process.Start();
            CurrentStreaming.Add(channel, process);
        }

        private void btn3_Click(object sender, RoutedEventArgs e){
            if (MessageBox.Show("Sure you want to delete?? ", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes){ 
                Button button = sender as Button;
                Channel chn = button.DataContext as Channel;
                DirectoryInfo dir2 = new DirectoryInfo(dir + "/Data/");
                FileInfo[] files = dir2.GetFiles(chn.Channels + "*", SearchOption.AllDirectories);
                Array.ForEach(files, file => File.Delete(file.ToString()));
                this.lbox.Items.Remove(chn);
            }
        }
        #region newuser
        private void CheckBox_video_Checked(object sender, RoutedEventArgs e){
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Suport Format|*.mp4;*.gif;*.avi;*.mkv;*.m4v;*.raw;*.png;*.jpg";
            if (openFileDialog.ShowDialog() == true){
                video = openFileDialog.FileName;
                cb1.Content = System.IO.Path.GetFileName(video);
                ytvideo.IsChecked = false;
            }
            else
                cb1.IsChecked = false;
        }
        private void ytvideo_Checked(object sender, RoutedEventArgs e)
        {
            cb1.IsChecked = false;
            //ytlink_video.Visibility = Visibility.Visible;
            YouTubeDownloaderWindows windows = new YouTubeDownloaderWindows();
            //windows.Format = "MP4";
            windows.Show();
        }
        private void ytaudio_Checked(object sender, RoutedEventArgs e)
        {
            cb2.IsChecked = false;
            ytlink_audio.Visibility = Visibility.Visible;
        }
        private void ytvideo_unchecked(object sender, RoutedEventArgs e){ 
            //ytlink_video.Visibility = Visibility.Hidden;
            ytvideo.Content = "Link Youtube";
            video = "";
        }
        private void ytaudio_unchecked(object sender, RoutedEventArgs e){ 
            //ytlink_audio.Visibility = Visibility.Hidden;
            ytlink_audio.Text = "Link Youtube";
            audio = "";
        }
        private void CheckBox_audio_Checked(object sender, RoutedEventArgs e){
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Suport Format|*.mp3;*.wav;*.acc;*.wma";
            if (openFileDialog.ShowDialog() == true){
                audio = openFileDialog.FileName;
                cb2.Content = System.IO.Path.GetFileName(audio);
                ytaudio.IsChecked = false;
            }
            else { 
                cb2.IsChecked = false;
                audio = "";
            }
        }

        private void CheckBox_video_unchecked(object sender, RoutedEventArgs e){
            cb1.Content = "Video";
            video = "";
        }
        private void CheckBox_audio_unchecked(object sender, RoutedEventArgs e){
            cb2.Content = "Audio";
            audio = "";
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
            if (!Channel_Name.Text.Contains(" ") && video != "" && !File.Exists(dir + "/Data/" + Channel_Name.Text + ".bat")){
                ButtonProgressAssist.SetIsIndicatorVisible(bgrided, true);
                Setvideo();
                SetAudio();
                switch (default_presets.Text){
                    case "MusicStreamer/MassStreamer by viri":
                        if ((bool)cb2.IsChecked)
                            Functions.fabric($"ffmpeg -stream_loop -1 -i {"./Audio/" + Channel_Name.Text + System.IO.Path.GetExtension(audio)} -stream_loop -1 -i {"./Video/" + Channel_Name.Text + System.IO.Path.GetExtension(video)} -c:v libx264 - preset veryfast -b:v 3000k -maxrate 3000k -bufsize 6000k -pix_fmt yuv420p -g 50 -c:a aac -b:a 160k -ac 2 -ar 44100 -f flv rtmp://live.twitch.tv/app/{stream_key.Text}", dir, Channel_Name.Text);
                        else
                            Functions.fabric($"ffmpeg -stream_loop -1 -i {"./Video/" + Channel_Name.Text + System.IO.Path.GetExtension(video)} -c:v libx264 -preset veryfast -b:v 3000k -maxrate 3000k -bufsize 6000k -pix_fmt yuv420p -g 50 -c:a aac -b:a 160k -ac 2 -ar 44100 -f flv rtmp://live.twitch.tv/app/{stream_key.Text}", dir, Channel_Name.Text);
                      break;
                    case "MusicStreamer/MassStreamer by viri - MOD GPU NVIDEA":
                        if ((bool)cb2.IsChecked)
                            Functions.fabric($"ffmpeg -stream_loop -1 -i {"./Audio/" + Channel_Name.Text + System.IO.Path.GetExtension(audio)} -stream_loop -1 -i {"./Video/" + Channel_Name.Text + System.IO.Path.GetExtension(video)} -c:v h264_nvenc -preset fast -b:v 3000k -maxrate 3000k -bufsize 6000k -pix_fmt yuv420p -g 50 -c:a aac -b:a 160k -ac 2 -ar 44100 -f flv rtmp://live.twitch.tv/app/{stream_key.Text}", dir, Channel_Name.Text);
                        else
                            Functions.fabric($"ffmpeg -stream_loop -1 -i {"./Video/" + Channel_Name.Text + System.IO.Path.GetExtension(video)} -c:v h264_nvenc -preset fast -b:v 3000k -maxrate 3000k -bufsize 6000k -pix_fmt yuv420p -g 50 -c:a aac -b:a 160k -ac 2 -ar 44100 -f flv rtmp://live.twitch.tv/app/{stream_key.Text}", dir, Channel_Name.Text);
                      break;
                    case "MusicStreamer/MassStreamer by viri - MOD GPU AMD":
                        if ((bool)cb2.IsChecked)
                            Functions.fabric($"ffmpeg -stream_loop -1 -i {"./Audio/" + Channel_Name.Text + System.IO.Path.GetExtension(audio)} -stream_loop -1 -i {"./Video/" + Channel_Name.Text + System.IO.Path.GetExtension(video)} -c:v h264_amf -b:v 3000k -maxrate 3000k -bufsize 6000k -pix_fmt yuv420p -g 50 -c:a aac -b:a 160k -ac 2 -ar 44100 -f flv rtmp://live.twitch.tv/app/{stream_key.Text}", dir, Channel_Name.Text);
                        else
                            Functions.fabric($"ffmpeg -stream_loop -1 -i {"./Video/" + Channel_Name.Text + System.IO.Path.GetExtension(video)} -c:v h264_amf -b:v 3000k -maxrate 3000k -bufsize 6000k -pix_fmt yuv420p -g 50 -c:a aac -b:a 160k -ac 2 -ar 44100 -f flv rtmp://live.twitch.tv/app/{stream_key.Text}", dir, Channel_Name.Text);
                      break;
                    case "autoStreamerv2 - Grand Bob":
                        Functions.fabric($"ffmpeg -stream_loop -1 -i {"./Video/" + Channel_Name.Text + System.IO.Path.GetExtension(video)} -codec:v libx264 -pix_fmt yuv420p -preset veryfast -b:v 400k -g 10.0 -codec:a aac -b:a 96k -ar 44100 -maxrate 400k -bufsize 200k -strict experimental -f flv rtmp://live.twitch.tv/app/{stream_key.Text}", dir, Channel_Name.Text);
                      break;
                    case "GPU NVIDEA":
                      break;
                    case "GPU AMD":
                      break;
                    case "CPU":
                      break;
                    case "Custom":
                        if (audio == "") { 
                        Functions.fabric($"ffmpeg -stream_loop -1 -i {"./Audio/" + Channel_Name.Text + System.IO.Path.GetExtension(audio)} -stream_loop -1 -i {"./Video/" + Channel_Name.Text + System.IO.Path.GetExtension(video)} -c:v {Codec_sel.Text} -preset fast -b:v {bittrate.Text} -bufsize {bittrate.Text} -b:a 128k -flvflags no_duration_filesize -pix_fmt yuv420p -r {fps.Text} -f flv {GetPlatform(Plarfomr_sel.Text) + stream_key.Text}", dir, Channel_Name.Text);
                        }
                        else { 
                        Functions.fabric($"ffmpeg -stream_loop -1 -i {"./Video/" + Channel_Name.Text + System.IO.Path.GetExtension(video)} -c:v {Codec_sel.Text} -preset fast -b:v {bittrate.Text} -bufsize {bittrate.Text} -b:a 128k -flvflags no_duration_filesize -pix_fmt yuv420p -r {fps.Text} -f flv {GetPlatform(Plarfomr_sel.Text) + stream_key.Text}", dir, Channel_Name.Text);
                        }
                        break;
                }
                ListChannels.Add(new Channel { Channels = Channel_Name.Text, start = "/data/1.png" });
                lbox.Items.Refresh();
                Create_profile();
                ButtonProgressAssist.SetIsIndicatorVisible(bgrided, false);
                SnackbarFour.MessageQueue.Enqueue("Sucesful making streaming");
            }
            else
            {
                ButtonProgressAssist.SetIsIndicatorVisible(bgrided, false);
                SnackbarFour.MessageQueue.Enqueue("Error");
                //MessageBox.Show("Please set correct values");

            }
        }
        void Setvideo()
        {
            if (System.IO.Path.GetExtension(video) != ".gif" && video != "") {
                var FileDestination = new FileInfo(dir + "/Data/Video/" + Channel_Name.Text + System.IO.Path.GetExtension(video));
                var FileSource = new FileInfo(video);
                int vaule;
                Task.Run(() => { FileSource.CopyTo(FileDestination, x => Dispatcher.Invoke(() => vaule = x)); }).GetAwaiter();

            }
            else
            { //Convert gif to mp4 for suport on ffmpeg
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                process.StartInfo.WorkingDirectory = dir + "/Data/";
                process.StartInfo.FileName = "cmd.exe";
                process.StartInfo.Arguments = "/C" + $" ffmpeg -f gif -i {video} -vf scale={Resolution.Text} -c:v libx264 -pix_fmt yuv420p {dir + "/Data/Video/" + Channel_Name.Text}.mp4";
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;
                process.Start();
                video = dir + "/Data/Video/" + Channel_Name.Text + ".mp4";
                process.WaitForExit();
            }
            SnackbarFour.MessageQueue.Enqueue("Video Correct");
        }
        void SetAudio()
        {
            //copy music to folder music
            if (audio == "") {
                var FileDestination = new FileInfo(dir + "/Data/Audio/" + Channel_Name.Text + System.IO.Path.GetExtension(audio));
                var FileSource = new FileInfo(audio);
                int vaule;
                Task.Run(() => { FileSource.CopyTo(FileDestination, x => Dispatcher.Invoke(() => vaule = x)); }).GetAwaiter();
                SnackbarFour.MessageQueue.Enqueue("Audio Correct");
            }
        }
        

        private void default_presets_DropDownClosed(object sender, EventArgs e){
            Custom.Visibility = Visibility.Hidden;
            extra.Visibility = Visibility.Hidden;
            cb2.Visibility = Visibility.Visible;
            //ytaudio.Visibility = Visibility.Visible;
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
                case "autoStreamerv2 - Grand Bob":
                    Custom.Visibility = Visibility.Visible;
                    cb2.Visibility = Visibility.Hidden;
                    ytaudio.Visibility = Visibility.Hidden;
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
        void Create_profile(){
            Dictionary<string, string> profile = new Dictionary<string, string>(){
                { "default_presets", default_presets.Text },
                { "Name", Channel_Name.Text },
                { "Platform", Plarfomr_sel.Text },
                { "FPS", fps.Text },
                { "Codec", Codec_sel.Text },
                { "StreamKey", stream_key.Text },
                { "Bittrate", bittrate.Text },
                { "Preset", Preset.Text }
            };
            File.Create(dir + "/Data/Channels/" + Channel_Name.Text + ".dic").Dispose();
            using (TextWriter tw = new StreamWriter(dir + "/Data/Channels/" + Channel_Name.Text + ".dic"))
            {
                foreach (var entry in profile)
                    tw.WriteLine("[{0}: {1}]", entry.Key, entry.Value);
            }
        }

        private void autostart_button_save_Click(object sender, RoutedEventArgs e)
        {
            using (TextWriter tw = new StreamWriter(dir + "/Data/Channels.txt"))
                tw.Write(tbMultiLine.Text);
        }

        private void VerifyFiles_Click(object sender, RoutedEventArgs e)
        {
            Functions.CheckFiles(dir, SnackbarFour);
            SnackbarFour.MessageQueue.Enqueue("All errors fixed");
        }

        private void Windows_Close(object sender, EventArgs e)
        {
            StopDiscord();
        }


        private void togglebutton_AutoRunChannels_Checked(object sender, RoutedEventArgs e)
        {
            EzStreaming.Properties.Settings.Default.AutoRunCh_bool = (bool)togglebutton_AutoRunChannels.IsChecked;
            tbMultiLine.IsEnabled = (bool)togglebutton_AutoRunChannels.IsChecked;
            autostart_button_save.IsEnabled = (bool)togglebutton_AutoRunChannels.IsChecked;
            EzStreaming.Properties.Settings.Default.Save();
            SnackbarFour.MessageQueue.Enqueue($"Auto Run Channels: {(bool)togglebutton_AutoRunChannels.IsChecked}");
        }

        private void togglebutton_AutoRunEzStreaming_Checked(object sender, RoutedEventArgs e)
        {
            object Index = "Startup";
            IWshRuntimeLibrary.WshShell wshShell = new IWshRuntimeLibrary.WshShellClass();
            string file = (string)wshShell.SpecialFolders.Item(ref Index) + "\\EzStreaming.lnk";
            //Process.GetCurrentProcess().MainModule.FileName
            if ((bool)togglebutton_AutoRunEzStreaming.IsChecked)
            {
                IWshRuntimeLibrary.IWshShortcut obj = (IWshRuntimeLibrary.IWshShortcut)wshShell.CreateShortcut(file);
                obj.Description = "EzStreming Shortcut";
                obj.TargetPath = Process.GetCurrentProcess().MainModule.FileName;
                obj.Save();
            }
            else
            {
                File.Delete(file);
            }

            EzStreaming.Properties.Settings.Default.Save();
            SnackbarFour.MessageQueue.Enqueue($"Startup EzStreaming: {(bool)togglebutton_AutoRunEzStreaming.IsChecked}");
        }

        private void togglebutton_StartVerify_Checked(object sender, RoutedEventArgs e)
        {
            EzStreaming.Properties.Settings.Default.StartVery = (bool)togglebutton_StartVerify.IsChecked;
            SnackbarFour.MessageQueue.Enqueue($"SVerify Files on start: {(bool)togglebutton_StartVerify.IsChecked}");

        }

        private void Hyperlinks_click(object sender, RoutedEventArgs e)
        {
            System.Windows.Documents.Hyperlink hyperlink = sender as System.Windows.Documents.Hyperlink;
            var p = new ProcessStartInfo();
                p.UseShellExecute = true;
                p.FileName = hyperlink.NavigateUri.ToString();
            Process.Start(p);
            //hyperlink.NavigateUri.ToString();



        }

        private void togglebutton_DiscordBot_Checked(object sender, RoutedEventArgs e)
        {
            EzStreaming.Properties.Settings.Default.Discord_bool = (bool)togglebutton_DiscordBot.IsChecked;
            EzStreaming.Properties.Settings.Default.Save();
            SnackbarFour.MessageQueue.Enqueue($"Please Restart app for: {(bool)togglebutton_DiscordBot.IsChecked} Discord Bot");
        }

        private void CheckUpdates_Click(object sender, RoutedEventArgs e)
        {
            Functions.UpdateProgram();
            SnackbarFour.MessageQueue.Enqueue("Check Update Program");
        }

        private void StartDiscord()
        {
            discordtabitem.Visibility = Visibility.Visible;
            DiscordBot.StartInfo.FileName = dir + @"\Data\Extensions\Bot.exe";
            DiscordBot.StartInfo.UseShellExecute = false;
            DiscordBot.StartInfo.RedirectStandardOutput = true;
            DiscordBot.StartInfo.CreateNoWindow = true;
            DiscordBot.OutputDataReceived += new DataReceivedEventHandler((object? sendingProcess, DataReceivedEventArgs outLine) => {
                if (!String.IsNullOrEmpty(outLine.Data)) this.resultTextBox.Dispatcher.Invoke(new Action(() => {
                    this.resultTextBox.AppendText(outLine.Data + Environment.NewLine);
                    this.resultTextBox.ScrollToEnd();
                    if (outLine.Data != "Started")
                    {
                        Channel chn = new Channel();
                        chn.Channels = outLine.Data.Split(": ")[1];
                        Channel chn2 = lbox.Items[lbox.Items.Cast<Channel>().ToList().FindIndex(x => x.Channels == chn.Channels)] as Channel;
                        if (outLine.Data.Split(": ")[0] == "Stop" && chn2.start == "/data/2.png")
                        {
                            StopStreaming(chn2.Channels);
                            chn2.start = "/data/1.png";
                        }
                        if (outLine.Data.Split(": ")[0] == "Start" && chn2.start == "/data/1.png")
                        {
                            LoadStream(chn2.Channels);
                            chn2.start = "/data/2.png";
                        }
                        this.lbox.Items.Refresh();

                    }
                    else
                        SnackbarFour.MessageQueue.Enqueue("Error Load Discord Bot");


                }));
            });
            DiscordBot.Start();
            DiscordBot.BeginOutputReadLine();
        }
        private void StopDiscord()
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C" + $"taskkill /F /T /PID {DiscordBot.Id}";
            startInfo.UseShellExecute = false;
            startInfo.CreateNoWindow = true;
            process.StartInfo = startInfo;
            process.Start();
        }
        
    }
}

