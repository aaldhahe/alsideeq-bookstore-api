namespace alsideeq_bookstore_api.DTOs 
{

    public class CustomerDTO
    {
        public string CustomerId { get; set; }
        public string Username { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public AddressDTO Address { get; set; }
    }
}