using System;
using alsideeq_bookstore_api.Adapters;
using alsideeq_bookstore_api.DTOs;
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

        
    }
}