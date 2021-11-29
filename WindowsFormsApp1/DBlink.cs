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
        private string server = "localhost";
        private string port = "3306";
        private string username = "root";
        private string password = "1234";
        private string database = "tank_ft";
        MySqlConnection connection;
        private void getConnection()
        {

            this.connection = new MySqlConnection("server="+server+";port="+port+";username="+username+";password="+password+";database="+database);
            //return connection;
        }
        public MySqlConnection open_connection()
        {
            getConnection();
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
            {
                connection.Close();
                Console.WriteLine("Отключено");
            }
        }
    }
}
