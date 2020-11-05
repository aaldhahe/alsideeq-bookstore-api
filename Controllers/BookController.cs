using System;
using alsideeq_bookstore_api.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using alsideeq_bookstore_api.Exceptions;

namespace alsideeq_bookstore_api.Controllers
{
    /// <summary>
    /// APIs for managing Books
    /// </summary>

    [Route("Book")]
    public class BookController : BaseApiController
    {
        private readonly ILogger<BookController> _logger;
        private BookContract _contract;

        public BookController(ILogger<BookController> logger)
        {
            _logger = logger;
            _contract = new BookContract();
        }

        /// <summary>
        /// APIs for creating book
        /// </summary> 
        /// <returns> Returns newly created book.</returns>
        [HttpPost]
        [Route("CreateBook")]
        [ProducesResponseType(typeof(BookDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CreateBook([FromBody]BookDTO book)
        {   
            if (book == null)
            {
                return BadRequest("There was a problem with the validation of the request body for create book");
            }

            try 
            {
                BookDTO createdBook = _contract.CreateBook(book);
                return Created(string.Empty, createdBook);
            }
            catch(ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(Exception ex)
            {
                return InternalServerError(ex.Message);
            }
        }

    }
}