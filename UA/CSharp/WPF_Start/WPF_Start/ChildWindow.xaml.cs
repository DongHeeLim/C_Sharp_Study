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

namespace WPF_Start
{
    /// <summary>
    /// Interaction logic for ChildWindow.xaml
    /// </summary>
    public partial class ChildWindow : Window
    {
        public ChildWindow()
        {
            InitializeComponent();
            this.ResizeMode = ResizeMode.CanResizeWithGrip;
            // Alpha -> 투명도 (작을수록 투명해짐), rgb
            btn_exit.Background = new SolidColorBrush(Color.FromArgb(45, 255, 0, 255));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            Close();
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            btn_exit.Background = new SolidColorBrush(Color.FromArgb(150, 255, 0, 0));
            base.OnMouseLeftButtonDown(e);
            this.DragMove();
        }

        protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e)
        {
            btn_exit.Background = new SolidColorBrush(Color.FromArgb(45, 255, 0, 255));
            base.OnMouseLeftButtonUp(e);

        }
    }
}
