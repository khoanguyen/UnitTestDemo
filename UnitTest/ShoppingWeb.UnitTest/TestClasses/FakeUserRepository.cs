using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using ShoppingWeb.Infrastructure.Domain;

namespace ShoppingWeb.UnitTest.TestClasses
{
    class FakeUserRepository : IUserRepository
    {

        private readonly List<User> _users = new List<User>()
            {
                new User {UserId = 1, UserName = "Khoa", Point = 15000, Password = "password"},
                new User {UserId = 2, UserName = "Quang", Point = 25000, Password = "password"},
                new User {UserId = 3, UserName = "Tham", Point = 5000, Password = "password"},
                new User {UserId = 4, UserName = "Khoi", Point = 0, Password = "password"},
            };

        public User FindByUserName(string userName)
        {
            if (userName == null) throw new NullReferenceException();
            return _users.SingleOrDefault(u => u.UserName == userName);
        }

        public void AddNewUser(User user)
        {
            if (_users.SingleOrDefault(u => u.UserName == user.UserName) != null)
                throw new UpdateException("Duplicate UserName");

            var newId = _users.Max(u => u.UserId) + 1;
            user.UserId = newId;
            _users.Add(user);
        }

        public void AppendPoint(string userName, int point)
        {
            var user = FindByUserName(userName);
            user.Point += point;
        }
    }
}
