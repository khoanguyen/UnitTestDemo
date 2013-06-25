using System.Linq;

namespace ShoppingWeb.Infrastructure.Domain
{
    public class UserRepository : IUserRepository
    {
        public User FindByUserName(string userName)
        {
            using (var context = new ShoppingWebDBEntities())
            {
                return context.Users.SingleOrDefault(u => u.UserName == userName);
            }
        }

        public void AddNewUser(User user)
        {
            using (var context = new ShoppingWebDBEntities())
            {
                context.AddToUsers(user);
                context.SaveChanges();
            }
        }

        public void AppendPoint(string userName, int point)
        {
            using (var context = new ShoppingWebDBEntities())
            {
                var user = FindByUserName(userName);
                if (user == null) return;
                user.Point += point;
                context.Update(user);
                context.SaveChanges();
            }
        }
    }
}