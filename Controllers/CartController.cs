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

        /// <summary>
        /// API to create a cart
        /// </summary>
        /// <returns> Returns updated cart </returns>
        [HttpPut]
        [Route("UpdateCart")]
        [ProducesResponseType(typeof(CartDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult UpdateCart([FromBody]CartDTO cart)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return Ok(_contract.UpdateCart(cart));
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
        /// API to customer cart
        /// </summary>
        /// <returns> Returns customer cart </returns>
        [HttpGet]
        [Route("GetCart/{customerId}")]
        [ProducesResponseType(typeof(CartDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetCustomerCart(string customerId)
        {
            if (string.IsNullOrEmpty(customerId))
            {
                return BadRequest("Customer Id cannot be empty");
            }

            try
            {
                return Ok(_contract.GetCustomerCart(customerId));
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
        /// API to Delete cart
        /// </summary>
        /// <returns> Delete customer cart </returns>
        [HttpDelete]
        [Route("DeleteCart/{cartId}")]
        [ProducesResponseType(typeof(CartDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteCart(string cartId)
        {
            if (string.IsNullOrEmpty(cartId))
            {
                return BadRequest("Cart Id cannot be empty");
            }

            try
            {
                _contract.DeleteCart(cartId);
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

    }

}