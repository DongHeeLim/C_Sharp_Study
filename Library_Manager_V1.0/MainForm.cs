using Library_Manager_V1._0.Class;
using Library_Manager_V1._0.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Manager_V1._0
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            totalBookslbl_num.Text = DataManager.Books.Count.ToString();
            UserNumberlbl_num.Text = DataManager.Users.Count.ToString();
            checkOutlbl_num.Text = DataManager.Books.Where((x) => x.isBorrowed).Count().ToString();
            overDuelbl.Text = DataManager.Books.Where((x) =>
            {
                return x.isBorrowed && x.BorrowedAt.AddDays(7) < DateTime.Now;
            }).Count().ToString();


            BookStatus bookUsercontrol = new BookStatus();

            
            bookGridView.CurrentCellChanged += BookGridView_CurrentCellChanged;

            
        }

        private void BookGridView_CurrentCellChanged(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
