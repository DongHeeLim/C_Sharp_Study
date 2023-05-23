using Intel.RealSense;
using System.Windows.Forms;
using System.Drawing.Imaging;
//using System.Threading;
using System.Timers;

namespace WinForm_RealSense_Test
{
    public partial class Form1 : Form
    {

        Pipeline _pipe = new Pipeline();
        Config _config = new Config();
        
        static int count = 0;
        System.Timers.Timer _timer = new System.Timers.Timer();
        delegate void TimerEventFiredDelegate();
        

        public Form1()    
        {

            _config.EnableStream(Intel.RealSense.Stream.Depth, 640, 480, Format.Z16, 30);
            _config.EnableStream(Intel.RealSense.Stream.Color, 640, 480, Format.Bgr8, 30);
            using (var profile = _pipe.Start(_config))
            
            //_pipe.Start();
            InitializeComponent();

            
            _timer.Interval = 50;
            _timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);
            

        }



        // Server Timer
        private void timer_Elapsed(object? sender, ElapsedEventArgs e)
        {
            BeginInvoke(new TimerEventFiredDelegate(Work));
        }

        private void Work()
        {

            // UI 쪽
            textBox3.Text = count.ToString();
            count++;

            using (var frames = _pipe.WaitForFrames())
            {
                Align align = new Align(Intel.RealSense.Stream.Color).DisposeWith(frames);
                Frame aligned = align.Process(frames).DisposeWith(frames);
                FrameSet alignedframeset = aligned.As<FrameSet>().DisposeWith(frames);
                var colorFrame = alignedframeset.ColorFrame.DisposeWith(alignedframeset);
                var depthFrame = alignedframeset.DepthFrame.DisposeWith(alignedframeset);
                if (colorFrame != null)
                {
                    var color_Img = new Bitmap(colorFrame.Width, colorFrame.Height, colorFrame.Stride, PixelFormat.Format24bppRgb, colorFrame.Data);

                    Console.WriteLine("The camera is pointing at an object " +
                            depthFrame.GetDistance(200, 200) + " meters away\t");

                    Brush aBrush = (Brush)Brushes.Yellow;
                    using (Graphics g = Graphics.FromImage(color_Img))
                    {
                        g.FillRectangle(aBrush, 200, 200, 2, 2);
                    }

                    pictureBox1.Image = color_Img;
                }
            }

            if (count % 5 == 0) 
            {
                using (var frames = _pipe.WaitForFrames())
                using (var depth = frames.DepthFrame)
                {
                    var depth_center = depth.GetDistance(depth.Width / 2, depth.Height / 2);

                    textBox1.Text = depth_center.ToString();
                    if (depth_center < 0.3f)
                    {
                        textBox2.Text = "too close..!";
                    }
                    else 
                    {
                        textBox2.Text = "";
                    }

                }
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {

            button1.BackColor = Color.Green;
            button1.Text = "카메라 시작";
            textBox3.Text = count.ToString();
            _timer.Stop();
        }


        static bool button1_state = false;
        private void button1_Click(object sender, EventArgs e)
        {
            if (button1_state == true) 
            {   
                button1.Text= "재시작";
                button1.BackColor= Color.Green;
                button1_state = false;
                _timer.Stop();
                //_timer.Dispose(); // 타이머 실행이 완료 된 후 소비한 리소스를 해제하는데 사용
                count = 0;
                textBox3.Text = count.ToString();
                if (pictureBox1.Image != null)
                {
                    pictureBox1.Image = null;
                }
            }
            else 
            {
                button1.Text = "정지";
                button1.BackColor = Color.Red;
                button1_state = true;
                _timer.Start();

            }
        }




    }
}