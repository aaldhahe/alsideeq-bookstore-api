using MySqlConnector;
using System;
using alsideeq_bookstore_api.Entity;

namespace alsideeq_bookstore_api.Controllers
{
    internal class BaseContract
    {
        public MySqlConnection DataSource 
        { 
            get
            {
                return DBConnection.GetMySqlConnection();
            }
        
        }

        public Guid ContentGuid
        {
            get
            {
                return Guid.NewGuid();
            }
        } 
    }
}