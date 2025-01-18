using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IRepo<CLASS,ID, RETURN>
    {
        RETURN GetByID(ID id);
        List<CLASS> GetAll();
        RETURN Add(CLASS obj);
        RETURN Update(CLASS obj);
        bool Delete(ID id);

    }
}
