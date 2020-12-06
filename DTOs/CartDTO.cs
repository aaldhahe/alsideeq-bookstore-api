using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace alsideeq_bookstore_api.DTOs
{
    public class CartGetDTO
    {
        public CustomerDTO Customer { get; set; }
        public List<CartDTOs> Carts { get; set; }
    }

    public class CartDTO
    {
        public string CartId { get; set; }
        [Required(ErrorMessage = "customer id is required")]
        public string CustomerId { get; set; }
        public string CartDate { get; set; }
        [Required(ErrorMessage = "book id is required")]
        public string BookId { get; set; }
        public int Quantity { get; set; }

    }

    public class CartDTOs
    {
        public CartDTO Cart { get; set; }
        public BookDTO Item { get; set; }
    }

}