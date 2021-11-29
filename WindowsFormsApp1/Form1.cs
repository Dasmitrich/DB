using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        List<string> boxfiller = new List<string> { "Dimcomission", "FctManufacturedtank", "Dimadministration", "Dimfactory",
        "Dimmachinetool", "Dimmonthplan", "Dimtankmodel", "Dimwarehouse", "Dimworkers", "Dimworkspace"};
        public Form1()
        {         
            InitializeComponent();
            comboBox1.Items.AddRange(boxfiller.ToArray());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                CommonQuery cq = new CommonQuery();
                DataTable sTable = cq.getTable("select * from " + comboBox1.SelectedItem.ToString());
                dataGridView1.DataSource = sTable;
                dataGridView1.ReadOnly = true;

                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBox1.Text))
            {
                CommonQuery cq = new CommonQuery();
                DataTable sTable = cq.getTable(textBox1.Text);
                dataGridView1.DataSource = sTable;
                dataGridView1.ReadOnly = true;

                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
