using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_MVVM_ICommand.ViewModel
{
    internal class MainViewModel : ViewModelBase
    {
        private Model.MainModel model = null;   // 가져올 데이터
        UserControl1 userControl1 = null;

        // 생성자
        public MainViewModel()
        { 
            this.model = new Model.MainModel();
            this.btn_cmd = new Command(btn_Execute_func, CanExecute_func);  // 버튼 기능 추가
            this.btn_set_name = new Command(name_Execute_func, CanExecute_func);
        }

        // 프로퍼티
        public Model.MainModel MainModel 
        {
            get { return this.model; }
            set 
            { 
                this.model = value; 
                OnPropertyChanged("MainModel");
            }
        }


        // Button
        public Command btn_cmd { get; set; }

        // 실행할 함수
        private void btn_Execute_func(object obj) 
        {
            model.Num2 = model.Num * 2;
        }
        // 조건
        private bool CanExecute_func(object obj) 
        {
            return true;
        }



        public Command btn_set_name { get; set; }
        // UserControls Name
        private void name_Execute_func(object obj) 
        {
            model.Name = "lim";
        }



        
    }
}
