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
        public DataTable getTable(string query)
        {
            if (query == null)
                query = "select 'wrong table!'";

            DBlink link = new DBlink();
            MySqlConnection connection = link.open_connection();
            MySqlCommand sCommand = new MySqlCommand(query, connection);

            var reader = sCommand.ExecuteReader();
            DataTable sTable = new DataTable();
            sTable.Load(reader);
            link.close_connection();
            return sTable;
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
