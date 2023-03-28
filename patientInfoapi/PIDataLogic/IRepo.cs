using DataLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using PIDataLogic.Entities;
namespace DataLogic
{
    public interface IRepo
    {
        public IEnumerable<PatientInfo> GetallPatientinfos();
        public IEnumerable<PatientInfo> GetPatientinfosbyemail(string Email);

        public PatientInfo GetPatientinfosbyId(Guid id);
        public string AddnewPatientInfo(Patientinfo patientinfo);
        public PatientInfo updatePatientinfos( Guid Pat_id, Patientinfo patientinfo);
    }
}
