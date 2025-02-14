using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class UserRepo : RepoDB, IAuth<bool>
    {
        public bool Authenticate(string uname, string password)
        {
            var user = db.Users.FirstOrDefault(u => u.Uname == uname && u.password == password);
            if (user != null) return true;
            return false;
        }
    }

}
