using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using alsideeq_bookstore_api.DTOs;
using alsideeq_bookstore_api.Exceptions;

namespace alsideeq_bookstore_api.Controllers
{
    /// <summary>
    /// APIs for managing Cart
    /// </summary>
    [Route("Cart")]
    public class CartController : BaseApiController
    {
        private readonly ILogger<CartController> _logger;
        private CartContract _contract;
        public CartController(ILogger<CartController> logger)
        {
            _logger = logger;
            _contract = new CartContract();
        }

        /// <summary>
        /// API to create a cart
        /// </summary>
        /// <returns> Returns newly created cart </returns>
        [HttpPost]
        [Route("CreateCart")]
        [ProducesResponseType(typeof(CartDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CreateCart([FromBody]CartDTO cart)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var createdCart = _contract.CreateCart(cart);
                return Created(string.Empty, createdCart);
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