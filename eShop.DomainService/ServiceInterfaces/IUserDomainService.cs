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

        ResultDTO AdminRegistration(UserEntity user);
        bool DeleteUser(Guid userId);
        ResultDTO UserRegistration(UserEntity userModel);
    }
}
