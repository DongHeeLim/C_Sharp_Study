using Library_Manager_V1._0.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Manager_V1._0.Interfaces
{
    public partial class BookStatus : UserControl
    {
        public BookStatus()
        {
            InitializeComponent();

            bookGridView.DataSource = DataManager.Books;

        }

        

    }
}
