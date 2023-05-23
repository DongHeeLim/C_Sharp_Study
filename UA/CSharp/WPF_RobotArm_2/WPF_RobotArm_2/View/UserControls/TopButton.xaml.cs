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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_RobotArm_2.View.UserControls
{
    /// <summary>
    /// Interaction logic for TopButtons.xaml
    /// </summary>
    public partial class TopButtons : UserControl
    {
        public TopButtons()
        {
            InitializeComponent();

 
            
        }

        private void init_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).cmd.Text += "Move to init\n";
        }

        private void home_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).cmd.Text += "Move to home\n";
        }

        private void shutdown_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).cmd.Text += "Shutdown\n";
        }

        private void recovery_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).cmd.Text += "Recovery Clicked\n";
        }

        private void unlock_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).cmd.Text += "Unlock Emergency\n";
        }


        private void Camera_toggle_btn_Click(object sender, RoutedEventArgs e)
        {
            if (Camera_toggle_btn.IsChecked == true)
            {
                ((MainWindow)Application.Current.MainWindow).cmd.Text += "Camera On\n";
                ((MainWindow)Application.Current.MainWindow).Front_Canvas.Visibility = Visibility.Visible;
                ((MainWindow)Application.Current.MainWindow).Front_Canvas.IsEnabled = true;
            }
            else 
            {
                ((MainWindow)Application.Current.MainWindow).cmd.Text += "Camera Off\n";
                ((MainWindow)Application.Current.MainWindow).Front_Canvas.Visibility = Visibility.Hidden;
                ((MainWindow)Application.Current.MainWindow).Front_Canvas.IsEnabled = false;
            }
        }

        private void Teaching_toggle_btn_Click(object sender, RoutedEventArgs e)
        {
            if (Teaching_toggle_btn.IsChecked == true)
            {
                ((MainWindow)Application.Current.MainWindow).cmd.Text += "Teaching Mode On\n";
            }
            else
            {
                ((MainWindow)Application.Current.MainWindow).cmd.Text += "Teaching Mode Off\n";
            }
        }
    }
}
