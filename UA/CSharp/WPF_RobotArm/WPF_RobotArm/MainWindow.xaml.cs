using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Diagnostics;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Runtime.InteropServices;


namespace WPF_RobotArm
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

            this.WindowStyle = WindowStyle.None;
            this.AllowsTransparency = true;
            //this.Owner = this;   // 본인 창
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.ResizeMode = ResizeMode.CanResizeWithGrip;
            //this.Topmost = true;
            
            View.UserControls.MenuBar menubar = new View.UserControls.MenuBar("MenuBarLight");
            MenuBarRoot.Children.Add( menubar );

            View.UserControls.TopButtons topButtons = new View.UserControls.TopButtons();
            TopButtonsRoot.Children.Add( topButtons );
            
            View.UserControls.FunctionButtons functionButtons = new View.UserControls.FunctionButtons();
            FunctionButtonsRoot.Children.Add( functionButtons );

            View.UserControls.Status status = new View.UserControls.Status();
            StatusRoot.Children.Add( status );

            View.UserControls.EndEffectorControl endEffectorControl = new View.UserControls.EndEffectorControl();
            EndEffectorControlRoot.Children.Add( endEffectorControl );

            View.UserControls.JointControl jointControl = new View.UserControls.JointControl();
            JointControlRoot.Children.Add( jointControl );


        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Right)
            {
                Point mousePoint = PointToScreen(e.GetPosition(this));

                IntPtr windowHandle = new System.Windows.Interop.WindowInteropHelper(this).Handle;

                IntPtr menuHandle = GetSystemMenu(windowHandle, false);

                int command = TrackPopupMenu(menuHandle, 0x100, (int)mousePoint.X, (int)mousePoint.Y, 0, windowHandle, IntPtr.Zero);

                if (command > 0)
                {
                    SendMessage(windowHandle, 0x112, (IntPtr)command, IntPtr.Zero);
                }
            }
            else if(e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
        }
    }
}
