using MySql.Data.MySqlClient;
using System;

namespace Store.DataBase
{
    public class MySQLConnection
    {
        public MySqlConnection connection = new MySqlConnection();

        string server = "localhost";
        string database = "Store";
        string user = "root";
        string password = "erudito";
        string port = "3306";

        public MySqlConnection openConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.ConnectionString = "server=" + server + ";port=" + port + ";database=" + database + ";user=" + user + ";password=" + password + ";";
                connection.Open();
                Console.WriteLine("Connection Opened");
            }
            return connection;
        }

        public MySqlConnection closeConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
                Console.WriteLine("Connection Closed");
            }
            return connection;
        }
    }
}
