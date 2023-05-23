using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for DrillingTab.xaml
    /// </summary>
    public partial class DrillingTab : UserControl
    {
        public DrillingTab()
        {
            InitializeComponent();
            drill_length_Input.Text = "0.0";    // 전 작업 기억해놓기 
        }

        private string result = string.Empty;
        int input_length = 0;
        bool float_flag = false;
        int last_input_length = 0;
        private void drill_length_Input_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

            // 한 문자씩 들어옴

            // 정수
            Regex regex_int = new Regex("[^0-9]+");
            Regex regex_dot = new Regex("[^.]+");

            Regex regex_float;
            // 실수
            if (input_length < 4)
            {
                if (!float_flag)
                {
                    regex_float = new Regex(@"[^0-9.]");
                    
                }
                else
                {
                    regex_float = new Regex(@"[^0-9]");
                }

                e.Handled = regex_float.IsMatch(e.Text);
            }
            else
            {
                regex_float = new Regex(@"[0-9.]");
                e.Handled = regex_float.IsMatch(e.Text);
            }

        }

        private void drill_length_Input_TextChanged(object sender, TextChangedEventArgs e)
        {
            //string pattern = @"\d\.?(\d{1}?){1}"; // \.? 0 또는  10진수 
            //Regex regex_float = new Regex(pattern);

            input_length = drill_length_Input.Text.Length;
            
            if (input_length > 0)
            {
                if (input_length == 2 && (last_input_length < input_length) && !drill_length_Input.Text.Contains("."))
                {
                    drill_length_Input.Text = drill_length_Input.Text + ".";
                    drill_length_Input.Select(input_length, 0);
                }


                if (drill_length_Input.Text.Contains(".") && (double.Parse(drill_length_Input.Text) < 35.0))
                {
                    float_flag = true;

                    
                    if (input_length < 5)
                    {
                        if (drill_length_Input.Text.Substring(input_length - 1) == ".")
                        {
                            current_drill_length.Content = drill_length_Input.Text + "0";

                        }
                        else
                        {
                            current_drill_length.Content = drill_length_Input.Text;
                        }
                    }

                }
                else if ((double.Parse(drill_length_Input.Text) >= 35.0))
                {
                    ((MainWindow)Application.Current.MainWindow).cmd.Text += "입력할 수 없는 값입니다.\n";
                }
                else
                {
                    float_flag = false;
                    
                }
            }

            last_input_length = input_length;

            //if (input_length > 0) 
            //{
            //    temp = drill_length_Input.Text.Substring(input_length-1);
            //    ((MainWindow)Application.Current.MainWindow).cmd.Text += temp + "\n";
            //}
            //((MainWindow)Application.Current.MainWindow).cmd.Text += string.Format("Float : {0}\n", float_flag);
            ((MainWindow)Application.Current.MainWindow).cmd.Text += input_length + "\n";
        }
    }
}
