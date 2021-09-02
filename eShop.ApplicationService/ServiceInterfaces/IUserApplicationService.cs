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
        ResultDTO AdminRegistration(UserDTO User);
        bool DeleteUser(Guid userId);
        bool DeleteSessionID(Guid sessionID);
        List<UserStatisticsDTO> GetUsersStatisticQuery();
        ResultDTO UserRegistration(UserDTO loginModel);
        void UserActivation(string userMail);
        UserQueryDTO GetUserQuery(string mail);
        void UpdateUserInformation(UserDTO userDTO);
    }
}
