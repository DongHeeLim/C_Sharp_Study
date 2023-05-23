using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPF_MVVM_ICommand
{
    internal class Command : ICommand
    {
        Action<object> ExecuteMethod = null;
        Func<object, bool> CanexecuteMethod = null;
        private readonly Predicate<object> predicate = null;

        // 생성자
        public Command(Action<object> execute_Method, Func<object, bool> canexecute_Method)
        {
            this.ExecuteMethod = execute_Method;        // 실제로 실행할 함수
            this.CanexecuteMethod = canexecute_Method;  // 실행 전의 조건을 검사하는 메소드, true 반환(bool)
        }   

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return this.CanexecuteMethod == null ? true : this.CanexecuteMethod(parameter);
            //return true;
        }

        public void Execute(object parameter)
        {
            this.ExecuteMethod(parameter);
        }
    }
}
