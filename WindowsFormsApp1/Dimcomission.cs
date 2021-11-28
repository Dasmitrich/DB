using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Dimcomission
    {
        private int comission_id;
        private int tank_id;
        private DateTime date_of_eval;
        private bool is_accepted;
        private string reason;
        private MySqlDataReader data;
        private List<string> data_o = new List<string>();


        public void getStrings(MySqlConnection connection)
        {
            string sql = "SELECT * from dimcomission";
            // объект для выполнения SQL-запроса
            MySqlCommand command = new MySqlCommand(sql, connection);
            // выполняем запрос и получаем ответ
            this.data = command.ExecuteReader();
            this.data_o.Add(String.Format("{0,30}|{1,10}|{2,30}|{3,30}|{4,30}", "comission_id", "tank_id", "date_of_eval", "is_accepted", "reason"));
        }

        public List<string> editWindowRows()
        {
            while (this.data.Read()) // построчно считываем данные
            {
                this.comission_id = data.GetInt16(0);
                this.tank_id = data.GetInt16(1);
                this.date_of_eval = data.GetDateTime(2);
                this.is_accepted = data.GetBoolean(3);
                this.reason = data.GetString(4);

                data_o.Add(String.Format("{0,30}|{1,10}|{2,30}|{3,30}|{4,30}", comission_id, tank_id, date_of_eval, is_accepted, reason));
            }

            return data_o;
        }
    }
}
