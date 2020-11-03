using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using alsideeq_bookstore_api.Entity;
using alsideeq_bookstore_api.DTOs;
using alsideeq_bookstore_api.Exceptions;
using MySqlConnector;
using System.Threading.Tasks;
using System.Linq;

namespace alsideeq_bookstore_api.Controllers 
{
    /// <summary>
    /// APIs for managing create account
    /// </summary>

    [Route("Account")]
    public class AccountController : BaseApiController
    {

        private readonly ILogger<AccountController> _logger;
        private AccountContract _contract;
        public AccountController(ILogger<AccountController> logger) : base()
        {
            _logger = logger;
            _contract = new AccountContract();
        }
        
        /// <summary>
        /// APIs for managing create account
        /// </summary> 
        /// <param name="userId"></param>
        /// <returns> Returns all the current user accounts.</returns>
        [HttpGet]
        [Route("Users")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllUsers()
        {
            try {
                var ahmed = "Ahmed Aldhaheri is here";
                _logger.LogInformation(ahmed);
                using var connection = new MySqlConnection(DataSourceConnectionString.GetMySqlConnectionString());
                await connection.OpenAsync();
                using var command = new MySqlCommand("SELECT * FROM Address;", connection);
                using var reader = await command.ExecuteReaderAsync();
                string values = null;
                while(await reader.ReadAsync())
                {
                    Console.WriteLine(reader["address_id"].ToString());
                    values = (string) reader["address_id"];
                    
                }
                return Ok(ahmed + " : " + values);
                // return Ok(ahmed + "did not query db correctly");

            } catch (Exception aex) {
                return InternalServerError(aex);
            }
        }

        /// <summary>
        /// APIs for managing create account
        /// </summary> 
        /// <param name="customerId"></param>
        /// <returns> Returns all the current user accounts.</returns>
        [HttpGet]
        [Route("Customers/{customerId}")]
        [ProducesResponseType(typeof(CustomerDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetCustomer(string customerId)
        {
            try
            {
                var customer = _contract.GetCustomerById(customerId);
                if (customer == null) 
                {
                    return NotFound();
                }
                else {
                    return Ok(customer);
                }
            }
            catch(Exception ex) 
            {
                return InternalServerError(ex.Message);
            }
        }
        
        /// <summary>
        /// APIs for managing create account
        /// </summary> 
        /// <returns> Creates a customer account</returns>
        [HttpPost]
        [Route("CreateAccount")]
        [ProducesResponseType(typeof(CustomerDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CreateAccount([FromBody]CustomerDTO customer)
        {
            if (customer == null)
            {
                return BadRequest("There was a problem with the validation of the request parameters for create account");
            }

            try
            {
                CustomerDTO createdAccount = _contract.CreateAccount(customer);
                return Created(string.Empty, createdAccount);
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
        /// APIs for managing create account
        /// </summary> 
        /// <returns> Verifies username exist</returns>
        [HttpPost]
        [Route("VerifyExist")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult IsUsernameTaken([FromBody]UsernameDTO username)
        {
            if (username == null)
            {
                return BadRequest("There was a problem with the validation of the request parameters for verify existing username");
            }

            try
            {
                bool exist = _contract.CheckIfUsernameExist(username.Username);
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

    }
}