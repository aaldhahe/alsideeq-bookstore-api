using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using alsideeq_bookstore_api.DTOs;

namespace alsideeq_bookstore_api.Controllers
{
    /// <summary>
    /// APIs for managing create account
    /// </summary>

    [Route("Security")]
    public class SecurityController : BaseApiController
    {
        private readonly ILogger<SecurityController> _logger;
        private SecurityContract _contract;

        public SecurityController(ILogger<SecurityController> logger) : base()
        {
            _logger = logger;
            _contract = new SecurityContract();
        }

        /// <summary>
        /// APIs for managing login
        /// </summary> 
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns> Returns user account </returns>
        [HttpPost]
        [Route("Login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Login([FromBody]UserDTO user)
        {   
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            } 
            try 
            {
                CustomerDTO customer = _contract.Login(user);
                return Ok(customer);
            }
            catch(Exception ex)
            {
                return InternalServerError(ex.Message);
            }
        } 
    }
}