using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface INurseRepo
    {
        string AddNurse(DataLayer.Entities.Nurse nurse);
        IEnumerable<DataLayer.Entities.Nurse> GetAllNurse();
        IEnumerable<DataLayer.Entities.Nurse> GetNurseByEmail(string email);
    }
}
