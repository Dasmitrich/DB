using MySql.Data.MySqlClient;
using System;
using System.Data;
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
            Console.WriteLine(query);
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
        public string deleteRow(string tableName, string deleteColumn, string deleteKeyValue)
        {
            connection = link.open_connection();
            string result;
            string query = "delete from " + tableName + " where " + deleteColumn + " = " + deleteKeyValue;

            try
               {
                Console.WriteLine(query);
                command = new MySqlCommand(query, connection);
                int rowAffected = command.ExecuteNonQuery();
                result = "Удалено строк: " + rowAffected.ToString();
                
               } 
                catch (Exception e)
               {
                result = "Error";
                messageErr(e);
               }

            link.close_connection();
            return "done";
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
            MessageBox.Show(e.Message, "Ошибка!");
        }
    }
}
