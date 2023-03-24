using DataLogic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
namespace DataLogic
{
    public interface IRepo
    {
        public IEnumerable<PatientInfo> GetallPatientinfos();
        public IEnumerable<PatientInfo> GetPatientinfosbyemail(string Email);
        public void AddnewPatientInfo(Patientinfo patientinfo);
        public PatientInfo updatePatientinfos( Guid Pat_id, Patientinfo patientinfo);
    }
}
