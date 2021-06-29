using EzStream;
using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
namespace EzStreaming
{
    /// <summary>
    /// Lógica de interacción para YouTubeDownloaderWindows.xaml
    /// </summary>
    public partial class YouTubeDownloaderWindows : Window
    {
        string format, file, dir = System.IO.Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName) + @"\Data";

        private Process ytProces = new Process();
        private ProgressBar progressBar = new ProgressBar();


        private string[] outputSeparators;
        //ProgressBar progressBar = new ProgressBar();
        public YouTubeDownloaderWindows()
        {
            InitializeComponent();
            var generator = new Random();
            PrepareytProces();
            file = Registry.GetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Shell Folders", "{374DE290-123F-4565-9164-39C4925E467B}", String.Empty).ToString() + @$"\ezstreamingVIDEO_{generator.Next(1000000, 9000000)}.mp4";
        }
        public string Format
        {
            get { return format; }
            set { format = value; }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ytProces.StartInfo.ArgumentList.Clear();
            ytProces.StartInfo.WorkingDirectory = dir;
            var check_format = "";
            if (settings_audio.Text != "Auto") // custom format
            {
                check_format += " -f ";

                if (settings_audio.Text.Contains("YouTube "))
                {
                    var parsedFormat = settings_audio.Text.Split(new char[] { '(', ')' });
                    if (parsedFormat.Length >= 2)
                        check_format += parsedFormat[1] + " ";
                    else
                        check_format += settings_audio.Text + " ";
                }
                else
                {
                    check_format += settings_audio.Text + " ";
                }

                if (check_format != "Auto") // merge into target container
                {
                    check_format += " --merge-output-format ";
                    check_format += settings_audio.Text;
                }
            }
            ytProces.StartInfo.ArgumentList.Add($"/C youtube-dl.exe {check_format} -f mp4 --no-playlist -o {file} {ytlink.Text}");
            bgrided.IsEnabled = false;
            ytProces.Start();
            ytProces.BeginOutputReadLine();
        }


        private void linkyt_keyup(object sender, KeyEventArgs e){
            //MessageBox.Show(video.Duration.ToString());
            try{

            }
            catch{
                MessageBox.Show("Error in Link");
            }

            //MessageBox.Show(streamInfo.ToString());

            //settings.IsEnabled = true;
        }
        private void PrepareytProces(){
            ytProces.StartInfo.FileName = "cmd.exe";
            ytProces.StartInfo.UseShellExecute = false;
            ytProces.StartInfo.RedirectStandardOutput = true;
            ytProces.StartInfo.RedirectStandardError = true;
            ytProces.StartInfo.CreateNoWindow = true;
            ytProces.OutputDataReceived += new DataReceivedEventHandler((object ? sendingProcess, DataReceivedEventArgs outLine) => { if (!String.IsNullOrEmpty(outLine.Data)) this.resultTextBox.Dispatcher.Invoke(new Action(() => { this.resultTextBox.AppendText(outLine.Data + Environment.NewLine); this.resultTextBox.ScrollToEnd(); ParseDlOutput(outLine.Data); }));  });
        }

        
        private void StartDownload()
        {
            //outputString.Clear();
            //ytProces.StartInfo.FileName = Settings.DlPath;
            ytProces.StartInfo.ArgumentList.Clear();

            /*try
            {
                if (!string.IsNullOrEmpty(Settings.Proxy))
                {
                    ytProces.StartInfo.ArgumentList.Add("--proxy");
                    ytProces.StartInfo.ArgumentList.Add($"{Settings.Proxy}");
                }

                if (!string.IsNullOrEmpty(Settings.FfmpegPath))
                {
                    ytProces.StartInfo.ArgumentList.Add("--ffmpeg-location");
                    ytProces.StartInfo.ArgumentList.Add($"{Settings.FfmpegPath}");
                }

                if (Settings.Format != "Auto") // custom format
                {
                    ytProces.StartInfo.ArgumentList.Add("-f");

                    if (Settings.Format.Contains("YouTube "))
                    {
                        var parsedFormat = Settings.Format.Split(new char[] { '(', ')' });
                        if (parsedFormat.Length >= 2)
                            ytProces.StartInfo.ArgumentList.Add($"{parsedFormat[1]}");
                        else
                            ytProces.StartInfo.ArgumentList.Add($"{Settings.Format}");
                    }
                    else
                    {
                        ytProces.StartInfo.ArgumentList.Add($"{Settings.Format}");
                    }

                    if (Settings.Container != "Auto") // merge into target container
                    {
                        ytProces.StartInfo.ArgumentList.Add("--merge-output-format");
                        ytProces.StartInfo.ArgumentList.Add($"{Settings.Container}");
                    }
                }
                else if (Settings.Container != "Auto") // custom container
                {
                    ytProces.StartInfo.ArgumentList.Add("-f");
                    ytProces.StartInfo.ArgumentList.Add($"{Settings.Container}");
                }

                if (Settings.AddMetadata)
                    ytProces.StartInfo.ArgumentList.Add("--add-metadata");

                if (Settings.DownloadThumbnail)
                    ytProces.StartInfo.ArgumentList.Add("--embed-thumbnail");

                if (Settings.DownloadSubtitles)
                {
                    ytProces.StartInfo.ArgumentList.Add("--write-sub");
                    ytProces.StartInfo.ArgumentList.Add("--embed-subs");
                }

                if (Settings.DownloadPlaylist)
                {
                    ytProces.StartInfo.ArgumentList.Add("--yes-playlist");
                }
                else
                {
                    ytProces.StartInfo.ArgumentList.Add("--no-playlist");
                }

                if (Settings.UseCustomPath)
                {
                    ytProces.StartInfo.ArgumentList.Add("-o");
                    ytProces.StartInfo.ArgumentList.Add($@"{Settings.DownloadPath}\%(title)s-%(id)s.%(ext)s");
                }

                ytProces.StartInfo.ArgumentList.Add($"{Link}");

                ytProces.Start();
                ytProces.BeginErrorReadLine();
                ytProces.BeginOutputReadLine();

                //FreezeButton = true;
                //DownloadButtonProgressIndeterminate = true;*/
        }

