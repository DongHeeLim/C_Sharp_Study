using Intel.RealSense;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows;
using System.Windows.Threading;
using System.Drawing;
using System.Windows.Media;
using System.ComponentModel;

namespace WPF_Realsense_Test
{
    internal class Camera
    {

        private Pipeline pipeline;
        private Colorizer colorizer;
        public CancellationTokenSource tokenSource = new CancellationTokenSource();

        static Action<VideoFrame> UpdateImage(System.Windows.Controls.Image img)
        {
            var wbmp = img.Source as WriteableBitmap;
            return new Action<VideoFrame>(frame =>
            {
                var rect = new Int32Rect(0, 0, frame.Width, frame.Height);
                wbmp.WritePixels(rect, frame.Data, frame.Stride * frame.Height, frame.Stride);
            });
        }

        private BackgroundWorker worker = null;
        public void initWorkerThread() 
        {
            worker = new BackgroundWorker();

            worker.WorkerSupportsCancellation = true;

            worker.DoWork += Worker_DoWork;
            
        }

        public void startWorkerThread() 
        {
            worker.RunWorkerAsync();
        }

        public void stopWorkerThread() 
        {
            worker.CancelAsync();
        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            StartCamera();
        }

        Action<VideoFrame> updateDepth;
        Action<VideoFrame> updateColor;
        public void StartCamera() 
        {
            try
            {
                

                // The colorizer processing block will be used to visualize the depth frames.
                colorizer = new Colorizer();

                // Create and config the pipeline to strem color and depth frames.
                pipeline = new Pipeline();

                using (var ctx = new Context())
                {
                    var devices = ctx.QueryDevices();
                    var dev = devices[0];

                    Console.WriteLine("\nUsing device 0, an {0}", dev.Info[CameraInfo.Name]);
                    Console.WriteLine("Serial number: {0}", dev.Info[CameraInfo.SerialNumber]);
                    Console.WriteLine("Firmware version: {0}", dev.Info[CameraInfo.FirmwareVersion]);



                    var sensors = dev.QuerySensors();
                    var depthSensor = sensors[0];
                    var colorSensor = sensors[1];

                    var depthProfile = depthSensor.StreamProfiles
                                        .Where(p => p.Stream == Stream.Depth)
                                        .OrderBy(p => p.Framerate)
                                        .Select(p => p.As<VideoStreamProfile>()).First();


                    // ReadOnly
                    var colorProfile = colorSensor.StreamProfiles
                                        .Where(p => p.Stream == Stream.Color)
                                        .OrderBy(p => p.Framerate)
                                        .Select(p => p.As<VideoStreamProfile>()).First();


                    var cfg = new Config();

                    //// 기존 읽어온 것 default
                    //cfg.EnableStream(Stream.Depth, depthProfile.Width, depthProfile.Height, depthProfile.Format, depthProfile.Framerate);
                    //cfg.EnableStream(Stream.Color, colorProfile.Width, colorProfile.Height, colorProfile.Format, colorProfile.Framerate);

                    // 변경한 것
                    cfg.EnableStream(Stream.Depth, 640, 480, Format.Z16, 30);
                    //cfg.EnableStream(Stream.Color, 640, 480, Format.Bgr8, 30);
                    cfg.EnableStream(Stream.Color, 640, 480, Format.Rgb8, 30);

                    App.Current.Dispatcher.Invoke(() =>
                    {
                        ((MainWindow)Application.Current.MainWindow).txtblk.Text = colorProfile.Width + " | " +
                                                                                   colorProfile.Height + "|" +
                                                                                   colorProfile.Framerate + "|" +
                                                                                   depthProfile.Format + "|" +
                                                                                   colorProfile.Format;

                    });

                    var pp = pipeline.Start(cfg);

                    SetupWindow(pp, out updateDepth, out updateColor);
                }

                //
                Task.Factory.StartNew(() =>
                {
                    while (!tokenSource.Token.IsCancellationRequested)
                    {
                        // We wait for the next available FrameSet and using it as a releaser object that would track
                        // all newly allocated .NET frames, and ensure deterministic finalization
                        // at the end of scope. 
                        using (var frames = pipeline.WaitForFrames())
                        {
                            var colorFrame = frames.ColorFrame.DisposeWith(frames);
                            var depthFrame = frames.DepthFrame.DisposeWith(frames);

                            // We colorize the depth frame for visualization purposes
                            var colorizedDepth = colorizer.Process<VideoFrame>(depthFrame).DisposeWith(frames);
                 
                            // Render the frames.
                            App.Current.Dispatcher.Invoke(DispatcherPriority.Render, updateDepth, colorizedDepth);
                            App.Current.Dispatcher.Invoke(DispatcherPriority.Render, updateColor, colorFrame);

                            App.Current.Dispatcher.Invoke(new Action(() =>
                            {
                                String depth_dev_sn = depthFrame.Sensor.Info[CameraInfo.SerialNumber];

                                ((MainWindow)Application.Current.MainWindow).lbl_state.Content = depth_dev_sn + " : " + String.Format("{0,-20:0.00}", 
                                                                                                 depthFrame.Timestamp) + "(" + 
                                                                                                 depthFrame.TimestampDomain.ToString() + ")";
                            }));
                        }
                    }
                }, tokenSource.Token);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                App.Current.Shutdown();
            }
        }


        public void SetupWindow(PipelineProfile pipelineProfile, out Action<VideoFrame> depth, out Action<VideoFrame> color)
        {

            using (var p = pipelineProfile.GetStream(Stream.Depth).As<VideoStreamProfile>())
                App.Current.Dispatcher.Invoke(() =>
                {
                    ((MainWindow)Application.Current.MainWindow).imgDepth.Source = new WriteableBitmap(p.Width, p.Height, 96d, 96d, PixelFormats.Rgb24, null);                   
                });

            depth = App.Current.Dispatcher.Invoke(()=>UpdateImage(((MainWindow)Application.Current.MainWindow).imgDepth));

            using (var p = pipelineProfile.GetStream(Stream.Color).As<VideoStreamProfile>())
                App.Current.Dispatcher.Invoke(()=>((MainWindow)Application.Current.MainWindow).imgColor.Source = new WriteableBitmap(p.Width, p.Height, 200, 200, PixelFormats.Rgb24, null));
            color = App.Current.Dispatcher.Invoke(()=>UpdateImage(((MainWindow)Application.Current.MainWindow).imgColor));
        }



    }
}
