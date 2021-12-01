using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private readonly string tablesPath = "Tables.txt";
        private List<string> columns;
        private DataTable table;
        private string[] comboBox = new string[5];
        private string[] boxFiller;

        string tableName;
        string alterColumn;
        string newField;
        string keyValue;
        string updateKeyColumn;
        string deleteKeyValue;

        public Form1()
        {
            InitializeComponent();
            StreamReader sr = new StreamReader(tablesPath);
            string rtables = sr.ReadToEnd();
            boxFiller = rtables.Split(',');

            comboBox1.Items.AddRange(boxFiller);
            label1.Text = "Здесь будут отображены\nдополнительные\nрезультаты запросов";
        }

        //кнопка "Выбрать табицу"
        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox[1] != null)
            {
                if(columns != null)
                    columns.Clear();
                clear_Boxes();

                //получаем данные из бд
                CommonQuery cq = new CommonQuery();
                table = cq.editTable("select * from " + comboBox[1]);
                dataGridView1.DataSource = table;
                dataGridView1.ReadOnly = true;

                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                //добавляем столбцы таблицы в комбобоксы
                columns = new List<string>();
                foreach (DataColumn d in table.Columns)
                {
                    columns.Add(d.ToString());
                }
                //обновляем связанные комбобоксы
                comboBox4.Items.AddRange(columns.ToArray());
                comboBox3.Items.AddRange(columns.ToArray());
                comboBox2.Items.AddRange(columns.ToArray());
            }
        }

        //кнопка свой запрос
        private void button2_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBox1.Text))
            {
                CommonQuery cq = new CommonQuery();
                table = cq.userQuery(textBox1.Text);

                dataGridView1.DataSource = table;
                dataGridView1.ReadOnly = true;

                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
        }

        //кнопка удаления строк
        private void button4_Click(object sender, EventArgs e)
        {
            if (comboBox[1] != null && comboBox[4] != null && textBox4 != null)
            {
                CommonQuery cq = new CommonQuery();
                string tableName = comboBox[1];
                deleteKeyValue = comboBox[4];
                string keyValue = textBox4.Text;

                string result = cq.deleteRow("delete from " + tableName + " where " + deleteKeyValue + " = " + keyValue);
                label1.Text = result;
            }
        }

        //кнопка обновления строк
        private void button5_Click(object sender, EventArgs e)
        {
            alterColumn = comboBox[2];
            updateKeyColumn = comboBox[3];

            if (comboBox1.SelectedItem != null && comboBox[2] != null && comboBox[3] != null && textBox3.TextLength > 0 && textBox5.TextLength > 0)
            {
                tableName = comboBox1.SelectedItem.ToString();
                newField = textBox3.Text;
                keyValue = textBox5.Text;
                //string query = "update " + tableName + " set " + alterColumn + " = " + "'" + newField + "'" + " where " + updateKeyColumn + " = " + keyValue;
            string result = new CommonQuery().updateRow(tableName, alterColumn, newField, updateKeyColumn, keyValue);
            label1.Text = result;
            }
            //Console.WriteLine(query);
        }

        //дулаем вставку записей
        private void add_data_button_Click(object sender, EventArgs e)
        {
            if (comboBox[1] != null && textBox2 != null)
            {
                //получаем данные из бд
                CommonQuery cq = new CommonQuery();
                table = cq.editTable("insert into " + comboBox[1] + " values (" + textBox2.Text + ")");
                dataGridView1.DataSource = table;
                dataGridView1.ReadOnly = true;

                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
        }

        //чистка комбобоксов перед каждым новым селектом
        private void clear_Boxes()
        {
            comboBox4.Items.Clear();
            comboBox3.Items.Clear();
            comboBox2.Items.Clear();
        }

        //комбобоксы
        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox[4] = comboBox4.SelectedItem.ToString();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox[3] = comboBox3.SelectedItem.ToString();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox[2] = comboBox2.SelectedItem.ToString();
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox[1] = comboBox1.SelectedItem.ToString();
        }
    }
}
