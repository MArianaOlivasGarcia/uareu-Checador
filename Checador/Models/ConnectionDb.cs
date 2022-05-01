using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checador.Models
{
    public class ConnectionDb
    {

        private MySqlConnection connection;
        private Boolean isConnected = false;
        public MySqlConnection Connection()
        {
            if (isConnected)
            {
                connection.Close();
                isConnected = false;
            }

            MySqlConnectionStringBuilder db = new MySqlConnectionStringBuilder
            {
                Server = Checador.Properties.Settings.Default.DB_SERVER,
                UserID = Checador.Properties.Settings.Default.DB_USER,
                Password = Checador.Properties.Settings.Default.DB_PASSWORD,
                Database = Checador.Properties.Settings.Default.DB_NAME
            };

            connection = new MySqlConnection(db.ToString());

            try
            {
                connection.Open();
                System.Diagnostics.Debug.WriteLine("Conexión a la DB exitosa.");
                isConnected = true;

            }
            catch (MySqlException error)
            {
                System.Diagnostics.Debug.WriteLine("Conexión a la DB fallida.");
                System.Diagnostics.Debug.WriteLine(error.Message);
                isConnected = false;

            }

            return connection;
        }


        public bool checkConnection(string server, string user, string password, string name)
        {
            MySqlConnectionStringBuilder db = new MySqlConnectionStringBuilder
            {
                Server = server,
                UserID = user,
                Password = password,
                Database = name
            };

            connection = new MySqlConnection(db.ToString());

            try
            {

                connection.Open();
                System.Diagnostics.Debug.WriteLine("Conexión a la DB exitosa.");
                connection.Close();
                return true;

            }
            catch (MySqlException error)
            {
                System.Diagnostics.Debug.WriteLine("Conexión a la DB fallida.");
                System.Diagnostics.Debug.WriteLine(error.Message);
                return false;

            }
        }


    }
}
