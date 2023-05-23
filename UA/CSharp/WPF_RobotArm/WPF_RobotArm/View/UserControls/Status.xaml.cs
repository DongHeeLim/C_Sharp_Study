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

namespace WPF_RobotArm.View.UserControls
{
    /// <summary>
    /// Interaction logic for Status.xaml
    /// </summary>
    public partial class Status : UserControl
    {
        public Status()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            SetDateTime();  // 현재 시간 불러옴

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);   // 동작 방식 1초 마다 실행
            timer.Tick += Timer_Tick;   // 이벤트 추가 1초 간격 CNT 증가
            timer.Start();
        }

        private void SetDateTime()
        {
            tb_date.Text = DateTime.Now.ToShortDateString();
            tb_time.Text = DateTime.Now.ToLongTimeString();
        }

        // Initialize DateTime
        private void Timer_Tick(object? sender, EventArgs e)
        {
            SetDateTime();
        }
    }
}
