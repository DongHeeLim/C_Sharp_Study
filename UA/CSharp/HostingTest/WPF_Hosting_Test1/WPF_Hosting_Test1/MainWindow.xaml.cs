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

namespace WPF_Hosting_Test1
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        IntPtr hwndListBox;
        ControlHost targetControl;
        System.Windows.Application app;
        System.Windows.Window myWindow;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            app = System.Windows.Application.Current;
            myWindow = app.MainWindow;
            myWindow.SizeToContent = SizeToContent.WidthAndHeight;
            targetControl = new ControlHost(border_Main.ActualHeight, border_Main.ActualWidth);
            border_Main.Child = targetControl;
        }
    }
}
