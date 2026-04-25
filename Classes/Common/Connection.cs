using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportGeneration_Shashin.Classes.Common
{
    public class Connection
    {
        public static string congig = "server=127.0.0.1;port=3307uid=root;pwd=;database=journal";
        public static MySqlConnection OpenConnection()
        {
            MySqlConnection connection = new MySqlConnection(congig);
            connection.Open();
            return connection;
        }
        public static MySqlDataReader Query(string SQL, MySqlConnection connection)
        {
            return new MySqlCommand(SQL, connection).ExecuteReader();
        }
        public static void CloseConnection(MySqlConnection connection)
        {
            connection.Close();
            MySqlConnection.ClearPool(connection);
        }
    }
}
