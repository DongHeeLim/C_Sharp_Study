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
    /// Interaction logic for VoiceTab.xaml
    /// </summary>
    public partial class VoiceTab : UserControl
    {
        public VoiceTab()
        {
            InitializeComponent();
        }

        private void btn_start_Click(object sender, RoutedEventArgs e)
        {
            if (btn_start.IsChecked == true)
            {
                ((MainWindow)Application.Current.MainWindow).cmd.Text += "Voice Start\n";
            }
            else
            {
                ((MainWindow)Application.Current.MainWindow).cmd.Text += "Voice Ended\n";
            }
        }
    }
}
