using EntityFrame;
using PHREntityFrame.Entities;
using PHRModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PHRModels;

namespace EntityFrame
{
    public class EfRepo : IRepo
    {
        private readonly PatientHealthDbContext _PHdbcontext;
        public EfRepo(PatientHealthDbContext pHdbcontext)
        {
            _PHdbcontext = pHdbcontext;
        }


        public List<PHREntityFrame.Entities.PatientAllergy> getAllergyByPID(string id, string AID)
        {
            List<PHREntityFrame.Entities.PatientAllergy> list = new();
            var br = _PHdbcontext.PatientAllergies;
            var res = (from b in br
                       where b.HealthId == id && b.AppointmentId == AID
                       select b);
            foreach (var item in res)
            {
                list.Add(item);
            }
            return res.ToList();
        }

        public List<PHREntityFrame.Entities.PatientBasicRecord> getBasicByPID(string id)
        {
            List<PHREntityFrame.Entities.PatientBasicRecord> list = new();
            var br = _PHdbcontext.PatientBasicRecords;
            var res = (from b in br
                       where b.PatientId == id
                       select b);
            foreach (var item in res)
            {
                list.Add(item);
            }
            return res.ToList();
        }

        public List<PHREntityFrame.Entities.PatientMedication> getMedByPID(string id, string AID)
        {
            List<PHREntityFrame.Entities.PatientMedication> list = new();
            var br = _PHdbcontext.PatientMedications;
            var res = (from b in br
                       where b.HealthId == id && b.AppointmentId == AID
                       select b);
            foreach (var item in res)
            {
                list.Add(item);
            }
            return res.ToList();
        }

        public List<PHREntityFrame.Entities.PatientTest> getTestByPID(string id, string AID)
        {
            List<PHREntityFrame.Entities.PatientTest> list = new();
            var br = _PHdbcontext.PatientTests;
            var res = (from b in br
                       where b.HealthId == id && b.AppointmentId == AID
                       select b);
            foreach (var item in res)
            {
                list.Add(item);
            }
            return res.ToList();
        }

        public List<PHREntityFrame.Entities.PatientHealthRecord> getHealthByPID(string id)
        {
            List<PHREntityFrame.Entities.PatientHealthRecord> list = new();
            var br = _PHdbcontext.PatientHealthRecords;
            var res = (from b in br
                       where b.PatientId == id
                       select b);
            foreach (var item in res)
            {
                list.Add(item);
            }
            return res.ToList();
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
                              join p in padetails on b.AppointmentId equals p.AppointmentId
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
                           join m in pm on h.AppointmentId equals m.AppointmentId
                           join t in pt on h.AppointmentId equals t.AppointmentId
                           select new AllHealthDetails()
                           {
                               Conclusion = h.Conclusion,
                               Id = (Guid)h.Id,
                               Date_Time = h.DateTime,
                               Patient_Id = h.PatientId,
                               Doctor_Id = h.DoctorId,
                               Health_Id = m.HealthId,
                               AppointmentId = h.AppointmentId,
                               Drugs = m.Drug,
                               Quantity = m.Quantity,
                               Test = t.Test,
                               Result = t.Result,
                           });
            return alldata.ToList();
        }

        public List<PatientBasicRecord> GetAllBasicRecords()
        {
            return _PHdbcontext.PatientBasicRecords.ToList();
        }

        public PatientBasicRecord UpdateBasicRecord(PatientBasicRecord br)
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

        public List<All> GetAll(string pid)
        {
            var hr = _PHdbcontext.PatientHealthRecords;
            var tr = _PHdbcontext.PatientTests;
            var mr = _PHdbcontext.PatientMedications;
            var ar = _PHdbcontext.PatientAllergies;
            var br = _PHdbcontext.PatientBasicRecords;
            var res = (from h in hr
                       where h.PatientId == pid
                       select new PHRModels.All()
                       {
                           MoreInfo = (from hh in hr
                                       where hh.PatientId == h.PatientId && hh.AppointmentId == h.AppointmentId
                                       select new Models.Patient_Health_Record()
                                       {
                                           Doctor_Id = hh.DoctorId,
                                           Date_Time = hh.DateTime,
                                           Conclusion = hh.Conclusion,
                                           Appointment_Id = hh.AppointmentId,
                                       }).ToList(),
                           Allergys = (from a in ar
                                       where a.HealthId == h.PatientId && a.AppointmentId == h.AppointmentId
                                       select new Models.Patient_Allergy()
                                       {
                                           Allergy = a.Allergy,
                                           Appointment_Id = a.AppointmentId
                                       }).ToList(),
                           Basic = (from b in br
                                    where b.PatientId == h.PatientId && b.AppointmentId == h.AppointmentId
                                    select new Models.Patient_Basic_Record() {
                                        Date_Time = b.DateTime,
                                        Appointment_Id = b.AppointmentId,
                                        Bp = b.Bp,
                                        Heart_Rate = (int)b.HeartRate,
                                        SpO2 = b.SpO2,
                                        Height = b.Height,
                                        Weight = b.Weight,
                                        BloodGroup = b.BloodGroup,
                                        Temperature = b.Temperature,
                                    }).ToList(),
                           Tests = (from t in tr
                                    where t.HealthId == h.PatientId && t.AppointmentId == h.AppointmentId
                                    select new Models.Patient_Test()
                                    {
                                        Test = t.Test,
                                        Result = t.Result,
                                        Appointment_Id = t.AppointmentId
                                    }).ToList(),
                           Drugs = (from m in mr
                                    where m.HealthId == h.PatientId && m.AppointmentId == h.AppointmentId
                                    select new Models.Patient_Medication()
                                    {
                                        Drugs = m.Drug,
                                        Quantity = m.Quantity,
                                        Appointment_Id = m.AppointmentId
                                    }).ToList(),
                       }).ToList();
            return res;
        }

        public List<PHRModels.BasicsAll> BasicsAlls(string pid, string aid)
        {
            var ar = _PHdbcontext.PatientAllergies;
            var br = _PHdbcontext.PatientBasicRecords;
            var res = (from b in br
                       where b.PatientId == pid && b.AppointmentId == aid
                       select new PHRModels.BasicsAll()
                       {
                           DateTime = b.DateTime,
                           PatientId = b.PatientId,
                           AppointmentId = b.AppointmentId,
                           Bp = b.Bp,
                           HeartRate = b.HeartRate,
                           SpO2 = b.SpO2,
                           Height = b.Height,
                           Weight = b.Weight,
                           BloodGroup = b.BloodGroup,
                           Temperature = b.Temperature,

                           Allergies = (from a in ar
                                        where a.HealthId == b.PatientId && a.AppointmentId == b.AppointmentId
                                        select new Models.Patient_Allergy()
                                        {
                                            Allergy = a.Allergy,
                                            Appointment_Id = a.AppointmentId,
                                            Health_Id = a.HealthId,
                                        }).ToList()
                       }).ToList();
            return res;
        }
    }
}
