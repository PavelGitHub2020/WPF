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
using System.Windows.Threading;

namespace WpfApplication3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int counter = 0;

        private DispatcherTimer timerVideoTime;
        public MainWindow()
        {
            InitializeComponent();
            Pause.IsEnabled = false;
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            counter = 0;
            Pause.IsEnabled = true;
            myMedia.Play();
            EnableButtons(true);
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            if (counter % 2 == 0)
                myMedia.Pause();
            else
                myMedia.Play();
            ++counter;
            EnableButtons(false);
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            counter = 0;
            myMedia.Stop();
            Pause.IsEnabled = false;

            EnableButtons(false);
           
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            timerVideoTime = new DispatcherTimer();
            timerVideoTime.Interval = TimeSpan.FromSeconds(0.1);
            timerVideoTime.Tick += new EventHandler(timer_Tick);
            myMedia.Stop();
        }
        
        private void minionPlayer_MediaOpened(object sender,RoutedEventArgs e)
        {
            pr.Minimum = 0;
            pr.Maximum = myMedia.NaturalDuration.TimeSpan.TotalSeconds;

            scrollBar.Minimum = 0;
            scrollBar.Maximum =
            myMedia.NaturalDuration.TimeSpan.TotalSeconds;
            myMedia.Visibility = Visibility.Visible;
        }
        
        private void ShowPosition()
        {
            pr.Value = myMedia.Position.TotalSeconds;
            scrollBar.Value = myMedia.Position.TotalSeconds;
            //textBox.Text = myMedia.Position.TotalSeconds.ToString("0.0");
            
        }

        private void EnableButtons(bool is_playing)
        {
            if (is_playing)
            {
                Play.IsEnabled = false;
                Pause.IsEnabled = true;
                Play.Opacity = 0.5;
                Pause.Opacity = 1.0;
            }
            else
            {
                Play.IsEnabled = true;
                Pause.IsEnabled = false;
                Play.Opacity = 1.0;
                Pause.Opacity = 0.5;
            }
        }
        
        private void timer_Tick(object sender, EventArgs e)
        {
            ShowPosition();
        }

        private void Button_Click3(object sender, RoutedEventArgs e)
        {
            myMedia.SpeedRatio *= 1.5;
        }

        private void Button_Click4(object sender, RoutedEventArgs e)
        {
            myMedia.Position += TimeSpan.FromSeconds(10);
            ShowPosition();
        }

        private void Button_Click5(object sender, RoutedEventArgs e)
        {
            myMedia.Position -= TimeSpan.FromSeconds(10);
            ShowPosition();
        }

        private void Button_Click6(object sender, RoutedEventArgs e)
        {
            myMedia.SpeedRatio /= 1.5;
        }
        private void btnSetPosition_Click(object sender, RoutedEventArgs e)
        {
            TimeSpan timespan =
                TimeSpan.FromSeconds(double.Parse(textBox.Text));
            myMedia.Position = timespan;
            ShowPosition();
        }
        
        private void sbarPosition_PreviewMouseDown(object sender,
         MouseButtonEventArgs e)
        {
            myMedia.Pause();
            EnableButtons(false);
        }

        private void sbarPosition_Scroll(object sender, System.Windows.Controls.Primitives.ScrollEventArgs e)
        {
            myMedia.Position = TimeSpan.FromSeconds(scrollBar.Value);
            ShowPosition();
        }
    }

}
