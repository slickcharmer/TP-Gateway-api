using DataLogic.Entities;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLogic
{
    public interface ILogic
    {
        public IEnumerable<PatientInfo> GetallPatientinfos();
        public IEnumerable<PatientInfo> GetPatientDetailsByemail(string Email);
       
       public void AddnewPatientInfo(Patientinfo patientInfo);
        public PatientInfo updatePatientinfos(Guid Pat_id, Patientinfo patientinfo);

    }
}
