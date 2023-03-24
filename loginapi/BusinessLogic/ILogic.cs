using PatientFluentApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public interface ILogic
    {

        public PatientLogin AddPatient(PatientLogin patientLogin);

        public PatientLogin UpdatePatient(PatientLogin patientLogin);

        public PatientLogin DeletePatient(string email);

        public string GetPatient(string email, string password);
    }
}
