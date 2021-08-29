using eShop.DataTransferObject;
using eShop.DomainModel.Entity;
using eShop.DomainService.RepositoriInterfaces;
using eShop.DomainService.ServiceInterfaces;
using eShop.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.DomainService.Services
{
    public class UserDomainService : IUserDomainService
    {
        private IUserRepository _UserRepository;
        public UserDomainService(IUserRepository UserRepository)
        {
            _UserRepository = UserRepository;
        }

        public bool CheckSessionIsValid(Guid SessionID)
        {
            return _UserRepository.CheckSessionID(SessionID);
        }

        public bool DeleteUser(Guid userId)
        {
            return _UserRepository.DeleteUser(userId);
        }

        public List<string> Login(UserEntity user)
        {
            var validationResponse = new List<string>();
            validationResponse = user.IsValid(UserValidationType.Login);

            if (validationResponse.Count == 0)
            {
                if (!_UserRepository.Login(user.Get(UserOperationType.Login)))
                {
                    return new List<string>() { "Email_Or_Password_Active_Not_Valid" };
                }
                return validationResponse;
            }
            else
            {
                return validationResponse;
            }
        }
        public ResultDTO AdminRegistration(UserEntity user)
        {
            var validationResponse = new List<string>();
            validationResponse = user.IsValid(UserValidationType.Registration);

            if (!_UserRepository.CheckUserExists(user.Email))
            {
                validationResponse.Add("User already exist");
            }

            if (validationResponse.Count != 0)
            {
                return new ResultDTO()
                {
                    IsError = true,
                    ErrorMessages = validationResponse
                };
            }
            else
            {
                _UserRepository.AdminRegistration(user);
                return new ResultDTO() { IsError = false };
            }
        }

        public ResultDTO UserRegistration(UserEntity userModel)
        {

            var validationResponse = new List<string>();
            validationResponse = userModel.IsValid(UserValidationType.Registration);

            if (!_UserRepository.CheckUserExists(userModel.Email))
            {
                validationResponse.Add("User already exist");
            }

            if (validationResponse.Count != 0)
            {
                return new ResultDTO()
                {
                    IsError = true,
                    ErrorMessages = validationResponse,
                   
                };
            }
            else
            {
                _UserRepository.UserRegistration(userModel);
                return new ResultDTO() { IsError = false, VerificationURL = Guid.NewGuid().ToString() };
            }
        }
    }
}
