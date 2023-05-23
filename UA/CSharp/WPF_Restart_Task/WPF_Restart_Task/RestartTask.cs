using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WPF_Restart_Task
{
    internal class RestartTask
    {


        CancellationTokenSource cts = new CancellationTokenSource();
        static AutoResetEvent _restart = new AutoResetEvent(false);
        UserControl1 _userControl1 => ((MainWindow)App.Current.MainWindow).userControl1; 
        bool isWaiting = true;

        public void StartTask()
        {
            cts = new CancellationTokenSource();
            var countTask = Task.Run(async () => 
            {
                // 필요한 Task 추가
                await ControlLoop(300, cts.Token, _restart);
                //ProcessLoop(300, cts.Token, _restart);  // 각 기능마다 Token 다르게 만들기
            });
        }

        public void StopTask() 
        {
            cts.Cancel();
        }

        public void Pause_Resume_CountTask(bool isOn) 
        {
            isWaiting = isOn;
        }

        private async Task ControlLoop(int pollingIntervalMilliSeconds, CancellationToken token, AutoResetEvent restart)
        {
            // 캔슬 될때까지 실행
            while (!token.IsCancellationRequested) 
            {
                await Task.Run(() => 
                {
                    ProcessLoop(pollingIntervalMilliSeconds, token, restart);
                });
            }
        }
        
        private void ProcessLoop(int pollingIntervalMilliSeconds, CancellationToken token, AutoResetEvent restart) 
        {
            var previousDateTime = DateTime.MinValue;
            var terminators = new[] { token.WaitHandle, restart };

            int cnt = 0;

            while (WaitHandle.WaitAny(terminators, TimeSpan.FromMilliseconds(pollingIntervalMilliSeconds)) == WaitHandle.WaitTimeout)
            {
                if (isWaiting)
                {
                    cnt++;
                    App.Current.Dispatcher.Invoke(() =>
                    {
                        ((MainWindow)App.Current.MainWindow).txtblk_Main.Text += cnt.ToString() + "\n";
                        _userControl1.txtblk_u1.Text += "User : " + cnt.ToString() + "\n";
                    });
                    
                    

                    previousDateTime = DateTime.Now;
                }
                
            }
        }
    }
}
