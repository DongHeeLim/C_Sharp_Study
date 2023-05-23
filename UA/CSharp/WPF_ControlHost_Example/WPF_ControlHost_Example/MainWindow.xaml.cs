using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPF_ControlHost_Example;


namespace WPF_ControlHost_Example
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {

        int selectedItem;
        IntPtr hwndListBox;
        ControlHost listControl;
        System.Windows.Application app;
        System.Windows.Window myWindow;
        int itemCount;


        public MainWindow()
        {
            InitializeComponent();
        }


        private IntPtr ControlMsgFilter(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            int textLength;

            handled = false;
            if (msg == WM_COMMAND)
            {
                switch ((uint)wParam.ToInt32() >> 16 & 0xFFFF) //extract the HIWORD
                {
                    case LBN_SELCHANGE: //Get the item text and display it
                        selectedItem = SendMessage(listControl.hwndListBox, LB_GETCURSEL, IntPtr.Zero, IntPtr.Zero);
                        textLength = SendMessage(listControl.hwndListBox, LB_GETTEXTLEN, IntPtr.Zero, IntPtr.Zero);
                        StringBuilder itemText = new StringBuilder();
                        SendMessage(hwndListBox, LB_GETTEXT, selectedItem, itemText);
                        selectedText.Text = itemText.ToString();
                        handled = true;
                        break;
                }
            }
            return IntPtr.Zero;
        }

        // Win32 제어시 필요
        internal const int
          LBN_SELCHANGE = 0x00000001,
          WM_COMMAND = 0x00000111,
          LB_GETCURSEL = 0x00000188,
          LB_GETTEXTLEN = 0x0000018A,
          LB_ADDSTRING = 0x00000180,
          LB_GETTEXT = 0x00000189,
          LB_DELETESTRING = 0x00000182,
          LB_GETCOUNT = 0x0000018B;


        // WPF 시작 시
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            app = System.Windows.Application.Current;
            myWindow = app.MainWindow;
            myWindow.SizeToContent = SizeToContent.WidthAndHeight;
            listControl = new ControlHost(ControlHostElement.ActualHeight, ControlHostElement.ActualWidth);
            ControlHostElement.Child = listControl;


            listControl.MessageHook += new HwndSourceHook(ControlMsgFilter);
            hwndListBox = listControl.hwndListBox;
            for (int i = 0; i < 15; i++) //populate listbox
            {
                string itemText = "Item" + i.ToString();
                SendMessage(hwndListBox, LB_ADDSTRING, IntPtr.Zero, itemText);
            }
            itemCount = SendMessage(hwndListBox, LB_GETCOUNT, IntPtr.Zero, IntPtr.Zero);
            numItems.Text = "" + itemCount.ToString();
        }

        // SendMessage to Control 3가지
        [DllImport("user32.dll", EntryPoint = "SendMessage", CharSet = CharSet.Unicode)]
        internal static extern int SendMessage(IntPtr hwnd,
                                               int msg,
                                               IntPtr wParam,
                                               IntPtr lParam);

        [DllImport("user32.dll", EntryPoint = "SendMessage", CharSet = CharSet.Unicode)]
        internal static extern int SendMessage(IntPtr hwnd,
                                               int msg,
                                               int wParam,
                                               [MarshalAs(UnmanagedType.LPWStr)] StringBuilder lParam);

        [DllImport("user32.dll", EntryPoint = "SendMessage", CharSet = CharSet.Unicode)]
        internal static extern IntPtr SendMessage(IntPtr hwnd,
                                                  int msg,
                                                  IntPtr wParam,
                                                  String lParam);

        // 아이템 추가
        private void AppendText(object sender, EventArgs args)
        {
            if (!string.IsNullOrEmpty(txtAppend.Text))
            {
                SendMessage(hwndListBox, LB_ADDSTRING, IntPtr.Zero, txtAppend.Text);
            }
            itemCount = SendMessage(hwndListBox, LB_GETCOUNT, IntPtr.Zero, IntPtr.Zero);
            numItems.Text = "" + itemCount.ToString();
        }

        // 아이템 삭제
        private void DeleteText(object sender, EventArgs args)
        {
            selectedItem = SendMessage(listControl.hwndListBox, LB_GETCURSEL, IntPtr.Zero, IntPtr.Zero);
            if (selectedItem != -1) //check for selected item
            {
                SendMessage(hwndListBox, LB_DELETESTRING, (IntPtr)selectedItem, IntPtr.Zero);
            }
            itemCount = SendMessage(hwndListBox, LB_GETCOUNT, IntPtr.Zero, IntPtr.Zero);
            numItems.Text = "" + itemCount.ToString();
        }


    }
}
