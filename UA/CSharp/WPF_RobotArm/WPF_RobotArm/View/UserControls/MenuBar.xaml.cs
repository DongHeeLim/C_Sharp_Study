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

namespace WPF_RobotArm.View.UserControls
{
    /// <summary>
    /// Interaction logic for MenuBar.xaml
    /// </summary>
    public partial class MenuBar : UserControl
    {
        public MenuBar(string _style)
        {
            InitializeComponent();



            btn_minimize.Style = Application.Current.Resources[_style] as Style;
            btn_maximize.Style = Application.Current.Resources[_style] as Style;
            btn_close.Style = Application.Current.Resources[_style] as Style;
        }

        private void btn_minimize_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).WindowState = WindowState.Minimized;
        }

        int cnt = 0;
        private void btn_maximize_Click(object sender, RoutedEventArgs e)
        {
            txtb.Text += cnt++;

            if (Window.GetWindow(this).WindowState == WindowState.Maximized) 
            {
                Window.GetWindow(this).WindowState = WindowState.Normal;
            }
            else 
            {
                Window.GetWindow(this).WindowState = WindowState.Maximized;
            }
        }
        

        private void btn_close_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Close();
        }
    }
}
