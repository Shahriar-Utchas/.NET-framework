using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IAuth <RETURN>
    {
        RETURN Authenticate(string uname, string password);
    }
}
