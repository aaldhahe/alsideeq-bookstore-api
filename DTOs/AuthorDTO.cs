using System.ComponentModel.DataAnnotations;
namespace alsideeq_bookstore_api.DTOs
{
    public class AuthorDTO
    {
        public string AuthorId { get; set; }
        [Required(ErrorMessage = "firstname is required")]
        public string Firstname { get; set; }
        [Required(ErrorMessage = "lastname is required")]
        public string Lastname { get; set; }
    }
}