using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShoppingWeb.Infrastructure.Domain;
using ShoppingWeb.Models;

namespace ShoppingWeb.Infrastructure
{
    public class AccountService
    {
        private IUserRepository _userRepository;

        public IUserRepository UserRepository
        {
            get { return _userRepository ?? (_userRepository = new UserRepository()); }
            set { _userRepository = value; }
        }  

        public bool VerifyUser(LoginModel loginModel)
        {
            var user = UserRepository.FindByUserName(loginModel.UserName);
            return user != null && user.Password == loginModel.Password;
        }

        public void AddNewUser(NewAccountModel newAccount)
        {
            UserRepository.AddNewUser(new User
                {
                    UserName = newAccount.UserName,
                    Password = newAccount.Password,
                    Point = 0
                });
        }
    }
}