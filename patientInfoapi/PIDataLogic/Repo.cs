using PIDataLogic.Entities;
using Microsoft.Identity.Client;
using Models;

namespace DataLogic
{
    public class Repo : IRepo
    {
            PatientInfoServiceDbContext _context = new PatientInfoServiceDbContext();    
            public Repo(PatientInfoServiceDbContext context)
            {
                _context = context;
            }

        public string AddnewPatientInfo(Patientinfo patientinfo)
        {
            bool flag = false;
            if (_context.Patientinfos.Where(p => p.Email == patientinfo.Email).Any())  flag = true;
            else flag = false;
            if(!flag)
            {
                _context.Patientinfos.Add(patientinfo);
                _context.SaveChanges();
                return "1";
            }
            return "-1";
        }

        public IEnumerable<PatientInfo> GetallPatientinfos()
        {
            var patient =  _context.Patientinfos;
            var patient_info = (
                from pr in patient
                select new PatientInfo()
                {
                    PatId = pr.PatId,
                    Fullname = pr.Fullname,
                    Age = pr.Age,
                    Gender = pr.Gender,
                    Email= pr.Email,
                    Pasword = pr.Pasword,
                    Phone = pr.Phone,
                    AdressLine = pr.AdressLine,
                    City = pr.City,
                    State  = pr.State,
                    Created = pr.Created,
                }
                
                );
            return patient_info.ToList();

        }

        public IEnumerable<PatientInfo> GetPatientinfosbyemail(string Email)
        {
            var patient = _context.Patientinfos;
            var patient_info = (
                from pr in patient where pr.Email == Email
                select new PatientInfo()
                {
                    PatId = pr.PatId,
                    Fullname = pr.Fullname,
                    Age = pr.Age,
                    Gender = pr.Gender,
                    Email = pr.Email,
                    Pasword = pr.Pasword,
                    Phone = pr.Phone,
                    AdressLine = pr.AdressLine,
                    City = pr.City,
                    State = pr.State,
                    Created = pr.Created
                }

                );
            return patient_info.ToList();


        }

        public PatientInfo GetPatientinfosbyId(Guid id)
        {
            var patient = _context.Patientinfos;
            var patient_info = (
                from pr in patient
                where pr.PatId == id
                select new PatientInfo()
                {
                    PatId = pr.PatId,
                    Fullname = pr.Fullname,
                    Age = pr.Age,
                    Gender = pr.Gender,
                    Email = pr.Email,
                    Pasword = pr.Pasword,
                    Phone = pr.Phone,
                    AdressLine = pr.AdressLine,
                    City = pr.City,
                    State = pr.State,
                    Created = pr.Created
                }

                );
            return patient_info.First();


        }

        public PatientInfo updatePatientinfos(Guid Pat_id, Patientinfo patientinfo)
        {
            PatientInfo info = new PatientInfo() ;
            var patient = _context.Patientinfos.Where(pat => pat.PatId == Pat_id).FirstOrDefault();
            if (patient != null)
            {
                if ((patientinfo.Fullname != null && patientinfo.Fullname != "string") && patient.Fullname != patientinfo.Fullname)
                {
                    patient.Fullname = patientinfo.Fullname;
                }
                if ((patientinfo.Age != null && patientinfo.Age != 0) && patient.Age != patientinfo.Age)
                {
                    patient.Age = patientinfo.Age;
                }
                if ((patientinfo.Gender != null && patientinfo.Gender != "string") && patient.Gender != patientinfo.Gender)
                {
                    patient.Gender = patientinfo.Gender;
                }
                if ((patientinfo.AdressLine != null && patientinfo.AdressLine != "string") && patient.AdressLine != patientinfo.AdressLine)
                {
                    patient.AdressLine = patientinfo.AdressLine;
                }
                if ((patientinfo.Phone != null && patientinfo.Phone != 0) && patient.Phone != patientinfo.Phone)
                {
                    patient.Phone = patientinfo.Phone;
                }
                if ((patientinfo.State != null && patientinfo.State != "string") && patient.State != patientinfo.State)
                {
                    patient.State = patientinfo.State;
                }
                if ((patientinfo.City != null && patientinfo.City != "string") && patient.City != patientinfo.City)
                {
                    patient.City = patientinfo.City;
                }
                if ((patientinfo.Created != null && patientinfo.Created != "string") && patient.Created != patientinfo.Created)
                {
                    patient.Created = patientinfo.Created;
                }
            }
             _context.Patientinfos.Update(patient);
            _context.SaveChanges();
            return info;
        }

       
    }
}