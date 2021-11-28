using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class DBlink
    {
        MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=1234;database=tank_ft");

        public MySqlConnection open_connection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
                Console.WriteLine("Подключено");
            }
            return connection;
        }
        public void close_connection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
                connection.Close();
        }

        public MySqlConnection GetConnection()
        {
            return connection;
        }
    }
}
