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
using System.Transactions;

namespace eShop.DataBaseRepository
{
    public class UserRepostiory : IUserRepository
    {
        public void AdminRegistration(UserEntity user)
        {
            using (var scope = new TransactionScope())
            {
                using (eShopDBContext context = new eShopDBContext())
                {
                    try
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
                            RoleId = 2,
                            UserId = user.Id
                        };

                        context.UsersInRoles.Add(usersInRole);
                        context.Users.Add(newUser);

                        context.SaveChanges();
                        scope.Complete();
                    }
                    catch (Exception)
                    {
                        scope.Dispose();
                    }
                }
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

        public List<UserAddressDTO> GetUserAddresses(string userMail)
        {
            using (eShopDBContext context = new eShopDBContext())
            {
                var UserId = (from u in context.Users
                              where u.DateDeleted == null && u.Email == userMail
                              select u.Id).FirstOrDefault();

                var query = (from u in context.UserAddresses
                             select new UserAddressDTO
                             {
                                 Id = u.Id,
                                 City = u.City,
                                 FullAddress = u.FullAddress
                             }).ToList();

                return query;
            }
        }

        public UserQueryDTO GetUserQuery(string mail)
        {
            using (eShopDBContext context = new eShopDBContext())
            {
                var query = (from user in context.Users
                             join ur in context.UsersInRoles on user.Id equals ur.UserId
                             where user.DateDeleted == null && user.Email == mail
                             select new UserQueryDTO
                             {
                                 ID = user.Id,
                                 FirstName = user.FirstName,
                                 LastName = user.LastName,
                                 Email = user.Email,
                                 IsActive = user.IsActive,
                                 DateCreated = user.DateCreated
                             }).FirstOrDefault();

                return query;
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

        public List<UserStatisticsDTO> GetUsersStatisticsQuery()
        {
            using (eShopDBContext context = new eShopDBContext())
            {
                var query = context.Users
                                        .GroupBy(m => m.DateCreated.Date)
                                        .Select(m => new UserStatisticsDTO
                                        {
                                            Month = m.Key.Month,
                                            NumberOfUsers = m.Count()
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

        public void SaveUserAddress(UserAddressDTO userAddressDTO)
        {
            using (eShopDBContext context = new eShopDBContext())
            {
                var User = (from u in context.Users
                           where u.Email == userAddressDTO.Email
                           select u.Id).FirstOrDefault();

                if (User != Guid.Empty)
                {
                    UserAddress userAddress = new UserAddress()
                    {
                        UserId = User,
                        City = userAddressDTO.City,
                        FullAddress = userAddressDTO.FullAddress,
                        IsPrimary = userAddressDTO.IsPrimary,
                        DateCreated = DateTime.Now
                    };
                    context.UserAddresses.Add(userAddress);
                    context.SaveChanges();


                }
            }
        }

        public void UpdateUserInformation(UserDTO userDTO)
        {
            using (eShopDBContext context = new eShopDBContext())
            {
                var query = (from user in context.Users
                             select user).FirstOrDefault();

                if (query != null)
                {

                    if (!string.IsNullOrWhiteSpace(userDTO.FirstName)) query.FirstName = userDTO.FirstName;
                    if (!string.IsNullOrWhiteSpace(userDTO.LastName)) query.LastName = userDTO.LastName;
                    if (!string.IsNullOrWhiteSpace(userDTO.Email)) query.Email = userDTO.Email;

                    context.SaveChanges();
                }
            }
        }

        public void UserActivation(string userMail)
        {
            using (eShopDBContext context = new eShopDBContext())
            {
                var user = (from c in context.Users
                            where c.Email == userMail
                            select c).FirstOrDefault();

                user.IsActive = true;
                context.SaveChanges();
            }
        }

        public void UserRegistration(UserEntity user)
        {
            using (var scope = new TransactionScope())
            {
                using (eShopDBContext context = new eShopDBContext())
                {
                    try
                    {
                        User newUser = new User()
                        {
                            Id = user.Id,
                            Email = user.Email,
                            FirstName = user.FirstName,
                            PasswordHash = user.PasswordHash,
                            IsActive = false,
                            LastName = user.LastName,
                        };
                        UsersInRole usersInRole = new UsersInRole()
                        {
                            RoleId = 0,
                            UserId = user.Id
                        };

                        context.UsersInRoles.Add(usersInRole);
                        context.Users.Add(newUser);

                        context.SaveChanges();
                        scope.Complete();
                    }
                    catch (Exception)
                    {
                        scope.Dispose();
                    }
                }
            }
        }
    }
}
