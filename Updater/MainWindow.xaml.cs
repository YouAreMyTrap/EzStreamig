using System.Windows;
using Updater.Scripts;

namespace Updater
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string dir = System.IO.Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);

        public MainWindow()
        {
            InitializeComponent();
            
            Functions.CheckDirExist(dir + @"\EzStreaming\Data", txinfo);
            pgbar.Value = 20;
            Functions.CheckDirExist(dir + @"\EzStreaming\Data\Video", txinfo);
            pgbar.Value = 40;
            Functions.CheckDirExist(dir + @"\EzStreaming\Data\Extensions", txinfo);
            pgbar.Value = 60;
            Functions.CheckDirExist(dir + @"\EzStreaming\Data\Channels", txinfo);
            pgbar.Value = 80;
            Functions.CheckFileExist(dir + @"\EzStreaming\Data\Channels.txt", txinfo);
            pgbar.Value = 100;


        }

        private void pgbar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

            switch (pgbar.Value)
            {
                case 100:
                    Functions.DownalodFiles(dir, "EzStreaming", pgbar, txinfo);
                        break;
                case 200:
                    Functions.DownalodFiles(dir, "FFMpeg", pgbar, txinfo);
                        break;
                case 300:
                    Functions.DownalodFiles(dir, "youtube-dl", pgbar, txinfo);
                        break;
                case 400:
                    MessageBox.Show("End");
                        break;
            }

        }
    }
}
