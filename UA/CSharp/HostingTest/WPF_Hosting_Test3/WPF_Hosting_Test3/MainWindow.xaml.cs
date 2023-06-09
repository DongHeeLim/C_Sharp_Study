using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
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

using System.Windows.Forms;
using SmileWei.EmbeddedApp;
using System.Diagnostics;   // Process
using System.Runtime.InteropServices;
using System.Windows.Forms.Integration;
using System.Threading;

namespace WPF_Hosting_Test3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
        AppContainer appContainer = null;

        private System.Windows.Forms.Panel _panel;
        private Process _process;
        ProcessStartInfo psi;
        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32")]
        private static extern IntPtr SetParent(IntPtr hWnd, IntPtr hWndParent);

        [DllImport("user32")]
        private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, int uFlags);

        private const int SWP_NOZORDER = 0x0004;
        private const int SWP_NOACTIVATE = 0x0010;
        private const int GWL_STYLE = -16;
        private const int WS_CAPTION = 0x00C00000;
        private const int WS_THICKFRAME = 0x00040000;

        public MainWindow()
        {
            InitializeComponent();
            //appContainer = new AppContainer();
            //this.appContainer.ShowEmbedResult = true;
            openFileDialog.Multiselect = false;
            openFileDialog.Filter = "실행 파일(*.exe)|*.exe";
          
            _panel = new System.Windows.Forms.Panel();
            WinFormHost.Child = _panel;
            
            //WinFormHost.Child= appContainer;


            //DateTimePicker dtp = new DateTimePicker();

        }

        private void btnOpenBrowseApp_Click(object sender, RoutedEventArgs e)
        {
            if (openFileDialog.ShowDialog(this) == true) 
            {
                //string filePath = openFileDialog.FileName;
                //appContainer.AppFilename = openFileDialog.FileName;
                //appContainer.Start();

                txtblk_AppPath.Text += "Start Process\n";
                psi = new ProcessStartInfo(openFileDialog.FileName);
                _process = Process.Start(psi);
                
                Thread.Sleep(1000); // 필수
                Process[] processes = Process.GetProcesses();
                bool isExecuting = false;
                foreach (Process proc in processes) 
                {
                    //txtblk_AppPath.Text += $"{proc.ProcessName}\n";
                    if (proc.ProcessName.Equals("Robot_ARM")) 
                    {
                        txtblk_AppPath.Text += $"{proc.ProcessName}\n";
                        ShowWindow(_process.MainWindowHandle, SW_MINIMIZE);
                        
                        //SetForegroundWindow(procHandler);
                        isExecuting = true;
                        break;
                    }
                }
                txtblk_AppPath.Text += "==DoneWithRobotArm==";


                Thread.Sleep(3000); // 유니티가 완전히 실행될때까지 대기 -> Task.Delay 로 따로 만들기 
                _process.WaitForInputIdle();

                

                SetParent(_process.MainWindowHandle, _panel.Handle);

                // remove control box
                int style = GetWindowLong(_process.MainWindowHandle, GWL_STYLE);
                style = style & ~WS_CAPTION & ~WS_THICKFRAME;
                SetWindowLong(_process.MainWindowHandle, GWL_STYLE, style);

                // resize embedded application & refresh
                ResizeEmbeddedApp();



            }
        }



        //protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        //{
        //    base.OnClosing(e);
        //    if (_process != null)
        //    {
        //        _process.Refresh();
        //        _process.Close();
        //    }
        //}

        private void ResizeEmbeddedApp()
        {
            if (_process == null)
                return;

            SetWindowPos(_process.MainWindowHandle, IntPtr.Zero, 0, 0, (int)_panel.ClientSize.Width, (int)_panel.ClientSize.Height, SWP_NOZORDER | SWP_NOACTIVATE);
        }

        //protected override Size MeasureOverride(Size availableSize)
        //{
        //    Size size = base.MeasureOverride(availableSize);
        //    ResizeEmbeddedApp();
        //    return size;
        //}

        private void WinFormHost_Loaded(object sender, RoutedEventArgs e)
        {
            // 해당 프로그램 없으면 선택창 생성
        }

        private void btn_CloseEXE_Click(object sender, RoutedEventArgs e)
        {
            if (_process != null)
            {
                _process.Refresh();
                _process.Close();
                //_process.Kill();
                //WinFormHost.Dispose();
            }

        }

        [DllImport("user32.dll")]
        public static extern IntPtr FindWindowEx(IntPtr handleParent, IntPtr handleChild, string className, string WindowName);

        [DllImport("User32", EntryPoint = "FindWindow")]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        public static extern void SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        private const int SW_SHOWNORMAL = 1;
        private const int SW_MINIMIZE = 6;


        [DllImport("user32.dll")]
        private static extern IntPtr GetActiveWindow();
    }
}
