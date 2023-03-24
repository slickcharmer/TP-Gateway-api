using EntityFrame;
using Models;

namespace BusinessLogic
{
    public class Logic : ILogic
    {
        IRepo _repo;
        public Logic(IRepo repo)
        {
            _repo = repo;
        }

        public Patient_Basic_Record AddBasicR(Patient_Basic_Record record)
        {
            return Mapper.PbMap(_repo.AddBRecord(Mapper.PbMap(record)));
        }
        public Patient_Health_Record AddHealthR(Patient_Health_Record record)
        {
            return Mapper.HrMap(_repo.AddHRecord(Mapper.HrMap(record)));
        }

        public Patient_Medication AddMedicalReport(Patient_Medication record)
        {
            return Mapper.MrMap(_repo.AddMRecord(Mapper.MrMap(record)));
        }

        public Patient_Test AddTestReport(Patient_Test record)
        {
            return Mapper.TMap(_repo.AddTrecord(Mapper.TMap(record)));
        }
        public Patient_Allergy AddAllergyReport(Patient_Allergy record)
        {
            return Mapper.AMap(_repo.AddAReport(Mapper.AMap(record)));
        }

        public IEnumerable<EntityFrame.AllBasicDetails> GetBasicDetail()
        {
            return _repo.GetBasicRecords();
        }

        public EntityFrame.AllBasicDetails GetById(string id)
        {
            var search = _repo.GetBasicRecords().Where(r => r.Patient_Id == id).FirstOrDefault();
            return search;
        }

        public IEnumerable<EntityFrame.AllHealthDetails> GetHealthDetails()
        {
            return _repo.GetHealthRecords();
        }

        public EntityFrame.AllHealthDetails GetByHealthID(string id)
        {
            var search = _repo.GetHealthRecords().Where(r => r.Patient_Id == id).FirstOrDefault();
            return search;
        }

        public Patient_Basic_Record UpdateBR(string id, Patient_Basic_Record record)
        {
            var s = (from r in _repo.GetAllBasicRecords()
                     where r.PatientId == id
                     select r).FirstOrDefault();
            if (s != null)
            {
                s.DateTime = record.Date_Time;
                s.NurseId = record.Nurse_Id;
                s.AppointmentId = record.Appointment_Id;
                s.Bp = record.Bp;
                s.HeartRate = record.Heart_Rate;
                s.SpO2 = record.SpO2;
                s.Height= record.Height;
                s.Weight = record.Weight;
                s.BloodGroup= record.BloodGroup;
                s.Temperature= record.Temperature;

                s = _repo.UpdateBasicRecord(s);
            }
            if (s == null)
            {
                throw new Exception("Record Not Found");
            }
            return Mapper.PbMap(s);
        }

        public Models.Patient_Allergy UpdatePA(string id, Patient_Allergy record)
        {
            var s = (from r in _repo.GetAllAllergy()
                     where r.HealthId == id
                     select r).FirstOrDefault();
            if (s != null)
            {
                s.Allergy = record.Allergy;
                s.AppointmentId = record.Appointment_Id;

                s = _repo.UpdateAllergy(s);
            }
            if (s == null)
            {
                throw new Exception("Record Not Found");
            }
            return Mapper.AMap(s);
        }

        public Patient_Health_Record UpdateHealthR(string id, Patient_Health_Record record)
        {
            var s = (from r in _repo.GetAllHealthRecords()
                     where r.PatientId == id
                     select r).FirstOrDefault();
            if (s != null)
            {
                s.DateTime = record.Date_Time;
                s.PatientId = record.Patient_Id;
                s.DoctorId = record.Doctor_Id;
                s.AppointmentId = record.Appointment_Id;
                s.Conclusion = record.Conclusion;

                s = _repo.UpdateHealthRecord(s);
            }
            if (s == null)
            {
                throw new Exception("Record Not Found");
            }
            return Mapper.HrMap(s);
        }

        public Patient_Medication UpdateMedicalReport(string id, Patient_Medication record)
        {
            var z = (from r in _repo.GetAllHealthRecords()
                     where r.PatientId == id
                     select r).FirstOrDefault();

            var s = (from r in _repo.GetAllMedication()
                     where r.HealthId == z.Id
                     select r).FirstOrDefault();
            if (s != null)
            {
                s.Drug = record.Drugs;
                s.AppointmentId = record.Appointment_Id;

                s = _repo.UpdateMedication(s);
            }
            if (s == null)
            {
                throw new Exception("Record Not Found");
            }
            return Mapper.MrMap(s); ;
        }

        public Patient_Test UpdatePatientTest(string id, Patient_Test record)
        {
            var z = (from r in _repo.GetAllHealthRecords()
                     where r.PatientId == id
                     select r).FirstOrDefault();
            var s = (from r in _repo.GetAllTestRecords()
                     where r.HealthId == z.Id
                     select r).FirstOrDefault();
            if (s != null)
            {
                s.Test = record.Test;
                s.Result = record.Result;
                s.AppointmentId = record.Appointment_Id;

                s = _repo.UpdateTest(s);
            }
            if (s == null)
            {
                throw new Exception("Record Not Found");
            }
            return Mapper.TMap(s); ;
        }

    }
}