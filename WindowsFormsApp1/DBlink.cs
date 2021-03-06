using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    class DBlink
    {
        private readonly string jsonPropertiesPath = "Properties.json";
        private string jsonFile;
        private MySqlConnection connection;
        List<DBsettings> settings;

        public DBlink()
        {
            StreamReader sr = new StreamReader(jsonPropertiesPath);
            jsonFile = sr.ReadToEnd();
            //Console.WriteLine(jsonFile);
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

        private void setConnection()
        {
            Console.WriteLine(settings[0].server, settings[0].password);
            connection = new MySqlConnection("server="+settings[0].server+";port="+ settings[0].port + ";username="+ settings[0].username + ";password="+ settings[0].password + ";database="+ settings[0].database);
            Console.WriteLine(connection.State);
            //return connection;
        }
        public MySqlConnection open_connection()
        {
            setConnection();
            try
            {
                connection.Open();
                Console.WriteLine("Подключено");
            }
            catch(Exception e)
            {
                //MessageBox.Show(e.Message, "Ошибка!");
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
