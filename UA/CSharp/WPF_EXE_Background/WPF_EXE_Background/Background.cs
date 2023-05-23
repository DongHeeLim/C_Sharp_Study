using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interop;

namespace WPF_EXE_Background
{
   
    public class Background
    {

        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32")]
        private static extern IntPtr SetParent(IntPtr hWnd, IntPtr hWndParent);

        [DllImport("user32")]
        private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, int uFlags);

        private const int GWL_STYLE = -16;
        private const int WS_CAPTION = 0x00C00000;
        private const int WS_THICKFRAME = 0x00040000;
        private const int SWP_NOZORDER = 0x0004;
        private const int SWP_NOACTIVATE = 0x0010;

        // 3개 같음 -> 따로 설정해야하는 것이 있는듯
        string executeFilePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
        string entryPath = System.Reflection.Assembly.GetEntryAssembly().Location;
        string callingPath = System.Reflection.Assembly.GetCallingAssembly().Location;

        
        string folderPath = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
        string projectPath = Directory.GetParent(System.Environment.CurrentDirectory).Parent.FullName;
        string solutionName = System.Reflection.Assembly.GetEntryAssembly().GetName().Name;
        string outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);
        string currentPath = Path.GetDirectoryName(Environment.CurrentDirectory);

        string TargetFolder = "Test2";
        string executorName = "Robot_ARM.exe";

        Process process = null;
        System.Windows.Forms.Panel panel = new System.Windows.Forms.Panel();

        /// <summary>
        /// 프로그램 시작 테스크
        /// </summary>
        public void StartBackground() 
        {

            Task.Run(async () => 
            {               
                await ExecuteBackground();
            });
            
        }


        private async Task ExecuteBackground() 
        {
            string Test2Path = projectPath;
            string relativePath = Path.Combine(@"..\..", solutionName);
            string absolutePath = Path.GetFullPath(relativePath);
            string upperPath = Path.GetDirectoryName(projectPath);
            string combinePath = Path.Combine(projectPath, "..");
            string parentPath = new DirectoryInfo(combinePath).FullName;
            string TargetPath = Path.Combine(parentPath, TargetFolder);

            App.Current.Dispatcher.Invoke(() => 
            {
                ((MainWindow)App.Current.MainWindow).txtbox_Main.Text += "\n" + executeFilePath + "\n";
                ////((MainWindow)App.Current.MainWindow).txtbox_Main.Text += entryPath + "\n";
                ////((MainWindow)App.Current.MainWindow).txtbox_Main.Text += callingPath + "\n";
                ////((MainWindow)App.Current.MainWindow).txtbox_Main.Text += solutionName + "\n";
                ////((MainWindow)App.Current.MainWindow).txtbox_Main.Text += folderPath + "\n";
                ((MainWindow)App.Current.MainWindow).txtbox_Main.Text += projectPath + "\n";
                //((MainWindow)App.Current.MainWindow).txtbox_Main.Text += parentPath + "\n";
                //((MainWindow)App.Current.MainWindow).txtbox_Main.Text += TargetPath + "\n";
        


                //((MainWindow)App.Current.MainWindow).txtbox_Main.Text += currentPath + "\n";
      
                //((MainWindow)App.Current.MainWindow).txtbox_Main.Text += outPutDirectory + "\n";
            });

            Process proc = new Process();


            string AppArguments = "-c -x";
            App.Current.Dispatcher.Invoke( ()=> {
                ((MainWindow)App.Current.MainWindow).WinFormHost.Child = panel;
            });

            

            App.Current.Dispatcher.Invoke(() =>
            {
                ((MainWindow)App.Current.MainWindow).txtbox_Main.Text += TargetPath + "\n";
            });

            if (Directory.Exists(TargetPath))
            {
                string targetExecutor = Path.Combine(TargetPath, executorName);

                //ProcessStartInfo psi = new ProcessStartInfo(targetExecutor);
                proc.StartInfo.FileName = targetExecutor;
                proc.StartInfo.Arguments = AppArguments;
                proc.StartInfo.Arguments = null;

                App.Current.Dispatcher.Invoke(() =>
                {
                    ((MainWindow)App.Current.MainWindow).txtbox_Main.Text += targetExecutor + "\n";
                });

                proc.StartInfo.UseShellExecute = false;
                proc.StartInfo.CreateNoWindow = false;
                proc.StartInfo.RedirectStandardOutput = true;



                proc.Start();
                //proc.WaitForExit();
                proc.WaitForInputIdle();
                System.Threading.Thread.Sleep(1000);
                SetParent(proc.MainWindowHandle, panel.Handle);

                int style = GetWindowLong(proc.MainWindowHandle, GWL_STYLE);
                style = style & ~WS_CAPTION & ~WS_THICKFRAME;
                SetWindowLong(proc.MainWindowHandle, GWL_STYLE, style);

                // resize embedded application & refresh
                ResizeEmbeddedApp();

                App.Current.Dispatcher.Invoke(() =>
                {

                });
                string Result = proc.StandardOutput.ReadToEnd();    // 필요하면 출력하기
            }

            //proc.StartInfo.FileName = Test2Path;

            await Task.Delay(1);
        
        }




        public void ResizeEmbeddedApp()
        {
            if (process == null)
                return;

            SetWindowPos(process.MainWindowHandle, IntPtr.Zero, 0, 0, (int)panel.ClientSize.Width, (int)panel.ClientSize.Height, SWP_NOZORDER | SWP_NOACTIVATE);
        }

    }
}
