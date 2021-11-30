using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace WindowsFormsApp1
{
    class DBlink
    {
        private readonly string jsonFilePath = "Properties.json";
        private string jsonFile;
        /*private string server = "localhost";
        private string port = "3306";
        private string username = "root";
        private string password = "1234";
        private string database = "tank_fc";*/
        private MySqlConnection connection;
        List<DBsettings> settings;

        public DBlink()
        {
            StreamReader sr = new StreamReader(jsonFilePath);
            jsonFile = sr.ReadToEnd();
            Console.WriteLine(jsonFile);
            settings = JsonConvert.DeserializeObject<List<DBsettings>>(jsonFile);
        }

        public class DBsettings
        {
            public string server { get; set; }
            public string port { get; set; }
            public string username { get; set; }
            public string password { get; set; }
            public string database { get; set; }
        }

        private void getConnection()
        {
            Console.WriteLine(settings.Count);
            connection = new MySqlConnection("server="+settings[0].server+";port="+ settings[0].port + ";username="+ settings[0].username + ";password="+ settings[0].password + ";database="+ settings[0].database);
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
