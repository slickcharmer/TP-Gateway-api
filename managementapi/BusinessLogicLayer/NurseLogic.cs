using DataLayer;
using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class NurseLogic : INurseLogic
    {
        private readonly INurseRepo _repo;
        public NurseLogic(INurseRepo repo)
        {
            _repo = repo;
        }

        public string AddNurse(Nurse nurse)
        {
            return _repo.AddNurse(nurse);
        }

        public IEnumerable<Nurse> GetAll()
        {
            return _repo.GetAllNurse();
        }

        public IEnumerable<Nurse> GetByEmail(string email)
        {
            return _repo.GetNurseByEmail(email);
        }
    }
}
