using eShop.DataTransferObject;
using eShop.DomainModel.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.DomainService.ServiceInterfaces
{
    public interface IUserDomainService
    {
        List<string> Login(UserEntity user);

        bool CheckSessionIsValid(Guid SessionID);

        ResultDTO Registration(UserEntity user, int roleID);
        bool DeleteUser(Guid userId);
    }
}
