using alsideeq_bookstore_api.DTOs;
using MySqlConnector;

namespace alsideeq_bookstore_api.Adapters
{
    public class BookAdapter : BaseAdapter
    {
        public BookDTO ToBookDTO(MySqlDataReader data)
        {
            return new BookDTO();
        }
    }
}