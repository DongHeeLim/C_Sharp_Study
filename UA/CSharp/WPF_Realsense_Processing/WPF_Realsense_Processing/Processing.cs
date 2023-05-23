using Intel.RealSense;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace WPF_Realsense_Processing
{
    internal class Processing
    {
        private Pipeline pipeline = new Pipeline();
        private Colorizer colorizer = new Colorizer();
        private Align align = new Align(Intel.RealSense.Stream.Color);
        private CustomProcessingBlock block;
        private PipelineProfile pipelineProfile = null;

        System.Windows.Controls.Image imgColor = null;
        System.Windows.Controls.Image imgDepth = null;
        System.Windows.Controls.Image imgYolo = null;

        Action<VideoFrame> updateColor = null;
        Action<VideoFrame> updateDepth = null;
        Action<VideoFrame> updateYolo = null;

 

        static Action<VideoFrame> UpdateImage(System.Windows.Controls.Image img) 
        {
            var wbmp = img.Source as WriteableBitmap;   // 이미지 소스를 Write가능한 비트맵으로

            return new Action<VideoFrame>(frame => 
            {
                var rect = new Int32Rect(0, 0, frame.Width, frame.Height);
                wbmp.WritePixels(rect, frame.Data, frame.Stride * frame.Height, frame.Stride);
            });
        }

        static Action<VideoFrame> UpdateYolo(System.Windows.Controls.Image img)
        {
            var wbmp = img.Source as WriteableBitmap;

            

            return new Action<VideoFrame>(frame =>
            {
                var rect = new Int32Rect(0, 0, frame.Width, frame.Height);
                wbmp.WritePixels(rect, frame.Data, frame.Stride * frame.Height, frame.Stride);
            });
        }

        internal void InitRealsense() 
        {
            Config cfg = new Config();

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
                                    .Where(p => p.Stream == Intel.RealSense.Stream.Depth)
                                    .OrderBy(p => p.Framerate)
                                    .Select(p => p.As<VideoStreamProfile>()).First();

                var colorProfile = colorSensor.StreamProfiles
                                    .Where(p => p.Stream == Intel.RealSense.Stream.Color)
                                    .OrderBy(p => p.Framerate)
                                    .Select(p => p.As<VideoStreamProfile>()).First();

                //cfg.EnableStream(Stream.Depth, depthProfile.Width, depthProfile.Height, depthProfile.Format, depthProfile.Framerate);
                cfg.EnableStream(Intel.RealSense.Stream.Depth, depthProfile.Width, depthProfile.Height, depthProfile.Format, 30);

                //cfg.EnableStream(Stream.Color, colorProfile.Width, colorProfile.Height, colorProfile.Format, colorProfile.Framerate);
                cfg.EnableStream(Intel.RealSense.Stream.Color, colorProfile.Width, colorProfile.Height, colorProfile.Format, 30);
                //cfg.EnableStream(Intel.RealSense.Stream.Color, colorProfile.Width, colorProfile.Height, Format.Bgr8, 30);


            }

            pipelineProfile = pipeline.Start();
        }

        internal void ReadyProcessing(System.Windows.Controls.Image target_color, System.Windows.Controls.Image target_depth)
        {
            imgColor = target_color;
            imgDepth = target_depth;
            //imgYolo = target_color;

            var sensor = pipelineProfile.Device.QuerySensors().First(s => s.Is(Extension.DepthSensor));
            var blocks = sensor.ProcessingBlocks.ToList();

            // Stream 가져오기
            using (var p = pipelineProfile.GetStream(Intel.RealSense.Stream.Color).As<VideoStreamProfile>()) 
            {
                App.Current.Dispatcher.Invoke(() => 
                {
                    imgColor.Source = new WriteableBitmap(p.Width, p.Height, 96d, 96d, PixelFormats.Rgb24, null);
                    imgDepth.Source = new WriteableBitmap(p.Width, p.Height, 96d, 96d, PixelFormats.Rgb24, null);
                    //imgYolo.Source = new WriteableBitmap(p.Width, p.Height, 96d, 96d, PixelFormats.Rgb24, null);
                });




                // 비트맵 이미지 업데이트 하는 곳
                updateColor = App.Current.Dispatcher.Invoke(()=> UpdateImage(imgColor));
                updateDepth = App.Current.Dispatcher.Invoke(()=> UpdateImage(imgDepth));
            }

            block = new CustomProcessingBlock((f, src) => 
            {
                using (var releaser = new FramesReleaser()) 
                {
                    foreach(ProcessingBlock p in blocks)
                        f = p.Process(f).DisposeWith(releaser);

                    f = f.ApplyFilter(align).DisposeWith(releaser);
                    f = f.ApplyFilter(colorizer).DisposeWith(releaser);
                    

                    var frames = f.As<FrameSet>().DisposeWith(releaser);

                    var colorFrame = frames[Intel.RealSense.Stream.Color, Format.Rgb8].DisposeWith(releaser);
                    var colorizedDepth = frames[Intel.RealSense.Stream.Depth, Format.Rgb8].DisposeWith(releaser);
                    

                    var res = src.AllocateCompositeFrame(colorizedDepth, colorFrame).DisposeWith(releaser);


                    src.FrameReady(res);

                    
                }            
            });

        }

   
        public void StartProcessing(CancellationTokenSource target_token) 
        {

            block.Start(f => 
            {
                using (var frames = f.As<FrameSet>()) 
                {
                    var colorFrame = frames.ColorFrame.DisposeWith(frames);
                    var colorizedDepth = frames.First<VideoFrame>(Intel.RealSense.Stream.Depth, Format.Rgb8).DisposeWith(frames);

                    System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(colorFrame.Width, colorFrame.Height, colorFrame.Stride, System.Drawing.Imaging.PixelFormat.Format32bppRgb, colorFrame.Data);


                    

                    //imgYolo.Source = BitmapToImageSource(bmp);

                    

                    App.Current.Dispatcher.Invoke(DispatcherPriority.Render, updateDepth, colorizedDepth);
                    App.Current.Dispatcher.Invoke(DispatcherPriority.Render, updateColor, colorFrame);
                    App.Current.Dispatcher.Invoke(DispatcherPriority.Render, new Action( () => 
                    {
                        //((MainWindow)App.Current.MainWindow).process_img.Source = imgYolo.Source;

                    }));
                    //App.Current.Dispatcher.Invoke(DispatcherPriority.Render, );


                }
            });

            var token = target_token.Token;

            var t = Task.Factory.StartNew(() => 
            {
                while (!token.IsCancellationRequested) 
                {
                    using (var frames = pipeline.WaitForFrames())
                    {
                        block.Process(frames);
                    }
                }
            
            }, token);
        }


        private System.Drawing.Bitmap BitmapFromWriteableBitmap(WriteableBitmap writeBmp) 
        {
            System.Drawing.Bitmap bmp;

            using (MemoryStream outStream = new MemoryStream()) 
            {
                BitmapEncoder encoder = new BmpBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create((BitmapSource)writeBmp));
                encoder.Save(outStream);
                bmp = new System.Drawing.Bitmap(outStream);
            }

            return bmp;
        }


        private byte[] ByteArrayFromWriteableBitmap(WriteableBitmap writeBmp) 
        {
            byte[] byteArray;

            using (MemoryStream outStream = new MemoryStream())
            {

                
                BitmapEncoder encoder = new BmpBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create((BitmapSource)writeBmp));
                encoder.Save(outStream);
                byteArray = outStream.ToArray();
                
            }


            return byteArray;
        
        }

        //private System.Drawing.Bitmap bitmap = null;
        BitmapImage BitmapToImageSource(System.Drawing.Bitmap bitmap)
        {
            BitmapImage bitmapimage = new BitmapImage();

            try
            {
                using (System.IO.MemoryStream memory = new System.IO.MemoryStream())
                {
                    bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
                    memory.Position = 0;

                    bitmapimage.BeginInit();
                    bitmapimage.StreamSource = memory;
                    bitmapimage.CacheOption = BitmapCacheOption.OnLoad;
                    bitmapimage.EndInit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n" + ex.StackTrace);
            }

            return bitmapimage;
        }
    }
}
