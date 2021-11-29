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
        private List<string> columns = new List<string>();
        private DataTable table;
        private List<string> boxfiller = new List<string> { "Dimcomission", "FctManufacturedtank", "Dimadministration", "Dimfactory",
        "Dimmachinetool", "Dimmonthplan", "Dimtankmodel", "Dimwarehouse", "Dimworkers", "Dimworkspace"};
        public Form1()
        {         
            InitializeComponent();
            comboBox1.Text = "Выберите таблицу";
            comboBox2.Text = "id строки";
            comboBox3.Text = "Поле строки";
            comboBox4.Text = "id строки";
            //textBox3.Text = "Новое начение";
            comboBox1.Items.AddRange(boxfiller.ToArray());
            label1.Text = "Здесь будут отображены\nдополнительные\nрезультаты запросов";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                CommonQuery cq = new CommonQuery();
                this.table = cq.getTable("select * from " + comboBox1.SelectedItem.ToString());
                dataGridView1.DataSource = table;
                dataGridView1.ReadOnly = true;

                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                this.columns.Clear();
                foreach (DataColumn d in table.Columns)
                {
                    Console.WriteLine(d);
                    columns.Add(d.ToString());
                }
                comboBox4.Items.AddRange(columns.ToArray());
            }
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
                table = cq.getTable(textBox1.Text);

                string result = cq.deleteRow("delete from " + comboBox1.SelectedItem.ToString() + " where " + comboBox4.SelectedItem.ToString() + " = " + textBox4.ToString());
                label1.Text = result;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
    }
}
