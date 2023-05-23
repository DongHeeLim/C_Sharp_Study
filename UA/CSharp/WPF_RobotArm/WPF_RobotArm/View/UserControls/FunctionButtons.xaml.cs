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
    /// Interaction logic for FunctionButtons.xaml
    /// </summary>
    public partial class FunctionButtons : UserControl
    {
        private enum FunctionButtonState {NONE, OPTITRACK };
        private FunctionButtonState buttonState = FunctionButtonState.NONE;

        public FunctionButtons()
        {
            InitializeComponent();
        }

        private void btn_OptiTrack_Click(object sender, RoutedEventArgs e)
        {
            this.buttonState = FunctionButtonState.OPTITRACK;

        }
    }
}
