using System.ComponentModel.DataAnnotations;
namespace alsideeq_bookstore_api.DTOs
{
    public class CategoryDTO
    {
        [Required(ErrorMessage = "category id is required")]
        public string CategoryId { get; set; }
        public string Title { get; set; } 
        public string Description { get; set; }
    }
}