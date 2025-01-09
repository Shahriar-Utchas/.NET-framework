using DAL.EF.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface INewsRepo<CLASS, ID, NAME, DATE>
    {
        List<CLASS> GetAll();
        CLASS GetByID(int id);
        void Create(CLASS news);
        string Update(CLASS news);
        void Delete(ID id);
        List<CLASS> GetByCategory(NAME category);
        List<CLASS> GetByDate(DATE date);
        List<CLASS> GetByTitle(NAME title);
        List<CLASS> GetByDateTitle(DATE d, NAME title);
        List<CLASS> GetByDateCategory(DATE d, NAME title);
    }
}
