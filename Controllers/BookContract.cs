using System;
using alsideeq_bookstore_api.Adapters;
using alsideeq_bookstore_api.DTOs;
using alsideeq_bookstore_api.Exceptions;
using MySqlConnector;

namespace alsideeq_bookstore_api.Controllers
{
    internal class BookContract : BaseContract 
    {
        private BookAdapter _adapter;
        internal BookContract(BookAdapter adapter)
        {
            _adapter = adapter;
        }
        internal BookContract()
        {
            _adapter = new BookAdapter();
        }

        internal BookDTO CreateBook(BookDTO book)
        {
            
            return new BookDTO();
        }

        internal BookDTO CreateBookAndLinkExistingAuthor(BookDTO book, string authorId)
        {
            book.Author.AuthorId = authorId;
            book.BookId = ContentGuid.ToString();
            string query = BuildQueryLinkExistingAuthor(book);
            using(var dataSource = DataSource)
            {
                dataSource.Open();
                QueryDataSource(query, dataSource);
                dataSource.Close();
            }
            return book;
        }

        internal string BuildQueryLinkExistingAuthor(BookDTO book)
        {
            return string.Format(
                @"INSERT INTO Book (book_id, title, price, description, photo_path, stock, category_id, author_id)
                    VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', {5}, '{6}', '{7}')",
                    book.BookId, book.Title, book.Price, book.Description, book.PhotoPath, book.Stock, book.Category.CategoryId, book.Author.AuthorId
            );
        }

        internal string GetAuthorID(AuthorDTO author)
        {
            try
            {
                return GetAuthorByName(author).AuthorId;
            }
            catch(NotFoundException)
            {
                return null;
            }
        }

        internal AuthorDTO GetAuthorByName(AuthorDTO author)
        {
            string query = string.Format(
                @"SELECT * 
                FROM Author
                WHERE firstname = '{0}' AND lastname = '{1}'", author.Firstname, author.Lastname
            );
            AuthorDTO dto;
            using (var dataSource = DataSource)
            {
                dataSource.Open();
                var queryResult = QueryDataSource(query, dataSource);
                if (!queryResult.Read())
                {
                    throw new NotFoundException("Cannot find author with firstname " + author.Firstname + " and lastname " + author.Lastname);
                }
                dto = _adapter.ToAuthorDTO(queryResult);
                dataSource.Close();
            }
            return dto;
        }

        
    }
}