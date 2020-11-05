namespace alsideeq_bookstore_api.DTOs
{
    public class BookDTO 
    {
        public string BookId { get; set; }
        public string title { get; set; }
        public string Price { get; set; }
        public string Description { get; set; }
        public string PhotoPath { get; set; }
        public int Stock { get; set; }
        public AuthorDTO Author { get; set; }
        public CategoryDTO Category { get; set; }

    }
}