using System;
using alsideeq_bookstore_api.DTOs;

namespace alsideeq_bookstore_api.Controllers
{
    internal class CartContract : BaseContract
    {
        internal CartDTO CreateCart(CartDTO cart)
        {
            cart.CartId = ContentGuid.ToString();
            DateTime date = DateTime.UtcNow;
            cart.CartDate = date.ToString("yyyy-MM-dd");
            cart.quantity = 1;
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
                                    VALUES('{cart.CartId}', '{cart.CustomerId}', '{cart.CartDate}', '{cart.BookId}', {cart.quantity})");
        }
    }
}