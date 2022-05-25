using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Winform_ComboBox_ListBox
{
    public partial class Form1 : Form
    {
        class Charactor
        {
            public string? CharactorName { get; set; }
            public int Star { get; set; }
        }

        public Form1()
        {
            InitializeComponent();

            var dataSourceList = new List<Charactor>()
            {
                new Charactor() {CharactorName = "야란", Star = 5 },
                new Charactor() {CharactorName = "시노부", Star = 4}
            };

            dataGridView1.DataSource = dataSourceList;
            
            comboBox2.DisplayMember = "CharactorName";
            comboBox2.ValueMember = "Star";
            comboBox2.DataSource = dataSourceList;
            comboBox2.SelectedIndexChanged += ComboBox2_SelectedIndexChanged;

            listBox2.DisplayMember = "CharactorName";
            listBox2.ValueMember = "Star";
            listBox2.DataSource = dataSourceList;
            listBox2.SelectedIndexChanged += ListBox2_SelectedIndexChanged;

            var dataSource = new String[] { "엠버", "케이아", "리사" };
            comboBox1.DataSource = dataSource;
            listBox1.DataSource = dataSource;

            comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
            listBox1.SelectedIndexChanged += ListBox1_SelectedIndexChanged;
        }

        private void ListBox2_SelectedIndexChanged(object? sender, EventArgs e)
        {
            label1.Text = listBox2.SelectedIndex + " : " + listBox2.SelectedValue + " : " + ((Charactor)listBox2.SelectedItem).CharactorName;
        }

        private void ComboBox2_SelectedIndexChanged(object? sender, EventArgs e)
        {
            label2.Text = comboBox2.SelectedIndex + " : " + comboBox2.SelectedValue + " : " + ((Charactor)comboBox2.SelectedItem).CharactorName;
        }

        private void ListBox1_SelectedIndexChanged(object? sender, EventArgs e)
        {
            label1.Text = listBox1.SelectedIndex + ": " + listBox1.SelectedItem;
            
        }

        private void ComboBox1_SelectedIndexChanged(object? sender, EventArgs e)
        {
            label2.Text = comboBox1.SelectedIndex + ": " + comboBox1.SelectedItem;
        }
    }
}
