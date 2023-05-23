using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Threading;

namespace WPF_RobotArm_2.View.UserControls
{
    /// <summary>
    /// Interaction logic for ControlPanel.xaml
    /// </summary>
    /// 


    public partial class ControlPanel : UserControl
    {
        public enum EJoint
        {
            J1,
            J2,
            J3,
            J4,
            J5,
            J6

        }

        bool j1_status = false;
        bool j2_status = false;
        bool j3_status = false;
        bool j4_status = false;
        bool j5_status = false;

        public ControlPanel()
        {
            InitializeComponent();

            Color color = Color.FromArgb(255, 0, 0, 0);
            SolidColorBrush brush = new SolidColorBrush(color);

            lbl_j1.BorderBrush = brush;
            lbl_j2.BorderBrush = brush;
            lbl_j3.BorderBrush = brush;
            lbl_j4.BorderBrush = brush;
            lbl_j5.BorderBrush = brush;
            lbl_j6.BorderBrush = brush;
        }


        private void btn_J_All_Click(object sender, RoutedEventArgs e)
        {
            if (btn_J_All.IsChecked == true)
            {
                btn_J1.IsChecked = true; btn_J2.IsChecked = true;
                btn_J3.IsChecked = true; btn_J4.IsChecked = true;
                btn_J5.IsChecked = true;

                set_joint_status(true);
                enable_slider(true);
            }
            else if (btn_J_All.IsChecked == false)
            {

                btn_J1.IsChecked = false; btn_J2.IsChecked = false;
                btn_J3.IsChecked = false; btn_J4.IsChecked = false;
                btn_J5.IsChecked = false;

                set_joint_status(false);
                enable_slider(false);
            }
        }

        private void set_joint_status(bool _status)
        {
            j1_status = _status;
            j2_status = _status;
            j3_status = _status;
            j4_status = _status;
            j5_status = _status;      
        }

        private bool get_joint_status() 
        {
            return j1_status | j2_status | j3_status | j4_status | j5_status;
        }

        private void enable_slider(bool _status) 
        {
            slider_j1.IsEnabled = _status;
            slider_j2.IsEnabled = _status;
            slider_j3.IsEnabled = _status;
            slider_j4.IsEnabled = _status;
            slider_j5.IsEnabled = _status;
        }

        private void btn_J1_Click(object sender, RoutedEventArgs e)
        {

            if (j1_status)
            {
                slider_j1.IsEnabled = false;
                j1_status = false;
            }
            else
            {
                slider_j1.IsEnabled = true;
                j1_status = true;
            }
        }
        private void btn_J2_Click(object sender, RoutedEventArgs e)
        {
            if (j2_status)
            {
                slider_j2.IsEnabled = false;
                j2_status = false;
            }
            else
            {
                slider_j2.IsEnabled = true;
                j2_status = true;
            }
        }
        private void btn_J3_Click(object sender, RoutedEventArgs e)
        {
            if (j3_status)
            {
                slider_j3.IsEnabled = false;
                j3_status = false;
            }
            else
            {
                slider_j3.IsEnabled = true;
                j3_status = true;
            }
        }
        private void btn_J4_Click(object sender, RoutedEventArgs e)
        {
            if (j4_status)
            {
                slider_j4.IsEnabled = false;
                j4_status = false;
            }
            else
            {
                slider_j4.IsEnabled = true;
                j4_status = true;
            }
        }
        private void btn_J5_Click(object sender, RoutedEventArgs e)
        {
            if (j5_status)
            {
                slider_j5.IsEnabled = false;
                j5_status = false;
            }
            else
            {
                slider_j5.IsEnabled = true;
                j5_status = true;
            }
        }

        private void btn_JointExecutor_Click(object sender, RoutedEventArgs e)
        {
            if (get_joint_status())
            {
                ((MainWindow)Application.Current.MainWindow).cmd.Text +=
                    string.Format("Move Joint => [J1 : {0}] | [J2 : {1}] | [J3 : {2}] | [J4 : {3}] | [J5 : {4}] | [J6 : {5}] |\n",
                    slider_j1.Value, slider_j2.Value, slider_j3.Value, slider_j4.Value, slider_j5.Value, slider_j6.Value);
            }
            else
            {
                ((MainWindow)Application.Current.MainWindow).cmd.Text += string.Format("Rotate EndEffector => [J6 : {0}]\n", slider_j6.Value);
            }

        }


        private void rpbtn_Rotate_Click(object sender, RoutedEventArgs e)
        {

            Point point = Mouse.GetPosition(this);

            double control_width = this.rpbtn_Rotate.ActualWidth;
            double control_height = this.rpbtn_Rotate.ActualHeight;


            //((MainWindow)Application.Current.MainWindow).cmd.Text += string.Format("Width : {0} | Height : {1} | X : {2} | Y : {3}]\n", control_width, control_height, point.X, point.Y);

            if (point.X > (control_width/2) )
            {
                if (slider_j6.Value != slider_j6.Maximum) 
                {
                    slider_j6.Value++;
                    ((MainWindow)Application.Current.MainWindow).cmd.Text += string.Format("Rotate EndEffector => [J6 : {0}]\n", slider_j6.Value);
                }
                
            }
            else 
            {
                if (slider_j6.Value != slider_j6.Minimum) 
                {
                    slider_j6.Value--;
                    ((MainWindow)Application.Current.MainWindow).cmd.Text += string.Format("Rotate EndEffector => [J6 : {0}]\n", slider_j6.Value);
                }

            }
            
        }

        double temp_position_x = 0;
        double temp_position_y = 0;
        double temp_position_z = 0;
        private void rpbtn_Click(object sender, RoutedEventArgs e)
        {
            // 로봇 좌표 얻어오기

            // x:Name 가져오기
            RepeatButton? repeatButton = e.Source as RepeatButton;


            //((MainWindow)Application.Current.MainWindow).cmd.Text += string.Format("UP : {0}]\n", temp_position);
            ((MainWindow)Application.Current.MainWindow).cmd.Text += string.Format("Target : {0}]\n", repeatButton?.Name);
            switch (repeatButton?.Name) {
                case "rpbtn_up":
                    temp_position_y++;
                    break;
                case "rpbtn_down":
                    temp_position_y--;
                    break;
                case "rpbtn_right":
                    temp_position_x++;
                    break;
                case "rpbtn_left":
                    temp_position_x--;
                    break;
                case "rpbtn_zup":
                    temp_position_z++;
                    break;
                case "rpbtn_zdown":
                    temp_position_z--;
                    break;
                case "rpbtn_stop":
                    break;
                default:
                    // stop
                    break;

            }
            ((MainWindow)Application.Current.MainWindow).cmd.Text += string.Format("[{0} {1} {2}]\n", temp_position_x, temp_position_y, temp_position_z);
        }


    }
}
