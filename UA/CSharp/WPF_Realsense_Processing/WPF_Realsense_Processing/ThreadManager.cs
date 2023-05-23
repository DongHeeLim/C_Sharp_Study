using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Media3D;

namespace WPF_Realsense_Processing
{
    public class ThreadManager
    {
        CancellationTokenSource cts = new CancellationTokenSource();
        //private Task startCameraTask;

        public static CancellationTokenSource _tokenSource = new CancellationTokenSource();
        public static CancellationTokenSource _pauseTokenSource = new CancellationTokenSource();
        private Task cameraTask = null;



        public async Task ControlLoop(Image color_img, Image depth_img, CancellationToken token) 
        {
            Processing processing = new Processing();

            processing.InitRealsense();
            processing.ReadyProcessing(color_img, depth_img);

            if (!token.IsCancellationRequested) 
            {
                await Task.Run(() =>
                {
                    // 구현 함수들                   
                    processing.StartProcessing(cts);    // 캔슬 대상 넣어주기
                });
            }

        }





        // 외부 접근
        public void StartCameraTask(Image color_img, Image depth_img) 
        {
            //cameraTask = Task.Run(() => StartCamera(color_img, depth_img));
            cts = new CancellationTokenSource();
            cameraTask = Task.Run( async () => 
            {
                await ControlLoop(color_img, depth_img, cts.Token);
            });
        }

        public void StopCameraTask() 
        {
            cts.Cancel();
        }


        // 일정시간 동안 
        static int count;
        int PollingInterval = 1;
        public async Task Start()
        {
            var previousDateTime = DateTime.MinValue;
            CancellationTokenSource internalTokenSource = new CancellationTokenSource();
            CancellationToken internalToken = internalTokenSource.Token;
            try
            {
                while (!internalToken.IsCancellationRequested)
                {
                    if (CheckForUpdate())
                    {
                        await UpdateAsync(previousDateTime); // or better await UpdateAsync(previousDateTime);
                    }

                    //
                    await Task.Delay(PollingInterval * 1000, internalToken);
                    Debug.WriteLine("here " + count);
                    if (count > 3)
                    {
                        count = 0;
                        throw new Exception("simulate error");
                    }
                }
                internalToken.ThrowIfCancellationRequested();
            }
            catch (OperationCanceledException oc)
            {
                Debug.WriteLine(oc.Message);
            }
        }

        public async Task UpdateAsync(DateTime previousDateTime)
        {
            
        }

        public static bool CheckForUpdate()
        {
            //Console.WriteLine("Checking for update.");
            return true;
        }

        //public async void StopCameraTask() 
        //{
        //    var isWaiting = true;

        //    while (isWaiting)
        //    {
        //        try
        //        {
        //            //A long delay is key here to prevent the task system from holding the thread.
        //            //The cancellation token allows the work to resume with a notification 
        //            //from the CancellationTokenSource.
        //            await Task.Delay(1000, _tokenSource.Token);
        //            MessageBox.Show(_tokenSource.Token.ToString());
        //        }
        //        catch (TaskCanceledException)
        //        {
        //            //Catch the cancellation and it turns into continuation
        //            isWaiting = false;
        //        }
        //    }
        //}

        // 구현함수
        private void StartCamera(Image color_img, Image depth_img) 
        {
            Processing processing = new Processing();

            processing.InitRealsense();
            processing.ReadyProcessing(color_img, depth_img);
            processing.StartProcessing(_tokenSource);
        }

    }
}
