using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using alsideeq_bookstore_api.Entity;
using MySqlConnector;
using System.Threading.Tasks;
using System.Linq;

namespace alsideeq_bookstore_api.Controllers 
{
    /// <summary>
    /// APIs for managing create account
    /// </summary>

    [Route("Account")]
    public class AccountController : ControllerBase
    {

        private readonly ILogger<AccountController> _logger;
        public AccountController(ILogger<AccountController> logger)
        {
            _logger = logger;
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
                using var command = new MySqlCommand("SELECT username FROM USERS;", connection);
                using var reader = await command.ExecuteReaderAsync();
                while(await reader.ReadAsync())
                {
                    var values = reader.GetValue(0);
                    return Ok(ahmed + " : " + values.ToString());
                }
                return Ok(ahmed + "did not query db correctly");

            } catch (Exception aex) {
                return StatusCode(500, aex.Message);
            }
        }
    }
}