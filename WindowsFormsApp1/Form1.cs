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
        private List<string> columns;
        private DataTable table;
        private List<string> boxfiller = new List<string> { "Dimcomission", "FctManufacturedtank", "Dimadministration", "Dimfactory",
        "Dimmachinetool", "Dimmonthplan", "Dimtankmodel", "Dimwarehouse", "Dimworkers", "Dimworkspace"};
        public Form1()
        {         
            InitializeComponent();
            boxfiller.Sort();
            comboBox1.Items.AddRange(boxfiller.ToArray());
            label1.Text = "Здесь будут отображены\nдополнительные\nрезультаты запросов";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                CommonQuery cq = new CommonQuery();
                if(columns != null)
                    this.columns.Clear();
                clear_Boxes();

                this.table = cq.getTable("select * from " + comboBox1.SelectedItem.ToString());
                dataGridView1.DataSource = table;
                dataGridView1.ReadOnly = true;

                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                columns = new List<string>();
                foreach (DataColumn d in table.Columns)
                {
                    columns.Add(d.ToString());
                }
                comboBox4.Items.AddRange(columns.ToArray());
                comboBox3.Items.AddRange(columns.ToArray());
                comboBox2.Items.AddRange(columns.ToArray());
            }
        }

        private void clear_Boxes()
        {
                comboBox4.Items.Clear();
                comboBox3.Items.Clear();
                comboBox2.Items.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBox1.Text))
            {
                CommonQuery cq = new CommonQuery();
                table = cq.getTable(textBox1.Text);
                dataGridView1.DataSource = table;
                dataGridView1.ReadOnly = true;

                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null && comboBox4.SelectedItem != null && textBox4 != null)
            {
                CommonQuery cq = new CommonQuery();
                string tableName = comboBox1.SelectedItem.ToString();
                string keyField = comboBox4.SelectedItem.ToString();
                string keyValue = textBox4.Text;
                string result = cq.deleteRow("delete from " + tableName + " where " + keyField + " = " + keyValue);
                label1.Text = result;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null && comboBox2.SelectedItem != null && comboBox3.SelectedItem != null && textBox3 != null && textBox5 != null)
            {
                CommonQuery cq = new CommonQuery();
                string tableName = comboBox1.SelectedItem.ToString();
                string alterField = comboBox2.SelectedItem.ToString();
                string keyField = comboBox3.SelectedItem.ToString();
                string newField = textBox3.Text;
                string keyValue = textBox5.Text;
                
                string result = cq.updateRow(tableName, alterField, keyField, newField, keyValue);
                label1.Text = result;
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
                comboBox4.Items.Clear();
                comboBox3.Items.Clear();
                comboBox2.Items.Clear();
        }
    }
}
