using alsideeq_bookstore_api.DTOs;
using MySqlConnector;
using System.Collections;
using System;
using System.Data;

namespace alsideeq_bookstore_api.Controllers 
{
    internal class AccountContract : BaseContract
    {
        internal CustomerDTO CreateAccount(CustomerDTO customer)
        {   
            Guid addressGuid = this.ContentGuid;
            Guid customerGuid = this.ContentGuid;
            ArrayList queries = new ArrayList();
            
            queries.Add(BuildInsertAddressQuery(addressGuid, customer.Address));
            queries.Add(BuildInsertCustomerQuery(customerGuid, addressGuid, customer));
            
            MySqlDataAdapter[] adapters = new MySqlDataAdapter[queries.Count];
            DataTable[] dataTables = new DataTable[queries.Count];
            
            using (MySqlConnection dataSource = this.DataSource)
            {
                dataSource.Open();
                using (MySqlTransaction trans = dataSource.BeginTransaction())
                {
                    MySqlCommand[] cmd = new MySqlCommand[queries.Count];
                    int index = 0;
                    foreach(string query in queries)
                    {
                        cmd[index] = new MySqlCommand(query, dataSource, trans);
                        cmd[index].ExecuteNonQuery();
                        index++;
                    }

                    trans.Commit();
                }
                
            }
            customer.CustomerId = customerGuid.ToString();
            customer.Address.AddressId = addressGuid.ToString();
            return customer;
        }

        private string BuildInsertAddressQuery(Guid guid, AddressDTO address)
        {
            return string.Format(@"INSERT INTO Address (address_id, address, address_2, city, zip_code, country, state) 
                                    VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}')"
                                    , guid, address.Address, address.Address2, address.City, address.ZipCode, address.Country, address.State);
        }

        private string BuildInsertCustomerQuery(Guid customerGuid, Guid addressGuid, CustomerDTO customer)
        {
            return string.Format(@"INSERT INTO Customer (customer_id, username, firstname, lastname, phone, email, pwd, address_id)
                                    VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}')"
                                    , customerGuid, customer.Username, customer.Firstname, customer.Lastname, customer.Phone, customer.Email, customer.Password, addressGuid);
        }

    }
}