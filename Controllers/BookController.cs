using System;
using alsideeq_bookstore_api.DTOs;
using alsideeq_bookstore_api.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using alsideeq_bookstore_api.Exceptions;
using System.Collections.Generic;

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
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
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
                if (ex.Message.ToLower().Contains("duplicate entry"))
                {
                    return InternalServerError("Book with title '" + book.Title + "' already exists");
                }
                return InternalServerError(ex.Message);
            }
        }

        /// <summary>
        /// APIs for updating book
        /// </summary> 
        /// <returns> Returns updated book.</returns>
        [HttpPut]
        [Route("UpdateBook")]
        [ProducesResponseType(typeof(BookDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult UpdateBook([FromBody]BookDTO book)
        {   
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            try 
            {
                BookDTO updatedBook = _contract.UpdateBook(book);
                return Ok(updatedBook);
            }
            catch(ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(Exception ex)
            {
                if (ex.Message.ToLower().Contains("duplicate entry"))
                {
                    return InternalServerError("Book with title '" + book.Title + "' already exists");
                }
                return InternalServerError(ex.Message);
            }
        }

        /// <summary>
        /// APIs for updating book
        /// </summary> 
        /// <returns> Returns updated book.</returns>
        [HttpDelete]
        [Route("DeleteBook/{bookId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteBook(string bookId)
        {   
            if (string.IsNullOrEmpty(bookId))
            {
                return BadRequest("Book Id cannot be null or empty");
            }
            
            try 
            {
                _contract.DeleteBook(bookId);
                return OKNoContent();
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
         /// <summary>
        /// APIs for getting book category list
        /// </summary> 
        /// <returns> Returns list of available book categories</returns>
        [HttpGet]
        [Route("Books")]
        [ProducesResponseType(typeof(List<BookDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetBooksList(BookFilterViewModel viewModel)
        {
            try 
            {
                return Ok(_contract.GetBooksList(viewModel));
            }
            catch(Exception ex)
            {
                return InternalServerError(ex.Message);
            }
        }
    }
}