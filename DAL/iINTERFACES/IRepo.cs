using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.iINTERFACES
{
    public interface IRepo<CLASS, ID, RET>
    {
        List<CLASS> Get();
        CLASS Get (int id);
        RET Create(CLASS obj);
        RET Update(CLASS obj);
        RET Delete(int id);
    }
}
