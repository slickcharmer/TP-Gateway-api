using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public interface INurseLogic
    {
        string AddNurse(DataLayer.Entities.Nurse nurse);
        IEnumerable<DataLayer.Entities.Nurse> GetAll();
        IEnumerable<DataLayer.Entities.Nurse> GetByEmail(string email);

    }
}
