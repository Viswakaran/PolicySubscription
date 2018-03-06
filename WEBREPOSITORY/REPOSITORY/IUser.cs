using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEBREPOSITORY.REPOSITORY
{
   public interface IUser
    {
        IEnumerable<User> Select();
        bool Create(User userObj);
        bool Update(int userid, int pid, string name, string address);
        bool Delete(int userid);
        User Find(int userid);
    }
}
