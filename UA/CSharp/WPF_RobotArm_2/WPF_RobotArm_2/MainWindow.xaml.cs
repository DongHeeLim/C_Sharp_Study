using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
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
using WPF_RobotArm_2.View.UserControls;


namespace WPF_RobotArm_2
{


    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

 
        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr windowHandle, int message, IntPtr wordParameter, IntPtr longParameter);

        [DllImport("user32.dll")]
        private static extern IntPtr GetSystemMenu(IntPtr windowHandle, bool revert);

        [DllImport("user32.dll")]
        private static extern int TrackPopupMenu(IntPtr menuHandle, uint flag, int x, int y, int reserved, IntPtr windowHandle, IntPtr rectangle);


        public MainWindow()
        {
            InitializeComponent();

        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Title
            View.UserControls.CustomTitle customTitle = new View.UserControls.CustomTitle();
            customTitleRoot.Children.Add(customTitle);



            // Top Side Buttons
            View.UserControls.TopButtons topButtons = new View.UserControls.TopButtons();
            TopButtonsRoot.Children.Add(topButtons);

            // Right Side Control Panel
            View.UserControls.ControlPanel controlPanel = new View.UserControls.ControlPanel();
            ControlPanelRoot.Children.Add(controlPanel);


            /* TabPanels */
            // OptiTrack
            View.TabPanels.OptiTrackTab optiTrackTab = new View.TabPanels.OptiTrackTab();
            optiTrack.Content = optiTrackTab;

            // Voice
            View.TabPanels.VoiceTab voiceTab = new View.TabPanels.VoiceTab();
            voice.Content = voiceTab;

            // Vision
            View.TabPanels.VisionTab visionTab = new View.TabPanels.VisionTab();
            vision.Content = visionTab;

            // Drilling
            View.TabPanels.DrillingTab drillingTab = new View.TabPanels.DrillingTab();
            drilling.Content = drillingTab;

            cmd.Text = "Window Loaded\n";


            // 서버 연결되면 작동하는 곳
            topButtons.lbl_robotStatus.Content = "None";
            Color color = new Color();
            if (!true)
            {
                color = Color.FromArgb(255, 100, 255, 10);
            }
            else 
            {
                color = Color.FromArgb(255, 255, 10, 10);
            }
            
            SolidColorBrush brush = new SolidColorBrush(color);
            topButtons.color_serverStatus.Fill = brush;
        }

        private int cnt = 0;


        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            //cmd.Text += e.Key.ToString();
            //cmd.Text += Window.GetWindow(this).WindowState;

            if (e.Key == Key.F11 ) 
            {
                if (Window.GetWindow(this).WindowState == WindowState.Maximized)
                {
                    //customTitleRoot.Visibility = Visibility.Visible;
                    //customTitleRoot.Height = 30; 
                    Window.GetWindow(this).WindowState = WindowState.Normal;
                }
                else if (Window.GetWindow(this).WindowState == WindowState.Normal)
                {
                    //customTitleRoot.Visibility = Visibility.Hidden;
                    //customTitleRoot.Height = 30; // minheight 없어야함 처음부터 0이면 상관 x
                    Window.GetWindow(this).WindowState = WindowState.Maximized;
                }

            }
        }

        private Point Click3times(MouseButtonEventArgs e)
        {
            // 0,0 찍히는 문제 해결해야함
            Point ClickPos = e.GetPosition(this);

            cmd.Text += Window.GetWindow(this).Width + "\n";
            cmd.Text += Window.GetWindow(this).Height + "\n";

            double ClickX = ClickPos.X;
            double ClickY = ClickPos.Y;


            cmd.Text += "(" + ClickX + ", " + ClickY + ")\n";

            cnt++;

            if (cnt >= 3)
            {
            
                cmd.Text = String.Empty;
                cnt = 0;
            }

            return ClickPos;
        }

        private void customTitleRoot_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            cmd.Text += "Right Button\n";

            Point mousePoint = PointToScreen(e.GetPosition(this));

            IntPtr windowHandle = new System.Windows.Interop.WindowInteropHelper(this).Handle;

            IntPtr menuHandle = GetSystemMenu(windowHandle, false);

            int command = TrackPopupMenu(menuHandle, 0x100, (int)mousePoint.X, (int)mousePoint.Y, 0, windowHandle, IntPtr.Zero);

            if (command > 0)
            {
                SendMessage(windowHandle, 0x112, (IntPtr)command, IntPtr.Zero);
            }
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            cmd.Text += "inner Side\n";
        }

        private Boolean AutoScroll = true;
        private void scroll_cmd_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            // User scroll event : set or unset auto-scroll mode
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
            }
        }


    }

}
