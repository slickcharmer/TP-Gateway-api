using EntityFrame.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrame
{
    public class EfRepo : IRepo
    {
        private readonly PatientHealthDbContext _PHdbcontext;
        public EfRepo(PatientHealthDbContext pHdbcontext)
        {
            _PHdbcontext = pHdbcontext;
        }

        public PatientBasicRecord AddBRecord(PatientBasicRecord record)
        {
            _PHdbcontext.Add(record);
            _PHdbcontext.SaveChanges();
            return record;
        }
        public PatientHealthRecord AddHRecord(PatientHealthRecord record)
        {
            _PHdbcontext.Add(record);
            _PHdbcontext.SaveChanges();
            return record;
        }

        public PatientMedication AddMRecord(PatientMedication medication)
        {
            _PHdbcontext.Add(medication);
            _PHdbcontext.SaveChanges();
            return medication;
        }
        public PatientTest AddTrecord(PatientTest test)
        {
            _PHdbcontext.Add(test);
            _PHdbcontext.SaveChanges();
            return test;
        }
        public PatientAllergy AddAReport(PatientAllergy report)
        {
            _PHdbcontext.Add(report);
            _PHdbcontext.SaveChanges();
            return report;
        }

        public IEnumerable<AllBasicDetails> GetBasicRecords()
        {
            var brdetails = _PHdbcontext.PatientBasicRecords;
            var padetails = _PHdbcontext.PatientAllergies;

            var alldetails = (from b in brdetails
                              join p in padetails on b.PatientId equals p.HealthId
                              select new AllBasicDetails()
                              {
                                  Id = (Guid)b.Id,
                                  Date_Time = (DateTime)b.DateTime,
                                  Patient_Id = b.PatientId,
                                  Nurse_Id = b.NurseId,
                                  Appointment_Id = b.AppointmentId,
                                  Bp = b.Bp,
                                  Heart_Rate = (int)b.HeartRate,
                                  SpO2 = b.SpO2,
                                  Height = b.Height,
                                  Weight = b.Weight,
                                  BloodGroup = b.BloodGroup,
                                  Temperature = b.Temperature,
                                  Health_Id = p.HealthId,
                                  Allergy = p.Allergy

                              });
            return alldetails.ToList();
        }

        public IEnumerable<AllHealthDetails> GetHealthRecords()
        {
            var phr = _PHdbcontext.PatientHealthRecords;
            var pm = _PHdbcontext.PatientMedications;
            var pt = _PHdbcontext.PatientTests;

            var alldata = (from h in phr
                           join m in pm on h.Id equals m.HealthId
                           join t in pt on h.Id equals t.HealthId
                           select new AllHealthDetails()
                           {
                               Id = h.Id,
                               Date_Time = (DateTime)h.DateTime,
                               Patient_Id = h.PatientId,
                               Doctor_Id = h.DoctorId,
                               Health_Id = (Guid)m.HealthId,
                               AppointmentId = h.AppointmentId,
                               Drugs = m.Drug,
                               Test = t.Test,
                               Result = t.Result,
                               Conclusion = h.Conclusion
                           });
            return alldata.ToList();
        }

        public List<Entities.PatientBasicRecord> GetAllBasicRecords()
        {
            return _PHdbcontext.PatientBasicRecords.ToList();
        }

        public Entities.PatientBasicRecord UpdateBasicRecord(Entities.PatientBasicRecord br)
        {
            _PHdbcontext.PatientBasicRecords.Update(br);
            _PHdbcontext.SaveChanges();
            return br;
        }

        public List<PatientAllergy> GetAllAllergy()
        {
            return _PHdbcontext.PatientAllergies.ToList();
        }

        public List<PatientHealthRecord> GetAllHealthRecords()
        {
            return _PHdbcontext.PatientHealthRecords.ToList();
        }

        public List<PatientMedication> GetAllMedication()
        {
            return _PHdbcontext.PatientMedications.ToList();
        }

        public List<PatientTest> GetAllTestRecords()
        {
            return _PHdbcontext.PatientTests.ToList();
        }

        public PatientAllergy UpdateAllergy(PatientAllergy record)
        {
            _PHdbcontext.PatientAllergies.Update(record);
            _PHdbcontext.SaveChanges();
            return record;
        }

        public PatientHealthRecord UpdateHealthRecord(PatientHealthRecord record)
        {
            _PHdbcontext.PatientHealthRecords.Update(record);
            _PHdbcontext.SaveChanges();
            return record;
        }

        public PatientMedication UpdateMedication(PatientMedication medication)
        {
            _PHdbcontext.PatientMedications.Update(medication);
            _PHdbcontext.SaveChanges();
            return medication;
        }

        public PatientTest UpdateTest(PatientTest test)
        {
            _PHdbcontext.PatientTests.Update(test);
            _PHdbcontext.SaveChanges();
            return test;
        }
    }
}
