using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace WPF_Task_CancellationToken
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // 10초 뒤 Cancel
        CancellationTokenSource cts = new CancellationTokenSource(5000);
        private Task myTask;

        // 대기 thread 하나를 해제한 뒤 신호를 받으면 자동으로 재설정되는 로컬 대기 핸들 이벤트
        // https://11cc.tistory.com/12
        static AutoResetEvent _restart = new AutoResetEvent(false); // 초기값 false

        bool flag = false;

        public MainWindow()
        {

            InitializeComponent();

        }

        // Task 내부에서 해당 타이밍의 작업에 대한 재시작


        public void RestartProcessLoop() 
        {
            _restart.Set();
        }

        public async Task ControlLoop(int pollingIntervalSeconds, CancellationToken token, AutoResetEvent restart)
        {
            while (!token.IsCancellationRequested)
            {
                await Task.Run(() =>
                {
                    ProcessLoop(pollingIntervalSeconds, token, restart);
                });
            }
            App.Current.Dispatcher.Invoke(() =>
            {
                cmd.Text += "Task Canceled\n";
            });
        }

        public void ProcessLoop(int pollingIntervalSeconds, CancellationToken token, AutoResetEvent restart) 
        {
            App.Current.Dispatcher.Invoke(() => 
            {
                cmd.Text += "Beginning ProcessLoop()\n";
            });
            

            var previousDateTime = DateTime.MinValue;
            var terminators = new[] {token.WaitHandle, restart };

            while (WaitHandle.WaitAny(terminators, TimeSpan.FromSeconds(pollingIntervalSeconds)) == WaitHandle.WaitTimeout)
            {
                if (CheckForUpdate()) 
                {
                    Update(previousDateTime);
                    previousDateTime = DateTime.Now;
                
                }
            }


            App.Current.Dispatcher.Invoke(() =>
            {
                cmd.Text += "Ending ProcessLoop()\n";
            });
            
        }

        // 작업
        private void Update(DateTime previouseDateTime) 
        { 
            
        }

        private bool CheckForUpdate() 
        {
            App.Current.Dispatcher.Invoke(() =>
            {
                cmd.Text += "Checking for Update\n";
            });

           
            return true;
        }

        private void btn_restart_Click(object sender, RoutedEventArgs e)
        {

            if (flag) 
            {
                flag = false;

                btn_restart.Content = "RESTART";
                cmd.Text += "==Canceled!!==\n";
                cts.Cancel();
            }
            else
            {
                flag = true;
                btn_restart.Content = "STOP";

                cts = new CancellationTokenSource();    // Task 시작 전에 만들어야함
                
                myTask = Task.Run(async () =>
                { 
                    await ControlLoop(1, cts.Token, _restart);
                });


                cmd.Text += myTask.IsCompleted.ToString() + "\n";
                //if (myTask.IsCompleted)
                //{
                    
                //    cts = new CancellationTokenSource();
                //    myTask.Start();
                //    //myTask = Task.Run(async () =>
                //    //{
                //    //    await ControlLoop(1, cts.Token, _restart);
                //    //});
                //}

            }          
        }

        private void btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            cmd.Text += "==Canceled!!==\n";
            flag = false;
            btn_restart.Content = "RESTART";
            cts.Cancel();
        }

     
    }
}
