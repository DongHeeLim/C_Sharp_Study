using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace WPF_Restart_Task
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        RestartTask restartTask = new RestartTask();
        Timer timer = new Timer();

        public UserControl1 userControl1 = new UserControl1();
        public MainWindow()
        {
            InitializeComponent();

            

            root.Children.Add(userControl1);
            timer.RunTimer();
            
        }

        private void togglebtn_Start_Stop_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)(sender as ToggleButton).IsChecked)
            {

                txtblk_Main.Text += "Start\n";
                togglebtn_Start_Stop.Content = "Stop";
                restartTask.StartTask();
            }
            else 
            {
                txtblk_Main.Text += "Stop\n";
                togglebtn_Start_Stop.Content = "Start";
                restartTask.StopTask();

                // Reset Pause ToggleButton
                togglebtn_Pause_Resume.Content = "Pause";
                togglebtn_Pause_Resume.IsChecked = false;
                restartTask.Pause_Resume_CountTask(true);

                
            }
        }

        private void togglebtn_Pause_Resume_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)(sender as ToggleButton).IsChecked)
            {
                togglebtn_Pause_Resume.Content = "Resume";
                restartTask.Pause_Resume_CountTask(false);
            }
            else
            {
                togglebtn_Pause_Resume.Content = "Pause";
                restartTask.Pause_Resume_CountTask(true);
            }
            
        }
    }
}
