using eShop.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.ApplicationService.ServiceInterfaces
{
    public interface IUserApplicationService
    {
        UserAuthResponseDTO Login(LoginDTO User);
        List<UserQueryDTO> GetUsersQuery();
        ResultDTO UserRegistraion(UserDTO User, int roleID);
        bool DeleteUser(Guid userId);
        bool DeleteSessionID(Guid sessionID);
    }
}
