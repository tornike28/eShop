using eShop.DataBaseRepository.DB;
using eShop.DataBaseRepository.DB.Models;
using eShop.DataTransferObject;
using eShop.DomainModel.Entity;
using eShop.DomainService.RepositoriInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.DataBaseRepository
{
    public class UserRepostiory : IUserRepository
    {
        public void AddNewUser(UserEntity user, int roleID)
        {
            using (eShopDBContext context = new eShopDBContext())
            {
                User newUser = new User()
                {
                    Id = user.Id,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    PasswordHash = user.PasswordHash,
                    IsActive = true,
                    LastName = user.LastName,
                };
                UsersInRole usersInRole = new UsersInRole()
                {
                    RoleId = roleID,
                    UserId = user.Id
                };

                context.UsersInRoles.Add(usersInRole);
                context.Users.Add(newUser);

                context.SaveChanges();
            }
        }

        public bool CheckSessionID(Guid SessionID)
        {
            using (eShopDBContext context = new eShopDBContext())
            {
                var query = (from user in context.Users
                             where user.SessionId == SessionID &&
                             user.DateDeleted == null &&
                             user.IsActive == true
                             select user).FirstOrDefault();

                return query != null;
            }
        }

        public bool CheckUserExists(string email)
        {
            using (eShopDBContext context = new eShopDBContext())
            {
                var query = (from user in context.Users
                             where user.Email == email &&
                             user.DateDeleted == null
                             select user).FirstOrDefault();

                return query != null ? false : true;

            }
        }

        public bool DeleteSessionId(Guid sessionID)
        {
            using (eShopDBContext context = new eShopDBContext())
            {
                var user = (from item in context.Users
                            where item.SessionId == sessionID
                            select item).FirstOrDefault();
                if (user == null)
                {
                    return false;
                }
                else
                {
                    user.SessionId = null;
                    context.SaveChanges();
                    return true;
                }
            }
        }

        public bool DeleteUser(Guid userId)
        {
            using (eShopDBContext context = new eShopDBContext())
            {
                var user = (from item in context.Users
                            where item.Id == userId
                            select item).FirstOrDefault();
                if (user == null)
                {
                    return false;
                }
                else
                {
                    user.DateDeleted = DateTime.Now;
                    context.SaveChanges();
                    return true;
                }
            }
        }

        public List<UserQueryDTO> GetUsersQuery()
        {
            using (eShopDBContext context = new eShopDBContext())
            {
                var query = (from user in context.Users
                             join ur in context.UsersInRoles on user.Id equals ur.UserId
                             where user.DateDeleted == null
                             select new UserQueryDTO
                             {
                                 ID = user.Id,
                                 FirstName = user.FirstName,
                                 LastName = user.LastName,
                                 Email = user.Email,
                                 IsActive = user.IsActive,
                                 Role = ur.Role.Name,
                                 DateCreated = user.DateCreated
                             }).ToList();

                return query;
            }
        }

        public bool Login(UserEntity UserModel)
        {
            using (eShopDBContext context = new eShopDBContext())
            {
                var query = (from user in context.Users
                             where user.Email == UserModel.Email &&
                             user.PasswordHash == UserModel.PasswordHash &&
                             user.DateDeleted == null &&
                             user.IsActive == true
                             select user).FirstOrDefault();

                if (query != null)
                {
                    query.SessionId = UserModel.SessionId;
                    context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

    }
}
