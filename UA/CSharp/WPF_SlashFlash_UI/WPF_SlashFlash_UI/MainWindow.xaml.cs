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
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WPF_SlashFlash_UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Animation animation = new Animation();

        public MainWindow()
        {
            InitializeComponent();
            LoadCanvas();
            CompositionTarget.Rendering += CompositionTarget_Rendering;

            DoubleAnimation_Start();
            //LogoUpDownAnimation_Start();

            animation.LogoUpDownAnimation_Start();

            //Task.Run(() =>
            //{
            //    while (true)
            //    {
            //        App.Current.Dispatcher.Invoke(() =>
            //        {
            //            //cmd.Text += "X : " + XPos + "\n";
            //            //cmd.Text += "Cnt : " + scroll_cnt + "\n";
            //        });

            //    }
            //});
        }

        Canvas LoadingCanvas = new Canvas();
        Ellipse MyEllipse = new Ellipse();
        Rectangle MyRectangle = new Rectangle();    

        private void LoadCanvas() 
        {


            //this.Background = new SolidColorBrush(Colors.Yellow);
            MyRectangle.Width = 50;
            MyRectangle.Height = 10;
            MyRectangle.Fill = new SolidColorBrush(Colors.Black);

            canvas_load.Children.Add(MyRectangle);

            MyEllipse.Width = 30;
            MyEllipse.Height = 30;
            MyEllipse.Fill = new SolidColorBrush(Colors.Black);

            canvas_load2.Children.Add(MyEllipse);


        }


        double speed = 0;
        double XPos = 0;
        bool GoBack = true;
        private void CompositionTarget_Rendering(object sender, EventArgs e)
        {
            speed = 5;
            // Go or Back 에 따른 속도
            if (GoBack)
            {
                //speed += 0.1;
                
                

                XPos += speed;

            }
            else
            {
                //speed -= 0.1;
                
                XPos -= speed;

            }

            double leftOffset = 50;
            double rightOffset = 50;
            // 위치에 따른 Go or Back
            if (XPos <= leftOffset)  // 현재 위치가 음수로 넘어가면 0으로 이동
            {
                GoBack = !GoBack;
                XPos = leftOffset;
                lbl_status.Content = string.Format("WindowSize : {0} RectagleSize : {1}  LastPosition : {2}", this.Width.ToString(), MyRectangle.Width.ToString(), XPos); 
            }
            if (this.Width - MyRectangle.Width - rightOffset <= XPos) // (윈도우 폭 - 직사각형 길이)=> 직사각형의 오른쪽 끝점 위치 < 현재위치
            {
                GoBack = !GoBack;   // 반대로 보내기
                XPos = this.Width - MyRectangle.Width - rightOffset;   // 현재 위치는  끝점
                lbl_status.Content = string.Format("WindowSize : {0} RectagleSize : {1}  LastPosition : {2}", this.Width.ToString(), MyRectangle.Width.ToString(), XPos);
            }

            
            //cmd.Text += "X : " + XPos + "\n";
            Canvas.SetLeft(MyRectangle, XPos);
        }

        private void DoubleAnimation_Start() 
        {
            DoubleAnimation doubleAnimation = new DoubleAnimation();
            doubleAnimation.From = 0.0;
            doubleAnimation.To = this.Width - MyEllipse.Width;

            doubleAnimation.AccelerationRatio = 1.0;                // 가속도 0.0 ~ 1.0
            doubleAnimation.Duration = new Duration(TimeSpan.FromMilliseconds(1000));

            doubleAnimation.FillBehavior = FillBehavior.HoldEnd;    // HoldEnd 현위치, Stop 원위치
            doubleAnimation.AutoReverse = true;                     // 돌아오기
            doubleAnimation.Completed += DoubleAnimation_Completed; // 종료 이벤트
            MyEllipse.BeginAnimation(Canvas.LeftProperty, doubleAnimation);


        
        }


        // 이미지 위 아래로
        private void LogoUpDownAnimation_Start() 
        {
            DoubleAnimation imgUAnimation = new DoubleAnimation();
            imgUAnimation.From = -30;
            imgUAnimation.To = -5;

            imgUAnimation.AccelerationRatio = 1.0;
            imgUAnimation.Duration = new Duration(TimeSpan.FromMilliseconds(1000));
            //imgUAnimation.Completed += LogoAnimation_Completed;

            TranslateTransform transform = new TranslateTransform();
            img_U.RenderTransform = transform;
            transform.BeginAnimation(TranslateTransform.YProperty, imgUAnimation);


            DoubleAnimation imgAAnimation = new DoubleAnimation();
            imgAAnimation.From = 30;
            imgAAnimation.To = 5;

            imgAAnimation.AccelerationRatio = 1.0;
            imgAAnimation.Duration = new Duration(TimeSpan.FromMilliseconds(1000));
            imgAAnimation.Completed += LogoAnimation_Completed;

            TranslateTransform transform2 = new TranslateTransform();
            img_A.RenderTransform = transform2;
            transform2.BeginAnimation(TranslateTransform.YProperty, imgAAnimation);

        }



        CancellationTokenSource logo_cts = null;
        private void LogoAnimation_Completed(object sender, EventArgs e)
        {
            logo_cts = new CancellationTokenSource(5000);
            ImageTranslateAnimation_Start();
            Task.Run(() => ShowText(), logo_cts.Token);
            logTranslateAnimation_Start();
        }

        // 이미지 옆으로
        private void ImageTranslateAnimation_Start() 
        {
            DoubleAnimation imgTranslateAnimation = new DoubleAnimation();
            imgTranslateAnimation.From = 0;
            imgTranslateAnimation.To = -10;
            

            imgTranslateAnimation.AccelerationRatio = 1.0;
            imgTranslateAnimation.Duration = new Duration( TimeSpan.FromMilliseconds(500));
            imgTranslateAnimation.Completed += ImgTranslateAnimation_Completed;

            TranslateTransform translateTransform = new TranslateTransform();
            img_Grid.RenderTransform = translateTransform;
            translateTransform.BeginAnimation(TranslateTransform.XProperty, imgTranslateAnimation);

        }



        private void ImgTranslateAnimation_Completed(object sender, EventArgs e)
        {
            
        }

        private void logTranslateAnimation_Start()
        {
            DoubleAnimation logTranslateAnimation = new DoubleAnimation();
            logTranslateAnimation.From = 0;
            logTranslateAnimation.To = -5;


            logTranslateAnimation.AccelerationRatio = 1.0;
            logTranslateAnimation.Duration = new Duration(TimeSpan.FromMilliseconds(500));
            logTranslateAnimation.Completed += LogTranslateAnimation_Completed;

            TranslateTransform translateTransform = new TranslateTransform();
            lbl_log.RenderTransform = translateTransform;
            translateTransform.BeginAnimation(TranslateTransform.XProperty, logTranslateAnimation);

        }

        private void LogTranslateAnimation_Completed(object sender, EventArgs e)
        {
            // fadeIn fadeOut
            Task.Run(() => FadeOut());       
        }



        private async Task FadeOut() 
        {
            double offset = 0.05;
            for (int i = 0; i < 20; i++)
            {
                Dispatcher.Invoke(() =>
                {
                    vb_log.Opacity -= offset;
                    //cmd.Text = vb_log.Opacity.ToString() + "\n";
                });                
                await Task.Delay(10);
            }

        }

        private async Task ShowText() 
        {
            string _name = "Robotics";
            int _length = _name.Length;
            string temp = string.Empty;


            for (int i = 0; i < _length; i++)
            {
                temp += _name[i];


                Dispatcher.Invoke(() =>
                {
                    lbl_log.FontSize = 60;
                    lbl_log.Content = temp;
                });
               
                await Task.Delay(50);
            }
        }

        private void DoubleAnimation_Completed(object sender, EventArgs e)
        {
            DoubleAnimation_Start();                                // 재시작
            //MyEllipse.Visibility = Visibility.Collapsed;
        }

        private void gif_MediaEnded(object sender, RoutedEventArgs e)
        {
            gif.Position = new TimeSpan(0, 0, 1);   // 1초 지나면 실행
            gif.Play();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            lbl_status.Content = string.Format("WindowSize : {0} RectagleSize : {1}", this.Width.ToString(), MyRectangle.Width.ToString());

            DropShadowEffect shadow = new DropShadowEffect();
            shadow.Opacity = 0.8;
            shadow.Color = Color.FromArgb(255, 0, 250, 50);
            shadow.Direction = 270;
            shadow.BlurRadius = 0.8;
            shadow.ShadowDepth = 0.3;
            lbl_log.Effect = shadow;
            //this.Dispatcher.Invoke((ThreadStart)(() => {  }), DispatcherPriority.ApplicationIdle);
            //Thread.Sleep(3000);
            //this.Dispatcher.Invoke((ThreadStart)(() => { }), DispatcherPriority.ApplicationIdle);
            shadow.Color = Color.FromArgb(255, 255, 0, 50);
            lbl_log.Effect = shadow;
        }

        private bool AutoScroll = true;
        private long scroll_cnt = 0;
        private void ScrollViewer_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            if (e.ExtentHeightChange == 0)
            {   // Content unchanged : user scroll event
                if (scroll_cmd.VerticalOffset == scroll_cmd.ScrollableHeight)
                {   // Scroll bar is in bottom
                    // Set auto-scroll mode
                    AutoScroll = true;
                }
                else
                {   // Scroll bar isn't in bottom
                    // Unset auto-scroll mode
                    AutoScroll = false;
                }
            }

            // Content scroll event : auto-scroll eventually
            if (AutoScroll && e.ExtentHeightChange != 0)
            {   // Content changed and auto-scroll mode set
                // Autoscroll
                scroll_cmd.ScrollToVerticalOffset(scroll_cmd.ExtentHeight);
                //scroll_cnt++;
                //if (scroll_cnt > 50) 
                //{
                //    cmd.Text = "";
                //    scroll_cnt = 0;
                //}
            }
        }
    }
}
