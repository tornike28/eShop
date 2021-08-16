using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace eShop.DomainModel.Entity
{
    public class UserEntity
    {
        public Guid Id { get; private set; }
        public Guid? SessionId { get; private set; }
        public string ActivationCode { get; private set; }
        public bool IsActive { get; private set; }
        public string Email { get; private set; }
        public string PasswordHash { get; private set; }
        public string PasswordHashRepeat { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public DateTime DateCreated { get; private set; }
        public DateTime? DateChanged { get; private set; }
        public DateTime? DateDeleted { get; private set; }


        public void Set(UserEntity user)
        {
            Id = Guid.NewGuid();
            SessionId = user.SessionId;
            ActivationCode = user.ActivationCode;
            IsActive = user.IsActive;
            Email = user.Email;
            PasswordHash = user.PasswordHash;
            PasswordHashRepeat = user.PasswordHashRepeat;
            FirstName = user.FirstName;
            LastName = user.LastName;
            DateCreated = user.DateCreated;
            DateChanged = user.DateChanged;
            DateDeleted = user.DateDeleted;


        }

        public UserEntity Get(UserOperationType userOperationType)
        {
            switch (userOperationType)
            {
                case UserOperationType.Login:
                    this.SessionId = Guid.NewGuid();
                    break;
                case UserOperationType.Registration:
                    break;
                case UserOperationType.Activation:
                    break;
                default:
                    break;
            }
            return this;
        }
        public List<string> IsValid(UserValidationType ValidationType)
        {
            switch (ValidationType)
            {
                case UserValidationType.Login:
                    return LoginValidation();
                case UserValidationType.Registration:
                    return RegistrationValidation();
                case UserValidationType.Activation:
                    return ActivationValidation();
                default:
                    return new List<string>();
            }
        }

        private List<string> LoginValidation()
        {
            List<string> Errorresult = new List<string>();

            if (string.IsNullOrEmpty(this.Email))
            {
                Errorresult.Add(UserErrors.Email_Is_Empty.ToString());
            }
            else
            {
                if (!Regex.IsMatch(this.Email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
                {
                    Errorresult.Add(UserErrors.Email_Is_Not_Valid.ToString());
                }
            }



            if (string.IsNullOrEmpty(this.PasswordHash))
            {
                Errorresult.Add(UserErrors.Password_Is_Empty.ToString());
            }
            return Errorresult;
        }

        private string PasswordHashGenerator(string Password)
        {
            var bytes = System.Text.Encoding.UTF8.GetBytes(Password);
            using (var hash = System.Security.Cryptography.SHA512.Create())
            {
                var hashedInputBytes = hash.ComputeHash(bytes);
                var hashedInputedStringBuilder = new System.Text.StringBuilder(128);
                foreach (var b in hashedInputBytes)
                {
                    hashedInputedStringBuilder.Append(b.ToString("X2"));
                }
                return hashedInputedStringBuilder.ToString();
            }
        }

        private List<string> RegistrationValidation()
        {

            List<string> Errorresult = new List<string>();
            if (string.IsNullOrEmpty(this.FirstName))
            {
                Errorresult.Add(UserErrors.FirstName_Is_Empty.ToString());
            }
            if (string.IsNullOrEmpty(this.LastName))
            {
                Errorresult.Add(UserErrors.LastName_Is_Empty.ToString());
            }
            if (string.IsNullOrEmpty(this.Email))
            {
                Errorresult.Add(UserErrors.Email_Is_Empty.ToString());
            }
            else
            {
                if (!Regex.IsMatch(this.Email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
                {
                    Errorresult.Add(UserErrors.Email_Is_Not_Valid.ToString());
                }
            }
          

            return Errorresult;

        }

        private List<string> ActivationValidation()
        {
            return new List<string>();

        }

    }
    public enum UserErrors
    {
        Email_Is_Empty = 0,
        Email_Is_Not_Valid = 1,
        Password_Is_Empty = 2,
        Password_Is_Not_Match = 3,
        FirstName_Is_Empty = 4,
        LastName_Is_Empty = 5
    }
    public enum UserValidationType
    {
        Login = 0,
        Registration = 1,
        Activation = 2
    }

    public enum UserOperationType
    {
        Login = 0,
        Registration = 1,
        Activation = 2
    }
}
