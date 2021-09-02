using eShop.ApplicationService.ServiceInterfaces;
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

namespace eShop.ApplicationService.Services
{
    public class UserApplicationService : IUserApplicationService
    {
        private IUserDomainService _UserDomainService;
        private IUserRepository _UserRepository;
        public UserApplicationService(IUserDomainService UserDomainService, IUserRepository UserRepository)
        {
            _UserDomainService = UserDomainService;
            _UserRepository = UserRepository;
        }

        public bool DeleteSessionID(Guid sessionID)
        {
            return _UserRepository.DeleteSessionId(sessionID);
            
        }

        public bool DeleteUser(Guid userId)
        {
           return _UserDomainService.DeleteUser(userId);
        }

        public List<UserQueryDTO> GetUsersQuery()
        {
            var result = _UserRepository.GetUsersQuery();
            return result;
        }

        public List<UserStatisticsDTO> GetUsersStatisticQuery()
        {
           return _UserRepository.GetUsersStatisticsQuery();
        }

        public UserAuthResponseDTO Login(LoginDTO User)
        {
            UserEntity UserModel = new UserEntity();
            UserModel.Set(AutoMapperExtensions.MapObject<LoginDTO, UserEntity>(User));
            return new UserAuthResponseDTO()
            {
                Messages = _UserDomainService.Login(UserModel),
                SessionID = UserModel.SessionId
            };
        }

        public ResultDTO AdminRegistration(UserDTO User)
        {
            UserEntity UserModel = new UserEntity();
            UserModel.Set(AutoMapperExtensions.MapObject<UserDTO, UserEntity>(User));

                return _UserDomainService.AdminRegistration(UserModel);
        }

        public ResultDTO UserRegistration(UserDTO loginModel)
        {
            UserEntity UserModel = new UserEntity();
            UserModel.Set(AutoMapperExtensions.MapObject<UserDTO, UserEntity>(loginModel));

            return _UserDomainService.UserRegistration(UserModel);
        }

        public void UserActivation(string userMail)
        {
             _UserRepository.UserActivation(userMail);
        }

        public UserQueryDTO GetUserQuery(string mail)
        {
           return _UserRepository.GetUserQuery(mail);
        }

        public void UpdateUserInformation(UserDTO userDTO)
        {
             _UserRepository.UpdateUserInformation(userDTO);
        }
    }
}

