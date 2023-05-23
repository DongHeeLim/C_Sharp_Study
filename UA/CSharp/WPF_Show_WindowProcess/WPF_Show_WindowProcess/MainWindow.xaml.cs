using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPF_Show_WindowProcess
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        [DllImport("user32.dll")]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool PrintWindow(IntPtr hwnd, IntPtr hDC, uint nFlags);

        [DllImport("user32.dll", SetLastError = true)]
        static extern int GetWindowRgn(IntPtr hWnd, IntPtr hRgn);

        [DllImport("gdi32.dll")]
        static extern IntPtr CreateRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect);


        public MainWindow()
        {
            InitializeComponent();
             
        }




        private Bitmap ProcessCapture(string processName)
        {
            IntPtr hwnd = FindWindow(null, processName);

            System.Drawing.Rectangle rc = System.Drawing.Rectangle.Empty;
            Graphics gfxWin = Graphics.FromHwnd(hwnd);
            rc = System.Drawing.Rectangle.Round(gfxWin.VisibleClipBounds);

            Bitmap bmp = new Bitmap(rc.Width, rc.Height, PixelFormat.Format32bppArgb);

            Graphics gfxBmp = Graphics.FromImage(bmp);
            IntPtr hdcBitmap = gfxBmp.GetHdc();

            bool succeeded = PrintWindow(hwnd, hdcBitmap, 1);
            gfxBmp.ReleaseHdc(hdcBitmap);
            if (!succeeded)
            {
                gfxBmp.FillRectangle(
                    new SolidBrush(Color.Gray),
                    new System.Drawing.Rectangle(System.Drawing.Point.Empty, bmp.Size));
            }

            IntPtr hRgn = CreateRectRgn(0, 0, 0, 0);

            GetWindowRgn(hwnd, hRgn);

            Region region = Region.FromHrgn(hRgn);
            if (!region.IsEmpty(gfxBmp))
            {
                gfxBmp.ExcludeClip(region);
                gfxBmp.Clear(Color.Transparent);
            }
            gfxBmp.Dispose();

            //bmp.Save("C:\\SaveFileTest\\test.bmp");

            return bmp;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Process[] prcs = Process.GetProcesses();
            List<string> prcsList = new List<string>();
            foreach (Process p in prcs)
            {
                if (p.MainWindowTitle.Equals(""))
                {
                    continue;
                }
                //prcsList.Add(p.MainWindowTitle + "|" + p.Id);
                prcsList.Add(p.MainWindowTitle);
            }

            cbxProgram.ItemsSource = prcsList;
        }
        
        private BitmapImage Bitmap2BitmapImage(Bitmap src)
        {
            using (MemoryStream memory = new MemoryStream())
            {
                src.Save(memory, ImageFormat.Bmp);
                memory.Position = 0;
                BitmapImage bitmapimage = new BitmapImage();
                bitmapimage.BeginInit();
                bitmapimage.StreamSource = memory;
                bitmapimage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapimage.EndInit();

                memory.Close();

                return bitmapimage;
            }
        }

        // 캡쳐용
        private void cbxProgram_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            string prcsName = cbxProgram.SelectedItem.ToString();
 
            //imgCapture.Source = Bitmap2BitmapImage(ProcessCapture(prcsName));
            Task.Run(async () => 
            {
                await StreamProgram(prcsName);
            });
        }

        private async Task StreamProgram(string prcsName) 
        {           
            while (true) 
            {
                Dispatcher.Invoke(new Action(() => 
                {
                    imgCapture.Source = Bitmap2BitmapImage(ProcessCapture(prcsName));
                }));

                await Task.Delay(1);
                //// 해당 프로그램 종료 시 while 문 나오게??
                //if (prcsName == null) 
                //{
                //    break;
                //}
            }     
        }



    }
}
