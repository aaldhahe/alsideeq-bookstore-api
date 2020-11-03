
using System;
using alsideeq_bookstore_api.DTOs;

namespace alsideeq_bookstore_api.Controllers
{
    internal class SecurityContract : BaseContract
    {
        private AccountContract _accountContract;

        public SecurityContract() {
            _accountContract = new AccountContract();
        }

        public SecurityContract(AccountContract accountContract) 
        {
            _accountContract = accountContract;
        }

        internal CustomerDTO Login(UserDTO user)
        {
            bool usernameExists = _accountContract.CheckIfUsernameExist(user.Username);
            if (!usernameExists)
            {
                throw new Exception($"Username {user.Username} does not exist");
            }
            CustomerDTO dto = _accountContract.GetCustomerByUsername(user.Username, true);
            string hashedPwd = GetHashedPassword(user.Password);

            if (hashedPwd != dto.Password) 
            {
                throw new Exception("Invlid password");
            }
            dto.Password = null;
            return dto;
        }
    }
}