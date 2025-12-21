using System.Data.OleDb;
using System.IO;

namespace Shop_Lukashevich.Classes.Common
{
    public class DBConnect
    {
        public static readonly string Path = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "Shop.accdb");

        public static OleDbConnection Connection()
        {
            OleDbConnection oleDbConnection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + Path);
            oleDbConnection.Open();

            return oleDbConnection;
        }

        public static OleDbDataReader Query(string Query, OleDbConnection Connection)
        {
            return new OleDbCommand(Query, Connection).ExecuteReader();
        }

        public static void CloseConnection(OleDbConnection Connection)
        {
            Connection.Close();
        }
    }
}
