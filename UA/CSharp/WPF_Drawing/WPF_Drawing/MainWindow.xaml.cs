using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
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

namespace WPF_Drawing
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly string currentPath = Directory.GetCurrentDirectory();
        private readonly string projectNamePath = Directory.GetParent(System.Environment.CurrentDirectory).Parent.FullName;
        private readonly string fileName = "pngegg.bmp";



        public MainWindow()
        {
            InitializeComponent();

            string targetPath = System.IO.Path.Combine(projectNamePath, fileName);

            DrawRect(targetPath);
            CompositeImage(targetPath);
        }

        private void DrawRect(string _target) 
        {
            //Bitmap MyBitmap = new Bitmap("D://DownLoad//pngegg.bmp");


            txtBlk.Text = _target;


            //txtBlk.Text += Directory.GetCurrentDirectory();
            //txtBlk.Text += System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);


            Bitmap MyBitmap = new Bitmap(_target);

            RenderTargetBitmap rtb = new RenderTargetBitmap(MyBitmap.Width, MyBitmap.Height, 96d, 96d, PixelFormats.Pbgra32);
            DrawingVisual dv = new DrawingVisual();

          

            using (DrawingContext dc = dv.RenderOpen()) 
            {
                dc.DrawRoundedRectangle(System.Windows.Media.Brushes.Transparent, 
                                        new System.Windows.Media.Pen(System.Windows.Media.Brushes.Red, 30),     // thickness
                                        new Rect(MyBitmap.Width/4, MyBitmap.Height / 4, 500, 500), 5, 5);
                dc.Close();
                rtb.Render(dv);
                if(rtb.IsFrozen)
                    rtb.Freeze();
            }

            source_Image.Source = rtb;

            Display_Image.Source = BitmapToBitmapImage(MyBitmap);
            //Display_Image.Source = BitmapToBitmapImage(B);
        }

        private ImageSource BitmapToBitmapImage(Bitmap bitmap)
        {

            using (MemoryStream ms = new MemoryStream()) 
            {
                bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);

                ms.Position = 0;

                var bi = new BitmapImage();

                bi.BeginInit();
                
                bi.StreamSource = ms;
                bi.CacheOption = BitmapCacheOption.OnLoad;

                bi.EndInit();


                return bi;
            }

        }

        private void CompositeImage(string _target) 
        {
            Bitmap bitmap = new Bitmap(_target);

            Bitmap tempBitmap = new Bitmap(bitmap.Width, bitmap.Height);

            System.Drawing.Pen BlueVioletPen = new System.Drawing.Pen(System.Drawing.Brushes.BlueViolet, 50);

            using (Graphics g = Graphics.FromImage(tempBitmap)) 
            {
                // 이미지 그리기
                g.DrawImage(bitmap, 0, 0, bitmap.Width, bitmap.Height);

                g.DrawRectangle(BlueVioletPen, new System.Drawing.Rectangle(bitmap.Width /2, bitmap.Height/2, 300, 300));
            }

            Display_Image2.Source = BitmapToBitmapImage(tempBitmap);

            BlueVioletPen.Dispose();
            bitmap.Dispose();
        }
    }
}
