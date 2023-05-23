using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {

        Process m_AppProcess = null; 


        public UserControl1()
        {
            InitializeComponent();

            AddProcess();

        }

        private void AddProcess() 
        {
            ProcessStartInfo info = new ProcessStartInfo("notepad.exe");
            info.UseShellExecute = true;
            info.WindowStyle = ProcessWindowStyle.Minimized;
            m_AppProcess = System.Diagnostics.Process.Start(info);
            m_AppProcess.WaitForInputIdle();
            //this.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.ApplicationIdle, appIdleEvent, this, null));

            //WindowInteropHelper helper = new WindowInteropHelper(Window.GetWindow(this));

        }
    }
}
