using alsideeq_bookstore_api.DTOs;
using MySqlConnector;
using System.Collections.Generic;

namespace alsideeq_bookstore_api.Adapters
{
    public class BookAdapter : BaseAdapter
    {
        public BookDTO ToBookDTO(MySqlDataReader data)
        {
             BookCategoryAdapter adapter = new BookCategoryAdapter();
            BookDTO book = new BookDTO();
            AuthorDTO author = ToAuthorDTO(data);
            CategoryDTO category = adapter.ToCategoryDTO(data);
            book.Category = category;
            book.Author = author;
            AssignModelValueToDomain<string>(s => book.BookId = (string)s, data["book_id"]);
            AssignModelValueToDomain<string>(s => book.Title = (string)s, data["title"]);
            AssignModelValueToDomain<string>(s => book.Price = (string)s, data["price"]);
            AssignModelValueToDomain<string>(s => book.Description = (string)s, data["description"]);
            AssignModelValueToDomain<string>(s => book.PhotoPath = (string)s, data["photo_path"]);
            AssignModelValueToDomain<int>(i => book.Stock = (int)i, data["stock"]);
            return book;
        }

        public AuthorDTO ToAuthorDTO(MySqlDataReader data)
        {
            AuthorDTO author = new AuthorDTO();
            AssignModelValueToDomain<string>(s => author.AuthorId = (string)s, data["author_id"]);
            AssignModelValueToDomain<string>(s => author.Firstname = (string)s, data["firstname"]);
            AssignModelValueToDomain<string>(s => author.Lastname = (string)s, data["lastname"]);
            return author;
        }

        public List<BookDTO> ToBookDTOList(MySqlDataReader data)
        {
            List<BookDTO> books = new List<BookDTO>();
            while(data.Read())
            {
                books.Add(ToBookDTO(data));
            }
            return books;
        }
    }
}