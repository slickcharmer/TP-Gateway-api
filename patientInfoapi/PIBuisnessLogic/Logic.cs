using DataLogic;
using DataLogic.Entities;
using Models;

namespace BuisnessLogic
{
    public class Logic : ILogic
    {
        Mapper _mapper = new Mapper();
        IRepo _repo;
        public Logic( IRepo repo)
        { 
            _repo = repo;
        }

        public void AddnewPatientInfo(Patientinfo patientInfo)
        {
            _repo.AddnewPatientInfo(patientInfo);
        }

        public IEnumerable<PatientInfo> GetallPatientinfos()
        {
           return  _repo.GetallPatientinfos();
        }

        public IEnumerable<PatientInfo> GetPatientDetailsByemail(string Email)
        {
            return _repo.GetPatientinfosbyemail(Email);
        }

        public PatientInfo updatePatientinfos(Guid Pat_id, Patientinfo patientinfo)
        {
            return _repo.updatePatientinfos(Pat_id, patientinfo);
        }
    }
}