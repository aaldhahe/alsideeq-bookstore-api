using MySqlConnector;
using System;
using alsideeq_bookstore_api.Entity;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Text;

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

        protected string GetHashedPassword(string password)
        {   
            ASCIIEncoding asci = new ASCIIEncoding();
            var md5 = new MD5CryptoServiceProvider();
            var data = Encoding.ASCII.GetBytes(password);
            var md5data = md5.ComputeHash(data);
            string hashedPassword = asci.GetString(md5data);
            Console.WriteLine($"Hashed: {hashedPassword}");
            return hashedPassword;
        }

        protected void ExecuteNonQuery(string query, MySqlConnection conn, MySqlTransaction trans)
        {
            MySqlCommand cmd = new MySqlCommand(query, conn, trans);
            cmd.ExecuteNonQuery();
        }

    }
}