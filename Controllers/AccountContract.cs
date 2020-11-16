using alsideeq_bookstore_api.DTOs;
using alsideeq_bookstore_api.Exceptions;
using alsideeq_bookstore_api.Adapters;
using System.Collections;
using System;
using MySqlConnector;

namespace alsideeq_bookstore_api.Controllers 
{
    internal class AccountContract : BaseContract
    {
        private AccountAdapter _adapter;
        internal AccountContract(AccountAdapter adapter) 
        {
            _adapter = adapter;
        }

        internal AccountContract()
        {
            _adapter = new AccountAdapter();
        }

        internal CustomerDTO CreateAccount(CustomerDTO customer)
        {   
            Guid addressGuid = ContentGuid;
            Guid customerGuid = ContentGuid;
            ArrayList queries = new ArrayList();
            customer.Password = GetHashedPassword(customer.Password);
            queries.Add(BuildInsertAddressQuery(addressGuid, customer.Address));
            queries.Add(BuildInsertCustomerQuery(customerGuid, addressGuid, customer));
            
            using (MySqlConnection dataSource = DataSource)
            {
                dataSource.Open();
                using (MySqlTransaction trans = dataSource.BeginTransaction())
                {
                    foreach(string query in queries)
                    {
                        ExecuteNonQuery(query, dataSource, trans);
                    }

                    trans.Commit();
                }
                dataSource.Close();
                
            }
            customer.CustomerId = customerGuid.ToString();
            customer.Address.AddressId = addressGuid.ToString();
            customer.Password = null;
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

        internal CustomerDTO GetCustomerById(string customerId)
        {
            string query = string.Format(
                                        @"SELECT * 
                                        FROM Customer 
                                        INNER JOIN Address USING(address_id)
                                        WHERE customer_id = '{0}'", customerId);
            var dataSource = DataSource;
            dataSource.Open();
            var queryResult = QueryDataSource(query, dataSource);
            if (!queryResult.Read())
            {
                throw new NotFoundException("Cannot find customer with Id " + customerId);
            }
            var dto = _adapter.ToCustomerDTO(queryResult);
            dataSource.Close();
            return dto;
        }

        internal CustomerDTO GetCustomerByUsername(string username, bool includePassword = false)
        {
            string query = string.Format(
                                        @"SELECT * 
                                        FROM Customer
                                        INNER JOIN Address USING(address_id)
                                        WHERE username = '{0}'", username);
            var dataSource = DataSource;
            dataSource.Open();
            var queryResult = QueryDataSource(query, dataSource);
            if (!queryResult.Read()) 
            {
                throw new NotFoundException("Cannot find customer with username " + username); 
            }
            var dto = _adapter.ToCustomerDTO(queryResult, includePassword);
            dataSource.Close();
            return dto;
        }

        internal bool CheckIfUsernameExist(string username)
        {
            CustomerDTO customer = null;
            try 
            {
                customer = GetCustomerByUsername(username);
            }
            catch(NotFoundException ex)
            {
                return false;
            }
            return customer != null;
        }

    }
}