using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MjpegProcessor;

namespace CCTV
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MjpegDecoder _mjpeg;
        public MainWindow()
        {
            InitializeComponent();
            _mjpeg = new MjpegDecoder();
            _mjpeg.FrameReady += mjpeg_FrameReady;
            DisplayCCTV();
        }

        public void DisplayCCTV()
        {
            _mjpeg.ParseStream(new Uri("http://203.130.228.60:3010/mjpg/video.mjpg"), "root", "d3phub");
        }
        private void button1_Click(object sender, RoutedEventArgs e)
        {
           
        }
        private void mjpeg_FrameReady(object sender, FrameReadyEventArgs e)
        {
            image.Source = e.BitmapImage;

        }
    }
}
