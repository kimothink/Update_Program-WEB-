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
using System.Net;
using System.ComponentModel;

namespace Update_Program
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Download();
        }

        private void Download()
        {
            var DocFolder = Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments);
            var webClient = new WebClient();
            webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
            webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
            webClient.DownloadFileAsync(new Uri("http://update.mapinfo.co.kr/FSBM_Setup.exe"), DocFolder+@"\FSBM_Setup.exe");
            
        }

        private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            this.progressBar.Value = e.ProgressPercentage;
        }

        private void Completed(object sender, AsyncCompletedEventArgs e)
        {
            MessageBox.Show("다운로드 완료");
            var DocFolder = Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments)+@"\FSBM_Setup.exe";
            System.Diagnostics.Process.Start(DocFolder);
        }

    }
}
