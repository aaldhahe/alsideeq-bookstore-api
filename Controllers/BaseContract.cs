using MySqlConnector;
using System;
using alsideeq_bookstore_api.Entity;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;


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
            // generate a 128-bit salt using a secure PRNG
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            // derive a 256-bit subkey (use HMACSHA1 with 10,000 iterations)
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));
            Console.WriteLine($"Hashed: {hashed}");
            return hashed;
        }

    }
}