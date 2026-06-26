using MySql.Data.MySqlClient;
using System.Data.SqlClient;

namespace Shop_Lukashevich.Classes.Common
{
    public class DBConnect
    {
        private static readonly string Config = "server=localhost;user=root;database=Shop;password=root;";

        public static MySqlConnection Connection()
        {
            MySqlConnection connection = new MySqlConnection(Config);
            connection.Open();
            return connection;
        }

        public static MySqlDataReader Query(string query, MySqlConnection connection)
        {
            return new MySqlCommand(query, connection).ExecuteReader();
        }

        public static void CloseConnection(MySqlConnection connection)
        {
            connection.Close();
        }
    }
}