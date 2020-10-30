using alsideeq_bookstore_api.DTOs;
using MySqlConnector;
using System;

namespace alsideeq_bookstore_api.Adapters
{
    public class AccountAdapter : BaseAdapter
    {
        public CustomerDTO ToCustomerDTO(MySqlDataReader data, bool includePassword = false)
        {
            CustomerDTO customer = new CustomerDTO();
            AddressDTO address = new AddressDTO();
            AssignModelValueToDomain<string>(s => customer.CustomerId = (string)s, data["customer_id"]);
            AssignModelValueToDomain<string>(s => customer.Username = (string)s, data["username"]);
            AssignModelValueToDomain<string>(s => customer.Firstname = (string)s, data["firstname"]);
            AssignModelValueToDomain<string>(s => customer.Lastname = (string)s, data["lastname"]);
            AssignModelValueToDomain<string>(s => customer.Phone = (string)s, data["phone"]);
            AssignModelValueToDomain<string>(s => customer.Email = (string)s, data["email"]);
            if (includePassword) 
            {
                AssignModelValueToDomain<string>(s => customer.Password = (string)s, data["pwd"]);
            }
            AssignModelValueToDomain<string>(s => address.AddressId = (string)s, data["address_id"]);
            AssignModelValueToDomain<string>(s => address.Address = (string)s, data["address"]);
            AssignModelValueToDomain<string>(s => address.Address2 = (string)s, data["address_2"]);
            AssignModelValueToDomain<string>(s => address.City = (string)s, data["city"]);
            AssignModelValueToDomain<string>(i => address.ZipCode = (string)i, data["zip_code"]);
            AssignModelValueToDomain<string>(s => address.Country = (string)s, data["country"]);
            AssignModelValueToDomain<string>(s => address.State = (string)s, data["state"]);
            customer.Address = address;
            return customer;
        }
    }
}