using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace WPF_ToggleSample
{
    public class Main_ViewModel : BaseViewModel
    {
        public static Main_ViewModel W = new Main_ViewModel();

        public ICommand togglecamera_Command { get; set; }
        public ICommand toggleTestFunc_Command { get; set; }

        public Main_ViewModel()
        {
            W = this;



            // get set 포함
            togglecamera_Command = new RelayCommand<System.Windows.Controls.Primitives.ToggleButton>(CanExecute_func, ToggleCamera_func);

            toggleTestFunc_Command = new RelayCommand<System.Windows.Controls.Primitives.ToggleButton>(ToggleButton => { return true; }, ToggleButton =>
            {
                //MessageBox.Show($"ToggleButton.IsChecked={ToggleButton.IsChecked}");
                if (ToggleButton.IsChecked == true)
                {
                    MessageBox.Show($"ToggleButtonTest.IsChecked=True");
                }
                else
                {
                    MessageBox.Show($"ToggleButtonTest.IsChecked=False");
                }
            });
        }


        private void ToggleCamera_func(object obj) 
        {
            if (((ToggleButton)obj).IsChecked == true)
            {
                MessageBox.Show($"ToggleButton.IsChecked=True");
            }
            else
            {
                MessageBox.Show($"ToggleButton.IsChecked=False");
            }
        }

        private bool CanExecute_func(object obj)
        {
            return true;
        }
    }
}
