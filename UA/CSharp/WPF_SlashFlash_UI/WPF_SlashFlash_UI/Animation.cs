using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Media.Animation;
using System.Windows.Media;
using System.Windows.Threading;
using System.Windows;

namespace WPF_SlashFlash_UI
{
    internal class Animation
    {


        // 이미지 위 아래로
        public void LogoUpDownAnimation_Start()
        {
            DoubleAnimation imgUAnimation = new DoubleAnimation();
            imgUAnimation.From = -30;
            imgUAnimation.To = -5;

            imgUAnimation.AccelerationRatio = 1.0;
            imgUAnimation.Duration = new Duration(TimeSpan.FromMilliseconds(1000));
            //imgUAnimation.Completed += LogoAnimation_Completed;

            TranslateTransform transform = new TranslateTransform();
            ((MainWindow)App.Current.MainWindow).img_U.RenderTransform = transform;
            transform.BeginAnimation(TranslateTransform.YProperty, imgUAnimation);


            DoubleAnimation imgAAnimation = new DoubleAnimation();
            imgAAnimation.From = 30;
            imgAAnimation.To = 5;

            imgAAnimation.AccelerationRatio = 1.0;
            imgAAnimation.Duration = new Duration(TimeSpan.FromMilliseconds(1000));
            imgAAnimation.Completed += LogoAnimation_Completed;

            TranslateTransform transform2 = new TranslateTransform();
            ((MainWindow)App.Current.MainWindow).img_A.RenderTransform = transform2;
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
            imgTranslateAnimation.Duration = new Duration(TimeSpan.FromMilliseconds(500));
            imgTranslateAnimation.Completed += ImgTranslateAnimation_Completed;

            TranslateTransform translateTransform = new TranslateTransform();
            ((MainWindow)App.Current.MainWindow).img_Grid.RenderTransform = translateTransform;
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
            ((MainWindow)App.Current.MainWindow).lbl_log.RenderTransform = translateTransform;
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
                App.Current.Dispatcher.Invoke(() =>
                {
                    ((MainWindow)App.Current.MainWindow).vb_log.Opacity -= offset;
                    //cmd.Text = vb_log.Opacity.ToString() + "\n";
                });
                await Task.Delay(10);
            }


            // 가장 마지막 부분이라서 Visibility 같은 거 조절하면됨
            App.Current.Dispatcher.Invoke(() =>
            {
                // 사용 X 참고용
                //((MainWindow)App.Current.MainWindow).splash.Visibility = Visibility.Collapsed;
            });
        }

        private async Task ShowText()
        {
            string _name = "Robotics";
            int _length = _name.Length;
            string temp = string.Empty;


            for (int i = 0; i < _length; i++)
            {
                temp += _name[i];

                await Task.Delay(1000);
                App.Current.Dispatcher.Invoke(() =>
                {
                    ((MainWindow)App.Current.MainWindow).lbl_log.FontSize = 60;
                    ((MainWindow)App.Current.MainWindow).lbl_log.Content = temp;
                });

                await Task.Delay(50);
            }
        }
    }
}
