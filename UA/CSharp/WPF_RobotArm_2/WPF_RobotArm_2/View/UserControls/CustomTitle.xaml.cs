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

namespace WPF_RobotArm_2.View.UserControls
{
    /// <summary>
    /// Interaction logic for CustomTitle.xaml
    /// </summary>
    public partial class CustomTitle : UserControl
    {

        public CustomTitle()
        {
            InitializeComponent();
            
        }


        private void Btn_minimize_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).WindowState = WindowState.Minimized;           
        }

        //int cnt = 0;
        private void Btn_maximize_Click(object sender, RoutedEventArgs e)
        {
            //test_txtblk.Text += Window.GetWindow(this).WindowState.ToString();
            //test_txtblk.Text += cnt++;
            if (One_Click()) 
            {
                if (Window.GetWindow(this).WindowState == WindowState.Maximized)
                {
                    btn_maximize.Content = "□";
                    Window.GetWindow(this).WindowState = WindowState.Normal;
                
                }
                else if (Window.GetWindow(this).WindowState == WindowState.Normal)
                {
                    btn_maximize.Content = "▣";
                    Window.GetWindow(this).WindowState = WindowState.Maximized;
                }
            }
        }

        private void Btn_close_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Close();
        }


        // 혹시 몰라서 넣었음
        #region                 // 원클릭 여부 확인
        long Firsttime = 0;   // 첫번째 클릭시간
        private bool One_Click()
        {
            long CurrentTime = DateTime.Now.Ticks;
            if (CurrentTime - Firsttime < 4000000) // 0.4초 ( MS에서는 더블클릭 평균 시간을 0.4초로 보는거 같다.)
            {
                Firsttime = CurrentTime;   // 더블클릭 또는 2회(2회, 3회 4회...)클릭 시 실행되지 않도록 함
                return false;   // 더블클릭 됨
            }
            else
            {
                Firsttime = CurrentTime;   // 1번만 실행되도록 함
                return true;   // 더블클릭 아님
            }
        }
        #endregion

        private void UserControl_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (Window.GetWindow(this).WindowState == WindowState.Maximized)
            {
                btn_maximize.Content = "□";
                Window.GetWindow(this).WindowState = WindowState.Normal;

            }
            else if (Window.GetWindow(this).WindowState == WindowState.Normal)
            {
                btn_maximize.Content = "▣";
                Window.GetWindow(this).WindowState = WindowState.Maximized;
            }
        }
    }




}
