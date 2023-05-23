using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPF_UserControl_Binding
{
    internal class ViewModel : INotifyProperty_Base
    {
        //public ObservableCollection<Item> Items { get; private set; }
        //public ICommand AddItem { get; private set; }
        //public ICommand RemoveItem { get; private set; }
        //public ViewModel()
        //{
        //    Items = new ObservableCollection<Item>();
        //    AddItem = new DelegatedCommand<object>(
        //        o => true, o => Items.Add(new Item()));
        //    RemoveItem = new DelegatedCommand<Item>(
        //        i => true, i => Items.Remove(i));
        //}
    }
}
