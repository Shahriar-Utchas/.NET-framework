using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IRepo<CLASS, ID, RETURN>
    {
        RETURN Create(CLASS obj);
        RETURN Read(ID id);
        List<RETURN> ReadAll();
        RETURN Update(CLASS obj);
        RETURN Delete(ID id);

    }
}
