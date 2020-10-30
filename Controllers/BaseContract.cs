using MySqlConnector;
using System;
using alsideeq_bookstore_api.Entity;

namespace alsideeq_bookstore_api.Controllers
{
    internal class BaseContract
    {
        internal MySqlConnection DataSource 
        { 
            get
            {
                return DBConnection.GetMySqlConnection();
            }
        
        }

        internal Guid ContentGuid
        {
            get
            {
                return Guid.NewGuid();
            }
        }
        
        internal MySqlDataReader QueryDataSource(string query, MySqlConnection conn)
        {
            MySqlCommand cmd = new MySqlCommand(query, conn);
            var result = cmd.ExecuteReader();
            return result;
        }

    }
}