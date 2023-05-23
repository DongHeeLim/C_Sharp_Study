using System;
using System.Collections.Generic;
using System.Data;
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

namespace WPF_DateTime_Gadget
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            Close();
            
        }

        private void Ellipse_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
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
