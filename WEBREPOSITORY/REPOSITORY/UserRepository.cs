using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEBREPOSITORY.REPOSITORY
{
    public class UserRepository : IUser
    {
        ProjectEntities ProUser = new ProjectEntities();
        public bool Create(User userObj)
        {
            ProUser.Users.Add(userObj);
            ProUser.SaveChanges();
            return true;
        }

        public bool Delete(int userid)
        {

            var deleteUser = (from user in ProUser.Users
                              where (user.UserID == userid)
                              select user).FirstOrDefault();
            if (deleteUser != null)
            {
                ProUser.Users.Remove(deleteUser);
                ProUser.SaveChanges();
            };
            return true;
        }

        public User Find(int userid)
        {
            User user = ProUser.Users.Find(userid);
            return user;
        }

        public IEnumerable<User> Select()
        {
            var lstusers = from user in ProUser.Users
                           select user;

            return lstusers;
        }

        public bool Update(int userid, int pid, string name, string address)
        {

            var updateUser = (from user in ProUser.Users
                              where (user.UserID == userid)
                              select user).FirstOrDefault();
            if (updateUser != null)
            {
                updateUser.PID = pid;
                updateUser.Name = name;
                updateUser.Address = address;
                ProUser.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
