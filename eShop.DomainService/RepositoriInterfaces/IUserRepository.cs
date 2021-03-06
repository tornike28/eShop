using eShop.DataTransferObject;
using eShop.DomainModel.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.DomainService.RepositoriInterfaces
{
    public interface IUserRepository
    {
        bool Login(UserEntity UserEntity);
        bool CheckSessionID(Guid SessionID);
        List<UserQueryDTO> GetUsersQuery();
        bool CheckUserExists(string email);
        void AdminRegistration(UserEntity user);
        bool DeleteUser(Guid userId);
        bool DeleteSessionId(Guid sessionID);
        List<UserStatisticsDTO> GetUsersStatisticsQuery();
        void UserRegistration(UserEntity userModel);
        void UserActivation(string userMail);
        UserQueryDTO GetUserQuery(string mail);
        void UpdateUserInformation(UserDTO userDTO);
        void SaveUserAddress(UserAddressDTO userAddressDTO);
        List<UserAddressDTO> GetUserAddresses(string userMail);
    }
}
