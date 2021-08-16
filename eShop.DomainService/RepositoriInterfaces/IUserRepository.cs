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
        void AddNewUser(UserEntity user, int roleID);
        bool DeleteUser(Guid userId);
    }
}
