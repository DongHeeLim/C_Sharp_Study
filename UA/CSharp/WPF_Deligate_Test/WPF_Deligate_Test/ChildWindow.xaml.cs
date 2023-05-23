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
using System.Windows.Shapes;

namespace WPF_Deligate_Test
{
    /// <summary>
    /// ChildWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ChildWindow : Window
    {
        //private Interface? frm = null;

        MainWindow mainWindow = new MainWindow();

        public ChildWindow()
        {

            InitializeComponent();

            //this.frm = frm;
            
            
            mainWindow.myEvent += MainWindow_myEvent;
            mainWindow.DataSendEvent += new DataGetEventHandler(this.DataGet);
            
        }

        private void DataGet(string Data)
        { 
            childTxt.Text = Data;
        }

        private void MainWindow_myEvent(object sender, EventArgs e)
        {
            childTxt.Text = "Got Event\n";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //frm.setData("Child Data");
        }
    }
}
