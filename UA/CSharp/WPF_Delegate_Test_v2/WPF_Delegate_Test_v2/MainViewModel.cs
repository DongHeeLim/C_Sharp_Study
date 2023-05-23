using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace WPF_Delegate_Test_v2
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        //[DllImport("user32.dll")]
        //static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, int dwExtraInfo);
        //private const uint MOUSEEVENT_LEFTDOWN = 0x0002;
        //private const uint MOUSEEVENT_LEFTUP = 0x0004;


        private string _name = string.Empty;

        //
        public string TEXT_NAME
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged("TEXT_NAME");
            }
        }


        //PropertyChaneged 이벤트 선언 및 이벤트 핸들러
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
