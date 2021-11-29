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
    class CommonQuery : TableBeh{
        private MySqlCommand command;
        private MySqlConnection connection;
        private DBlink link = new DBlink();

        public DataTable getTable(string query)
        {
            if (query == null)
                query = "select 'wrong table!'";

            connection = link.open_connection();
            command = new MySqlCommand(query, connection);

            var reader = command.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(reader);
            link.close_connection();
            return table;
        }
        public string deleteRow(string query)
        {
            string result;
            try
            {
                connection = link.open_connection();
                command = new MySqlCommand(query, connection);
                int rowAffected = command.ExecuteNonQuery();
                result = "Удалено строк: " + rowAffected.ToString();
            } catch (Exception e)
            {
                result = e.ToString();
            }
            finally
            {
                link.close_connection();
            }
            return result;
        }

        public string updateRow(string query)
        {
            string result;
            try
            {
                connection = link.open_connection();
                command = new MySqlCommand(query);
                int rowAffected = command.ExecuteNonQuery();
                result = "Строка успешно обновлена";
            }
            catch (Exception e)
            {
                result = e.ToString();
            }
            finally
            {
                link.close_connection();
            }
            return result;
        }
    }
    class Dimcomission
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
    }
}
