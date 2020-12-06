using System;
using alsideeq_bookstore_api.DTOs;
using System.Collections.Generic;
using alsideeq_bookstore_api.Adapters;
namespace alsideeq_bookstore_api.Controllers
{
    internal class CartContract : BaseContract
    {
        private CartAdapter _adapter;
        private AccountContract _contract;
        internal CartContract(CartAdapter adapter, AccountContract contract)
        {
            _adapter = adapter;
            _contract = contract;
        }

        internal CartContract()
        {
            _adapter = new CartAdapter();
            _contract = new AccountContract();
        }
        internal CartDTO CreateCart(CartDTO cart)
        {
            cart.CartId = ContentGuid.ToString();
            DateTime date = DateTime.UtcNow;
            cart.CartDate = date.ToString("yyyy-MM-dd");
            cart.Quantity = 1;
            string query = BuildCreateCartQuery(cart);
            using (var dataSource = DataSource)
            {
                dataSource.Open();
                var queryResult = QueryDataSource(query, dataSource);
                dataSource.Close();
            }
            return cart;
        }

        private string BuildCreateCartQuery(CartDTO cart)
        {
            return string.Format($@"INSERT INTO Cart (cart_id, customer_id, cart_date, book_id, quantity)
                                    VALUES('{cart.CartId}', '{cart.CustomerId}', '{cart.CartDate}', '{cart.BookId}', {cart.Quantity})");
        }

        internal CartDTO UpdateCart(CartDTO cart)
        {
            string query = BuildUpdateCartQuery(cart);
            using (var dataSource = DataSource)
            {
                dataSource.Open();
                var queryResult = QueryDataSource(query, dataSource);
                dataSource.Close();
            }
            return cart;
        }

        private string BuildUpdateCartQuery(CartDTO cart)
        {
            return string.Format(
                $@"Update Cart 
                    SET quantity = {cart.Quantity}
                    WHERE cart_id = '{cart.CartId}'
                "
            );
        }

        internal CartGetDTO GetCustomerCart(string customerId)
        {
            string query = BuildGetCustomerCartQuery(customerId);
            CartGetDTO customerCart = new CartGetDTO();

            using (var dataSource = DataSource)
            {
                dataSource.Open();
                var queryResult = QueryDataSource(query, dataSource);
                customerCart.Carts = _adapter.ToCartDTOsList(queryResult);
                customerCart.Customer = _contract.GetCustomerById(customerId);
                dataSource.Close();
            }
            return customerCart;
        }

        private string BuildGetCustomerCartQuery(string customerId)
        {
            return string.Format(
                $@"SELECT * FROM Cart
                   WHERE customer_id = '{customerId}'"
            );
        }

        internal void DeleteCart(string cartId)
        {
            string query = string.Format($@"DELETE FROM Cart WHERE cart_id = '{cartId}'");
            using (var dataSource = DataSource)
            {
                dataSource.Open();
                QueryDataSource(query, dataSource);
                dataSource.Close();
            }
        }
    }
}