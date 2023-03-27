using DataLayer;
using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class DoctorLogic : IDoctorLogic
    {
        private readonly IDoctorRepo _repo;

        public DoctorLogic(IDoctorRepo repo) {
            _repo = repo;
        }
        public string AddDoctor(Doctor doctor)
        {
            return _repo.AddDoctor(doctor);
        }

        public IEnumerable<Doctor> GetAll()
        {
            return _repo.GetAllDoctors();
        }

        Doctor IDoctorLogic.GetByEmail(string email)
        {
            return _repo.GetDoctorByEmail(email);
        }

        public IEnumerable<Doctor> GetById(Guid id)
        {
            return _repo.GetDoctorById(id);
        }
    }
}
