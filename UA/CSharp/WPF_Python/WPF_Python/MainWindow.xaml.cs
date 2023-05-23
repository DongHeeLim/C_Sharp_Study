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


using IronPython;
using IronPython.Hosting;
using IronPython.Runtime;
using IronPython.Modules;
using Microsoft.Scripting;
using Microsoft.Scripting.Hosting;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Markup;






//dynamic Video_Convertor = scope.GetVariable("Video");
//dynamic calc = Video_Convertor();

namespace WPF_Python
{
    
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string ret = "";
        ScriptEngine engine = IronPython.Hosting.Python.CreateEngine();

       public static readonly RoutedEvent DragEvent = EventManager.RegisterRoutedEvent("DragWindow",
                                                                                        RoutingStrategy.Direct,
                                                                                        typeof(RoutedEventHandler),
                                                                                        typeof(MainWindow));

        public event RoutedEventHandler DragWindow
        {
            add { AddHandler(DragEvent, value); }
            remove { RemoveHandler(DragEvent, value); }
        }

        public MainWindow()
        {
            InitializeComponent();

            try
            {
                var currentDirectory = Environment.CurrentDirectory;    // net 6.0
                txtBox.Text += currentDirectory + "\n";

                var scope = engine.CreateScope();
                ScriptSource source = engine.CreateScriptSourceFromFile("../../../../DataControl/DataControl.py");
                source.Execute(scope);
                var report = scope.GetVariable("test");
                //ret = Convert.ToString(report);
                string _name = "Dong Hee";
                ret = Convert.ToString(report(_name));

            }
            catch (Exception e) 
            {
                //txtBox.Text = string.Empty;
                txtBox.Text += e.Message + "\n";
                txtBox.Text += "Not working\n";
            }


            



        }

        private void btn_receive_Click(object sender, RoutedEventArgs e)
        {
            //txtBox.Text = string.Empty;
            //txtBox.Text += ret +"\n";
            txtBox.Text += "Button is Clicked\n";
            e.Handled = true;
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //this.DragMove();
        }

        void RaiseDragEvent() 
        {
            RoutedEventArgs newEventArgs = new RoutedEventArgs(MainWindow.DragEvent);
            RaiseEvent(newEventArgs);
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            this.DragMove();
            RaiseEvent(new RoutedEventArgs(MainWindow.MouseLeftButtonDownEvent));
        }

        

        private void Window_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }


        private void Rectangle_Click(object sender, RoutedEventArgs e)
        {
            
            txtBox.Text += "Rectable Click\n";
            
        }

        private void Window_Click(object sender, RoutedEventArgs e)
        {
            
            txtBox.Text += "Window Click\n";
        }
    }
}
