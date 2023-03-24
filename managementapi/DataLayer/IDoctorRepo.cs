using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IDoctorRepo
    {
        string AddDoctor(DataLayer.Entities.Doctor doctor);
        IEnumerable<DataLayer.Entities.Doctor> GetDoctorById(Guid id);
        IEnumerable<DataLayer.Entities.Doctor> GetDoctorByEmail(string email);
        IEnumerable<DataLayer.Entities.Doctor> GetAllDoctors();
    }
}
