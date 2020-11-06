using System;
using alsideeq_bookstore_api.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using alsideeq_bookstore_api.Exceptions;

namespace alsideeq_bookstore_api.Controllers
{
    /// <summary>
    /// APIs for managing Book Categories
    /// </summary>
    [Route("Category")]
    public class CategoryController : BaseApiController
    {
        private readonly ILogger<CategoryController> _logger;
        private CategoryContract _contract;

        public CategoryController(ILogger<CategoryController> logger)
        {
            _logger = logger;
            _contract = new CategoryContract();
        }

        /// <summary>
        /// APIs for creating book category
        /// </summary> 
        /// <returns> Returns newly created category.</returns>
        [HttpPost]
        [Route("CreateCategory")]
        [ProducesResponseType(typeof(CategoryDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CreateCategory([FromBody]CategoryDTO category)
        {
            if (category == null)
            {
                return BadRequest("There was a problem with the validation of the request body for create book category");
            }
            try 
            {
                CategoryDTO createdCategory = _contract.CreateCategory(category);
                return Created(string.Empty, createdCategory);
            }
            catch(ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(Exception ex)
            {
                if (ex.Message.ToLower().Contains("duplicate entry"))
                {
                    return InternalServerError("Category with title '" + category.Title + "' already exists");
                } 
                else 
                {
                    return InternalServerError(ex.Message);
                }
            }
        }

        /// <summary>
        /// API for checking if book category exist
        /// </summary> 
        /// <returns> Verifies book category exist</returns>
        [HttpPost]
        [Route("VerifyExist")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult IsCategoryTaken([FromBody]CategoryDTO category)
        {
            if (category == null)
            {
                return BadRequest("There was a problem with the validation of the request parameters for verify existing book category");
            }

            try
            {
                bool exist = _contract.CheckIfCategoryExist(category.Title);
                return Ok(exist);
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
        /// APIs for getting book category by id
        /// </summary> 
        /// <param name="title"></param>
        /// <returns> Returns book category with specific title.</returns>
        [HttpGet]
        [Route("Category/{title}")]
        [ProducesResponseType(typeof(CategoryDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetCategoryByTitle(string title)
        {
            if (title == null)
            {
                return BadRequest("Title field cannot be null");
            }
            try
            {
                var category = _contract.GetCategoryByTitle(title);
                if (category == null) 
                {
                    return NotFound();
                }
                else {
                    return Ok(category);
                }
            }
            catch(Exception ex) 
            {
                return InternalServerError(ex.Message);
            }
        }

    }
}