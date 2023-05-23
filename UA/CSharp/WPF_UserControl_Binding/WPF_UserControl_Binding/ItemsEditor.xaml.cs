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

namespace WPF_UserControl_Binding
{
    /// <summary>
    /// Interaction logic for ItemsEditor.xaml
    /// </summary>
    /// 


    public partial class ItemsEditor : UserControl
    {
        #region Items
        public static readonly DependencyProperty ItemsProperty =
            DependencyProperty.Register(
                "Items",
                typeof(IEnumerable<Item>),
                typeof(ItemsEditor),
                new UIPropertyMetadata(null));
        public IEnumerable<Item> Items
        {
            get { return (IEnumerable<Item>)GetValue(ItemsProperty); }
            set { SetValue(ItemsProperty, value); }
        }
        #endregion
        #region AddItem
        public static readonly DependencyProperty AddItemProperty =
            DependencyProperty.Register(
                "AddItem",
                typeof(ICommand),
                typeof(ItemsEditor),
                new UIPropertyMetadata(null));
        public ICommand AddItem
        {
            get { return (ICommand)GetValue(AddItemProperty); }
            set { SetValue(AddItemProperty, value); }
        }
        #endregion
        #region RemoveItem
        public static readonly DependencyProperty RemoveItemProperty =
            DependencyProperty.Register(
                "RemoveItem",
                typeof(ICommand),
                typeof(ItemsEditor),
                new UIPropertyMetadata(null));
        public ICommand RemoveItem
        {
            get { return (ICommand)GetValue(RemoveItemProperty); }
            set { SetValue(RemoveItemProperty, value); }
        }
        #endregion

        public ItemsEditor()
        {
            InitializeComponent();
        }
    }
}
