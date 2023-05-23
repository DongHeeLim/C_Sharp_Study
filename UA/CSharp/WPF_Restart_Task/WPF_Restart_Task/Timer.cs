using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace WPF_Restart_Task
{
    internal class Timer
    {

        UserControl1 _userControl1 => ((MainWindow)App.Current.MainWindow).userControl1;
        DispatcherTimer timer = new DispatcherTimer();

        public void RunTimer() 
        { 
            
            timer.Tick += Timer_Tick;
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Start();
        }

        int cnt = 0;    
        private void Timer_Tick(object sender, EventArgs e)
        {
            _userControl1.Dispatcher.BeginInvoke(new Action(() => 
            {
                _userControl1.txtblk_u1.Text += (cnt++).ToString() + "<= Timer\n";
                if(cnt > 5) 
                {
                    timer.Stop();
                    timer.Interval = TimeSpan.FromMilliseconds(5000);
                    timer.Start();
                }
            }));
        }
    }
}
