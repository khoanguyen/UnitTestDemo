using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingWeb.Infrastructure.Domain
{
    public interface IUserRepository
    {
        User FindByUserName(string userName);
        void AddNewUser(User user);
        void AppendPoint(string userName, int point);
    }
}
