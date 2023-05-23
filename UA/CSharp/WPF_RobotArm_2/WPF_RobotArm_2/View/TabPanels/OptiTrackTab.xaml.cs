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

namespace WPF_RobotArm_2.View.TabPanels
{
    /// <summary>
    /// Interaction logic for OptiTrackTab.xaml
    /// </summary>
    public partial class OptiTrackTab : UserControl
    {
        public OptiTrackTab()
        {
            InitializeComponent();
        }

        private void btn_start_Click(object sender, RoutedEventArgs e)
        {
            if (btn_start.IsChecked == true)
            {
                ((MainWindow)Application.Current.MainWindow).cmd.Text += "OptiTrack Start\n";
            }
            else 
            {
                ((MainWindow)Application.Current.MainWindow).cmd.Text += "OptiTrack Ended\n";
            }
        }
    }
}
