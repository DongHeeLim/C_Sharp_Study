using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_Realsense_Processing
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ThreadManager threadManager = new ThreadManager();

        public MainWindow()
        {
            InitializeComponent();

            try 
            {
                
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Application.Current.Shutdown();
            }


        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //threadManager._tokenSource.Cancel();
        }

        private void switch_Click(object sender, RoutedEventArgs e)
        {
            if ((sender as ToggleButton).IsChecked == true)
            {
                threadManager.StartCameraTask(color_img, depth_img);
            }
            else 
            {
                threadManager.StopCameraTask();
            }
        }
    }
}
