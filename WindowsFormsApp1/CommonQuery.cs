using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    class CommonQuery : ItableBeh{
        static int m = 0;
        private MySqlCommand command;
        private MySqlConnection connection;
        private DBlink link = new DBlink();        

        //метод получения строк таблицы
        public DataTable editTable(string query)
        {
            if (query == null)
                query = "select 'wrong table!'";

            DataTable table = new DataTable();
            connection = link.open_connection();

            try
            {
                command = new MySqlCommand(query, connection);
                var reader = command.ExecuteReader();
                table.Load(reader);
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e);
                messageErr(e);
            }

            link.close_connection();
            return table;
        }

        //пользовательский запрос
        public DataTable userQuery(string query)
        {
            if (query == null)
                query = "select 'wrong table!'";

            DataTable table = new DataTable();
            connection = link.open_connection();

            try
            {
                command = new MySqlCommand(query, connection);
                var reader = command.ExecuteReader();
                table.Load(reader);
            }
            catch (Exception e)
            {
                messageErr(e);
            }

            link.close_connection();
            return table;
        }

        //метод удаления строки
        public string deleteRow(string query)
        {
            connection = link.open_connection();
            string result;

               try
               {
                command = new MySqlCommand(query, connection);
                int rowAffected = command.ExecuteNonQuery();
                result = "Удалено строк: " + rowAffected.ToString();
               } catch (Exception e)
               {
                result = "Error";
                messageErr(e);
            }

            link.close_connection();
            return result;
        }

        //метод обновления строки
        public string updateRow(string tableName, string alterColumn, string newField, string updateKeyColumn, string keyValue)
        {
            connection = link.open_connection();
            string result;
            string query = "update " + tableName + " set " + alterColumn + " = " + "'" + newField + "'"+ " where " + updateKeyColumn + " = " + "'" + keyValue + "'";

            try
            {
                Console.WriteLine(query);
                command = new MySqlCommand(query, connection);

                int rowAffected = command.ExecuteNonQuery();
                result = "Строка успешно обновлена "+ ++m;
            }
            catch (Exception e)
            {
                result = "Error";
                messageErr(e);
            }

            link.close_connection();
            Console.WriteLine(result);
            return result;
        }

        private void messageErr(Exception e)
        {
            MessageBox.Show(e.ToString(), "Ошибка!");
        }
    }
    /*class Dimcomission
    {
        private int comission_id { get; set; }
        private int tank_id { get; set; }
        private DateTime date_of_eval { get; set; }
        private bool is_accepted { get; set; }
        private string reason { get; set; }
        private MySqlDataReader data { get; set; }
        private List<string> data_o = new List<string>();
        MySqlConnection connection;

        public Dimcomission(){}
        public Dimcomission(int comission_id, int tank_id, DateTime date_of_eval, bool is_accepted, string reason)
        {
            this.comission_id = comission_id;
            this.tank_id = tank_id;
            this.date_of_eval = date_of_eval;
            this.is_accepted = is_accepted;
            this.reason = reason;
        }
    }*/
}
