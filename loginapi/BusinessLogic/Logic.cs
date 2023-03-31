using Models;
using PatientFluentApi.Entities;
using System.Linq;

namespace BusinessLogic
{
    public class Logic : ILogic
    {
        IRepo<PatientLogin> repo;
        public Logic(IRepo<PatientLogin> repo) 
        {
            this.repo = repo;
        }
        public PatientLogin AddPatient(PatientLogin patientLogin)
        {
            Guid guid= Guid.NewGuid();
            patientLogin.LoginId = guid.ToString();
            var res = repo.Add(patientLogin);
            if (res == "1") return patientLogin;
            else return null;
        }

        public PatientLogin UpdatePatient(PatientLogin patientLogin) 
        {
            var oldPatient = repo.Get().Where(x => x.Email == patientLogin.Email).FirstOrDefault();
            if (oldPatient != null)
            {
                oldPatient.Password = patientLogin.Password;
                repo.Update(oldPatient);
            }
            return oldPatient;
        }

        public PatientLogin DeletePatient(string email)
        {
            var oldPatient = repo.Get().Where(x => x.Email == email).FirstOrDefault();
            repo.Delete(oldPatient);
            return oldPatient;
        }

        public string GetPatient(string email, string password) 
        {
            /* var patients = repo.Get().Where(x => x.Email == email && x.Password == password).FirstOrDefault();
             if(patients is null)
             {
                 return "false";
             }
             return "true";*/
            var res = repo.GetOne(email, password);
            if (res == "1") return "1";
            else return "0";

        }
    }
}