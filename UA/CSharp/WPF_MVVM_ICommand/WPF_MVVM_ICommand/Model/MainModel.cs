using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using WPF_MVVM_ICommand.ViewModel;

namespace WPF_MVVM_ICommand.Model
{
    internal class MainModel : ViewModelBase
    {

        private int num = 0;
        // Binding 대상 Num
        public int Num
        {
            get
            {
                return num;
            }
            set 
            {
                num = value;
                OnPropertyChanged("Num");
            }
        }

        // Num2
        private int num2 = 0;
        public int Num2
        {
            get 
            {
                return num2;
            }
            set 
            {
                num2 = value;
                OnPropertyChanged("Num2");
            }
        }

        string name = string.Empty;
        // Name
        public string Name
        {
            get 
            {
                return name;
            }
            set 
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }


    }
}
