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
using Intel.RealSense;
using System.Timers;
using System.Threading;
using System.Windows.Threading;

using System.Drawing;
//using System.IO;
using System.Windows.Media.Animation;
using System.ComponentModel;

namespace WPF_Realsense_Test
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    
    public partial class MainWindow : Window
    {
        public delegate void NextPrimeDelegate();
        private long num = 3;
        private bool continueCalculating = false;
      
        Camera camera = new Camera();

        public MainWindow()
        {
            InitializeComponent();
            camera.initWorkerThread();
            camera.startWorkerThread();
            

        }

     
        private void btn_Start_Stop_Click(object sender, RoutedEventArgs e)
        {
            // 토글 방식
            if (continueCalculating)
            {
                continueCalculating = false;
                btn_Start_Stop.Content = "Resume";
            }
            else 
            {
                continueCalculating = true;
                btn_Start_Stop.Content = "Stop";
                // 계산 중일 때
                btn_Start_Stop.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new NextPrimeDelegate(CheckNextNumber));
            }
        }

        private bool NotAPrime = false;
        public void CheckNextNumber()
        {


            NotAPrime = false;

            for (long i = 3; i <= Math.Sqrt(num); i++)
            {
                if (num % i == 0)
                {
                    // Set not a prime flag to true.
                    NotAPrime = true;   // 소수 일때
                    break;
                }
            }

            // If a prime number.   소수
            if (!NotAPrime)
            {
                lbl_state.Content = num.ToString();
            }

            num += 2;   // 2씩 증가
            if (continueCalculating)    // 계산 중
            {
                // 버튼에 대한 행동
                btn_Start_Stop.Dispatcher.BeginInvoke(
                    System.Windows.Threading.DispatcherPriority.SystemIdle,
                    new NextPrimeDelegate(this.CheckNextNumber));
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            camera.tokenSource.Cancel();
        }
    }
}
