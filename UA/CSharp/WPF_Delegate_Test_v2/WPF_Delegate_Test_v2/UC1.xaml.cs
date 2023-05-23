using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace WPF_Delegate_Test_v2
{
    /// <summary>
    /// Interaction logic for UC1.xaml
    /// </summary>
    public partial class UC1 : UserControl//, INotifyPropertyChanged
    {
        
        public UC1()
        {
            InitializeComponent();
        }


        // 대상 프로퍼티
        private static DependencyProperty NAMEProperty =
                                           DependencyProperty.Register("TEXT_NAME", typeof(string), typeof(UC1),
                                           new FrameworkPropertyMetadata(string.Empty,
                                               FrameworkPropertyMetadataOptions.BindsTwoWayByDefault | FrameworkPropertyMetadataOptions.Inherits));

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //this.UC1_txt.Text = "Hello";
            ((MainWindow)Application.Current.MainWindow).txt_Main.Text = "hi";

        }



        // 예제에는 있는데 왜 없어도 되는지 잘 모름, UC1 내부에서 바꿀 필요가 있을 때 사용하는 것 같음
        //public string TEXT_NAME
        //{
        //    get { return (string)GetValue(NAMEProperty); }
        //    set
        //    {
        //        SetValue(NAMEProperty, value);
        //    }
        //}


        //public event PropertyChangedEventHandler? PropertyChanged;
        //private void OnPropertyChanged(string p)
        //{
        //    if (PropertyChanged != null)
        //    {
        //        PropertyChanged(this, new PropertyChangedEventArgs(p));
        //    }
        //}



    }
}
