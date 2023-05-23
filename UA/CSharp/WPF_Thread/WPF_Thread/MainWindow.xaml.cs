using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Threading;

namespace WPF_Thread
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        private BackgroundWorker worker = null;

        public MainWindow()
        {
            InitializeComponent();
            InitWorkerThread();
        }

        private void InitWorkerThread()
        { 
            worker = new BackgroundWorker();
            
            worker.WorkerReportsProgress = true;        // 진행률 변경에 따른 ProgressChanged 이벤트 발행 여부 
            worker.WorkerSupportsCancellation = true;   // 작업 취소 가능 여부

            //worker.DoWork += new DoWorkEventHandler(worker_DoWork); // 작업
            //worker.ProgressChanged += new ProgressChangedEventHandler(worker_ProgressChanged);  // UI Progress
            //worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted); // 확인용

            worker.DoWork += worker_DoWork; // 작업
            worker.ProgressChanged += worker_ProgressChanged;  // UI Progress
            worker.RunWorkerCompleted += worker_RunWorkerCompleted; // 확인용
        }


      

        private void worker_DoWork(object sender, DoWorkEventArgs e) 
        {
            int num = 0;
            int sum = 0;
            int pct = 0;

            //  Dipatcher 분석 필요
            Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate { num = int.Parse(txt_number.Text); }));
            

            // 입력한 숫자까지 반복
            for (int idx = 1; idx <= num; idx++) 
            {
                // 작업이 제대로 이루어 졌는지 확인
                if (worker.CancellationPending == true)
                { 
                    e.Cancel = true;
                    return;
                }



                // 짝수
                if (idx % 2 == 0)   
                {
                    sum += idx;
                    if (num % 2 == 0)
                    {
                        pct = (idx++ * 100) / (num);   
                    }
                    else 
                    {
                        pct = (idx++ * 100) / (num - 1);
                    }
                    worker.ReportProgress(pct);  // 몇 개의 짝수까지 계산 되었는지 퍼센트
                    Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate { cmd.Content = pct.ToString(); }));

                    //cmd.Content = pct;    // UI + worker 가 pct 를 사용 -> Dispatcher.Invoke 필요

                    // 합계 추가
                    Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate { listBox.Items.Add(sum); }));

                    Thread.Sleep(100);
                }


            }
            // 총합 
            Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate { txt_result.Text = sum.ToString(); }));

        }
        private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null) 
            {
                MessageBox.Show(e.Error.Message, "Error");
                return;
            }
        }

        private void btn_start_Click(object sender, RoutedEventArgs e)
        {
            listBox.Items.Clear();
            txt_result.Text = "0";
            if (txt_number.Text != string.Empty)
            {
                // 비동기로 실행
                worker.RunWorkerAsync();
            }
            else 
            {
                MessageBox.Show("숫자를 입력하지 않았습니다.");
            }

            
        }

        private void btn_stop_Click(object sender, RoutedEventArgs e)
        {
            // 비동기로 중지
            worker.CancelAsync();
            MessageBox.Show("중지되었습니다!");
            
        }
    }
}
