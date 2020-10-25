using MySqlConnector;

namespace alsideeq_bookstore_api.Entity
{
    public class DBConnection : IDBConnection
    {
        public static MySqlConnection GetMySqlConnection() 
        {
            return new MySqlConnection(DataSourceConnectionString.GetMySqlConnectionString());
        }
    }
}