        private void App_load(object sender, RoutedEventArgs e){
            var template = bgrided.Template;
            progressBar = (ProgressBar)template.FindName("pgbarr", bgrided);
            //progressBar.Foreground = new SolidColorBrush(Colors.Red);
            outputSeparators = new string[]{
                "[download]",
                "of",
                "at",
                "ETA",
                " "
            };
        }
        private void ParseDlOutput(string output)
        {
            var parsedStringArray = output.Split(outputSeparators, StringSplitOptions.RemoveEmptyEntries);
            if (parsedStringArray.Length == 4) // valid [download] line
            {
                var percentageString = parsedStringArray[0];
                if (percentageString.EndsWith('%')) // actual percentage
                {
                    // show percentage on button
                    //DownloadButtonProgressPercentageString = percentageString;

                    // get percentage value for progress bar
                    var percentageNumberString = percentageString.TrimEnd('%');
                    float x = float.Parse(percentageNumberString);
                    //MessageBox.Show(x.ToString());

                    progressBar.Value = x;
                    if (double.TryParse(percentageNumberString, out var percentageNumber))
                    {
                        //MessageBox.Show(percentageNumberString);
                        //progressBar = (int)percentageNumber;
                        //DownloadButtonProgressIndeterminate = false;
                    }
                }

                // save other info
                //FileSizeString = parsedStringArray[1];
                //DownloadSpeedString = parsedStringArray[2];
                //DownloadETAString = parsedStringArray[3];
            }
        }

        private void pgbarr_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (progressBar.Value == 100)
            {
                //MessageBox.Show("100");
                foreach (var item in Application.Current.Windows)
                {
                    if (item is MainWindow window)
                    {
                            //MessageBox.Show("1020");
                            window.ytvideo.Content = System.IO.Path.GetFileName(file);
                            window.video = file;
                        //window.lbox.Items.Clear();
                            this.Close();
                    }
                }
            }
        }

        private void Windows_Closed(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (progressBar.Value != 100) { 
                MessageBox.Show("Close");
            }
        }
    }
}
