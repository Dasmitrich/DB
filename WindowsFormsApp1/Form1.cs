using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private List<string> columns;
        private List<string> rows;
        private DataTable table;
        private string[] comboBox = new string[6];//тут хранятся считанные значения 4-х комбобоксов
        Dictionary<string, string> Box5Value = new Dictionary<string, string> {
        {"Нет", "нет"},
        {"Макс. значение", "max"},
        {"Мин. значение", "min"},
        {"Среднее значение", "avg"},
        {"Узнать количество", "count"},
        {"Суммировать", "sum"}
        };//словарь для агрегатных функций
        CommonQuery cq = new CommonQuery();

        string tableName;
        string alterColumn;
        string newField;
        string keyValue;
        string updateKeyColumn;
        string deleteKeyValue;

        public Form1()
        {
            
            InitializeComponent();
            //читаем названия таблиц
            
            table = cq.editTable("show tables");
            rows = new List<string>();

            foreach (DataRow d in table.Rows)
            {
                rows.Add(d.Field<string>(0));
            }

            comboBox1.Items.AddRange(rows.ToArray()); //заполняем комбобокс для таблиц
            comboBox5.Items.AddRange(new List<string>(Box5Value.Keys).ToArray());//зааполняем комбобокс для агрегатных функций на основе ключей словаря
            comboBox[5] = "нет";
            label1.Text = "Здесь будут отображены\nдополнительные\nрезультаты запросов";
        }

        //кнопка "Выбрать табицу"
        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox[1] != null)
            {
                label1.Text = "";
                if (columns != null)
                    columns.Clear();
                if(comboBox[5] == "нет")
                    clear_Boxes();

                //получаем данные из бд
                if (comboBox[5] == "нет")
                {
                    updateForm("select * from " + comboBox[1]);
                }
                else if(comboBox[4] != null && comboBox[1] != null)
                {
                    updateForm("select " + comboBox[5] + "(" + comboBox[4] + ") from " + comboBox[1]);
                } else
                    label1.Text = "Недоcстаточно атрибутов\nзапроса";
                
                //обновляяем столбцы таблицах комбобоксов
                columns = new List<string>();
                foreach (DataColumn d in table.Columns)
                {
                    columns.Add(d.ToString());
                }
                //обновляем связанные комбобоксы  при отсутствии агрегатных функций
                if (comboBox[5] == "нет")
                {
                    comboBox4.Items.AddRange(columns.ToArray());
                    comboBox3.Items.AddRange(columns.ToArray());
                    comboBox2.Items.AddRange(columns.ToArray());
                }
            }
            else
                label1.Text = "Недостаточно атрибутов\nзапроса";
        }

        //кнопка группировки строк
        private void group_button_Click(object sender, EventArgs e)
        {
            if (comboBox[1] != null && comboBox[5] != null && comboBox[5] != "нет" && comboBox[2] != null && comboBox[3] != null )
            {
                label1.Text = "";
                updateForm("select " + comboBox[2] + "," + comboBox[5]+ "("+ comboBox[3] + ") from " + comboBox[1] + " group by " + comboBox[2]);
            } else
                label1.Text = "Недостаточно атрибутов\nзапроса";
        }

        //кнопка свой запрос
        private void button2_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBox1.Text))
            {
                label1.Text = "";
                table = cq.userQuery(textBox1.Text);
                updateForm("select * from " + comboBox[1]);
            }
        }

        //кнопка удаления строк
        private void button4_Click(object sender, EventArgs e)
        {
            if (comboBox[1] != null && comboBox[4] != null && textBox4 != null)
            {
                label1.Text = "";
                tableName = comboBox[1];
                deleteKeyValue = comboBox[4];
                keyValue = textBox4.Text;

                string result = cq.deleteRow(tableName, deleteKeyValue, keyValue);
                label1.Text = result;
                updateForm("select * from " + comboBox[1]);
            }
            else
                label1.Text = "Недостаточно атрибутов\nзапроса";
        }

        //кнопка обновления строк
        private void button5_Click(object sender, EventArgs e)
        {
            alterColumn = comboBox[2];
            updateKeyColumn = comboBox[3];

            if (comboBox1.SelectedItem != null && comboBox[2] != null && comboBox[3] != null && textBox3.TextLength > 0 && textBox5.TextLength > 0)
            {
                label1.Text = "";
                tableName = comboBox1.SelectedItem.ToString();
                newField = textBox3.Text;
                keyValue = textBox5.Text;
                //string query = "update " + tableName + " set " + alterColumn + " = " + "'" + newField + "'" + " where " + updateKeyColumn + " = " + keyValue;
            string result = cq.updateRow(tableName, alterColumn, newField, updateKeyColumn, keyValue);
            label1.Text = result;                
            updateForm("select * from " + comboBox[1]);
            }
            else
                label1.Text = "Недостаточно атрибутов\nзапроса";
            //Console.WriteLine(query);
        }

        //делаем вставку записей
        private void add_data_button_Click(object sender, EventArgs e)
        {
            if (comboBox[1] != null && textBox2.TextLength > 0)
            {
                label1.Text = "";
                //получаем данные из бд
                table = cq.editTable("insert into " + comboBox[1] + " values (" + textBox2.Text + ")");
                updateForm("select * from " + comboBox[1]);
            }
            else
                label1.Text = "Недостаточно атрибутов\nзапроса";
        }

        //обновляем форму
        private void updateForm(string query)
        {
            table = cq.editTable(query);
            dataGridView1.DataSource = table;
            dataGridView1.ReadOnly = true;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        //чистка комбобоксов перед каждым новым селектом
        private void clear_Boxes()
        {
            comboBox4.Items.Clear();
            comboBox3.Items.Clear();
            comboBox2.Items.Clear();
        }


        //комбобоксы
        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox[5] = Box5Value[comboBox5.SelectedItem.ToString()];
        }
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

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
