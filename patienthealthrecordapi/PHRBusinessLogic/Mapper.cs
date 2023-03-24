using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;

namespace BusinessLogic
{
    public class Mapper
    {
        public static Models.Patient_Basic_Record PbMap(EntityFrame.Entities.PatientBasicRecord r)
        {
            return new Models.Patient_Basic_Record()
            {
                Id = (Guid)r.Id,
                Date_Time = (DateTime)r.DateTime,
                Patient_Id = r.PatientId,
                Nurse_Id = r.NurseId,
                Appointment_Id = r.AppointmentId,
                Bp = r.Bp,
                Heart_Rate = (int)r.HeartRate,
                SpO2 = r.SpO2,
                Height = r.Height,
                Weight = r.Weight,
                BloodGroup = r.BloodGroup,
                Temperature = r.Temperature

            };
        }

        public static EntityFrame.Entities.PatientBasicRecord PbMap(Models.Patient_Basic_Record r)
        {
            return new EntityFrame.Entities.PatientBasicRecord()
            {
                Id = r.Id,
                DateTime = r.Date_Time,
                PatientId = r.Patient_Id,
                NurseId = r.Nurse_Id,
                AppointmentId = r.Appointment_Id,
                Bp = Validation.IsValidBP(r.Bp),
                HeartRate = r.Heart_Rate,
                SpO2 = r.SpO2,
                Height = r.Height,
                Weight = r.Weight,
                BloodGroup = r.BloodGroup,
                Temperature = r.Temperature
            };
        }

        public static Models.Patient_Health_Record HrMap(EntityFrame.Entities.PatientHealthRecord hr)
        {
            return new Models.Patient_Health_Record()
            {
                Id = hr.Id,
                Date_Time = (DateTime)hr.DateTime,
                Patient_Id = hr.PatientId,
                Doctor_Id = hr.DoctorId,
                Appointment_Id = hr.AppointmentId,
                Conclusion = hr.Conclusion
            };
        }

        public static EntityFrame.Entities.PatientHealthRecord HrMap(Models.Patient_Health_Record hr)
        {
            return new EntityFrame.Entities.PatientHealthRecord()
            {
                Id = hr.Id,
                DateTime = hr.Date_Time,
                PatientId = hr.Patient_Id,
                DoctorId = hr.Doctor_Id,
                AppointmentId = hr.Appointment_Id,
                Conclusion = hr.Conclusion
            };
        }
        public static Models.Patient_Medication MrMap(EntityFrame.Entities.PatientMedication mr)
        {
            return new Models.Patient_Medication()
            {
                Id = mr.Id,
                Health_Id = (Guid)mr.HealthId,
                Appointment_Id = mr.AppointmentId,
                Drugs = mr.Drug
            };
        }

        public static EntityFrame.Entities.PatientMedication MrMap(Models.Patient_Medication mr)
        {
            return new EntityFrame.Entities.PatientMedication()
            {
                Id = mr.Id,
                HealthId = mr.Health_Id,
                AppointmentId = mr.Appointment_Id,
                Drug = mr.Drugs
            };
        }
        public static Models.Patient_Test TMap(EntityFrame.Entities.PatientTest tm)
        {
            return new Models.Patient_Test()
            {
                Id = tm.Id,
                Health_Id = (Guid)tm.HealthId,
                Appointment_Id = tm.AppointmentId,
                Test = tm.Test,
                Result = tm.Result
            };
        }
        public static EntityFrame.Entities.PatientTest TMap(Models.Patient_Test tm)
        {
            return new EntityFrame.Entities.PatientTest
            {
                Id = tm.Id,
                HealthId = tm.Health_Id,
                AppointmentId = tm.Appointment_Id,
                Test = tm.Test,
                Result = tm.Result
            };
        }
        public static Models.Patient_Allergy AMap(EntityFrame.Entities.PatientAllergy ar)
        {
            return new Models.Patient_Allergy()
            {
                Id = ar.Id,
                Health_Id = ar.HealthId,
                Appointment_Id = ar.AppointmentId,
                Allergy = ar.Allergy
            };
        }

        public static EntityFrame.Entities.PatientAllergy AMap(Models.Patient_Allergy ar)
        {
            return new EntityFrame.Entities.PatientAllergy()
            {
                Id = ar.Id,
                HealthId = ar.Health_Id,
                AppointmentId = ar.Appointment_Id,
                Allergy = ar.Allergy
            };
        }

        public static IEnumerable<Models.Patient_Basic_Record> PbMap(IEnumerable<EntityFrame.Entities.PatientBasicRecord> records)
        {
            return records.Select(PbMap);
        }

        public static IEnumerable<Models.Patient_Health_Record> HrMap(IEnumerable<EntityFrame.Entities.PatientHealthRecord> hr)
        {
            return hr.Select(HrMap);
        }

        public static IEnumerable<Models.Patient_Medication> MrMap(IEnumerable<EntityFrame.Entities.PatientMedication> mr)
        {
            return mr.Select(MrMap);
        }

        public static IEnumerable<Models.Patient_Test> TMap(IEnumerable<EntityFrame.Entities.PatientTest> tm)
        {
            return tm.Select(TMap);
        }
        public static IEnumerable<Models.Patient_Allergy> AMap(IEnumerable<EntityFrame.Entities.PatientAllergy> ar)
        {
            return ar.Select(AMap);
        }
    }
}
