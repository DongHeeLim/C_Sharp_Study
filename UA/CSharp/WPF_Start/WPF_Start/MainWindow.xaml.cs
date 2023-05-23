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

namespace WPF_Start
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //Uri iconUri = new Uri("/UA_ICON.ico", UriKind.RelativeOrAbsolute);
            //this.Icon = BitmapFrame.Create(iconUri);
        }

        private void Click_Exit(object sender, RoutedEventArgs e)
        {
            // "Body", "Title", ButtonType, Options 
            MessageBoxResult messageBox = MessageBox.Show("Do you want to exit?", "Exit", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            if (messageBox == MessageBoxResult.OK) 
            {
                Close();
            }
        }

        private void Click_CenterScreen(object sender, RoutedEventArgs e)
        {
            Window win = new ChildWindow();
            win.WindowStyle = WindowStyle.None;
            win.AllowsTransparency = true;
            win.Owner = this;   // 본인 창
            win.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            win.Topmost = true;
            win.Background = Brushes.Coral;
            win.Show();
        }
    }
}
