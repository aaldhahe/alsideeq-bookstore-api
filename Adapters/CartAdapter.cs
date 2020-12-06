using MySqlConnector;
using System.Collections.Generic;
using alsideeq_bookstore_api.DTOs;
using alsideeq_bookstore_api.Controllers;

namespace alsideeq_bookstore_api.Adapters
{
    public class CartAdapter : BaseAdapter
    {
        private BookContract _contract;
        public CartAdapter()
        {
            _contract = new BookContract();
        }
        public CartDTO ToCartDTO(MySqlDataReader data)
        {
            CartDTO cart = new CartDTO();
            AssignModelValueToDomain<string>(s => cart.CartId = (string)s, data["cart_id"]);
            AssignModelValueToDomain<string>(s => cart.CartDate = (string)s, data["cart_date"]);
            AssignModelValueToDomain<string>(s => cart.BookId = (string)s, data["book_id"]);
            AssignModelValueToDomain<string>(s => cart.CustomerId = (string)s, data["customer_id"]);
            AssignModelValueToDomain<int>(i => cart.Quantity = (int)i, data["quantity"]);
            return cart;
        }

        public List<CartDTOs> ToCartDTOsList(MySqlDataReader data)
        {
            List<CartDTOs> carts = new List<CartDTOs>();
            while (data.Read())
            {
                CartDTOs cart = new CartDTOs();
                cart.Cart = ToCartDTO(data);
                cart.Item = _contract.GetBookById(cart.Cart.BookId);
                carts.Add(cart);
            }
            return carts;
        }
    }
}