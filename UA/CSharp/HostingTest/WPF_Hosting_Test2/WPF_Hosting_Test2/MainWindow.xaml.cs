using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_Hosting_Test2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        string TargetFolder = "Test2";
        string executorName = "Robot_ARM.exe";
        Process proc = new Process();
        string projectPath = Directory.GetParent(System.Environment.CurrentDirectory).Parent.FullName;


        public MainWindow()
        {
            InitializeComponent();

            UserControl1 userControl1 = new UserControl1();

            //NamedPipeServerStream pipeServer = new NamedPipeServerStream("testpipe", PipeDirection.InOut, 1);
            //pipeServer.WaitForConnection();

            Loaded += (s, e) =>
            {
                string combinePath = System.IO.Path.Combine(projectPath, "..");
                string parentPath = new DirectoryInfo(combinePath).FullName;
                string TargetPath = System.IO.Path.Combine(parentPath, TargetFolder);
                string targetExecutor = System.IO.Path.Combine(TargetPath, executorName);
                proc.StartInfo.FileName = targetExecutor;
                cmd.Text += targetExecutor +"\n";

                //Process p = Process.Start("notepad.exe");
                //Process p = Process.Start(targetExecutor);

                //proc.Start();

                //p.WaitForInputIdle(); // Allow the process to open it's window
                //SetParent(p.MainWindowHandle, new System.Windows.Interop.WindowInteropHelper(this).Handle);
                //var win = view as Window;
                //var winHandle = new WindowInteropHelper(win).Handle;
                //SetParent(process.MainWindowHandle, winHandle);

                
                //SetWindowLong(process.MainWindowHandle, GWL_STYLE, WS_VISIBLE);
                //MoveWindow(process.MainWindowHandle, 0, 0, (int)win.ActualWidth, (int)win.ActualHeight, true);

                //proc.WaitForInputIdle(); // Allow the process to open it's window
                //SetParent(proc.MainWindowHandle, new System.Windows.Interop.WindowInteropHelper(this).Handle);
            };


        }



        //protected override void OnSourceInitialized(EventArgs e)
        //{
        //    base.OnSourceInitialized(e);

        //    Process p = Process.Start("notepad.exe");
        //    p.WaitForInputIdle(); // Allow the process to open it's window
        //    SetParent(p.MainWindowHandle, new System.Windows.Interop.WindowInteropHelper(this).Handle);
        //}






    }
}
