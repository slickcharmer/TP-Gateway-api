using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;
using PHREntityFrame.Entities;

namespace BusinessLogic
{
    public class Mapper
    {
        public static Models.Patient_Basic_Record PbMap(PatientBasicRecord r)
        {
            return new Models.Patient_Basic_Record()
            {
                Id = (Guid?)r.Id,
                Date_Time = (DateTime?)r.DateTime,
                Patient_Id = r.PatientId,
                Nurse_Id = r.NurseId,
                Appointment_Id = r.AppointmentId,
                Bp = r.Bp,
                Heart_Rate = (int?)r.HeartRate,
                SpO2 = r.SpO2,
                Height = r.Height,
                Weight = r.Weight,
                BloodGroup = r.BloodGroup,
                Temperature = r.Temperature

            };
        }

        public static PatientBasicRecord PbMap(Models.Patient_Basic_Record r)
        {
            return new PatientBasicRecord()
            {
                Id = r.Id,
                DateTime = r.Date_Time,
                PatientId = r.Patient_Id,
                NurseId = r.Nurse_Id,
                AppointmentId = r.Appointment_Id,
                Bp = r.Bp,
                HeartRate = r.Heart_Rate,
                SpO2 = r.SpO2,
                Height = r.Height,
                Weight = r.Weight,
                BloodGroup = r.BloodGroup,
                Temperature = r.Temperature
            };
        }

        public static Models.Patient_Health_Record HrMap(PatientHealthRecord hr)
        {
            return new Models.Patient_Health_Record()
            {
                Id= (Guid?)hr.Id,
                Date_Time = hr.DateTime,
                Patient_Id = hr.PatientId,
                Doctor_Id = hr.DoctorId,
                Appointment_Id = hr.AppointmentId,
                Conclusion = hr.Conclusion
            };
        }

        public static PatientHealthRecord HrMap(Models.Patient_Health_Record hr)
        {
            return new PatientHealthRecord()
            {
                Id = hr.Id,
                DateTime = hr.Date_Time,
                PatientId = hr.Patient_Id,
                DoctorId = hr.Doctor_Id,
                AppointmentId = hr.Appointment_Id,
                Conclusion = hr.Conclusion
            };
        }
        public static Models.Patient_Medication MrMap(PatientMedication mr)
        {
            return new Models.Patient_Medication()
            {
                Id = mr.Id,
                Health_Id = mr.HealthId,
                Appointment_Id = mr.AppointmentId,
                Drugs = mr.Drug,
                Quantity = mr.Quantity
            };
        }

        public static PatientMedication MrMap(Models.Patient_Medication mr)
        {
            return new PatientMedication()
            {
                Id = mr.Id,
                HealthId = mr.Health_Id,
                AppointmentId = mr.Appointment_Id,
                Drug = mr.Drugs,
                Quantity = mr.Quantity
            };
        }
        public static Models.Patient_Test TMap(PatientTest tm)
        {
            return new Models.Patient_Test()
            {
                Id = tm.Id,
                Health_Id = tm.HealthId,
                Appointment_Id = tm.AppointmentId,
                Test = tm.Test,
                Result = tm.Result
            };
        }
        public static PatientTest TMap(Models.Patient_Test tm)
        {
            return new PatientTest
            {
                Id = tm.Id,
                HealthId = tm.Health_Id,
                AppointmentId = tm.Appointment_Id,
                Test = tm.Test,
                Result = tm.Result
            };
        }
        public static Models.Patient_Allergy AMap(PatientAllergy ar)
        {
            return new Models.Patient_Allergy()
            {
                Id = ar.Id,
                Health_Id = ar.HealthId,
                Appointment_Id = ar.AppointmentId,
                Allergy = ar.Allergy
            };
        }

        public static PatientAllergy AMap(Models.Patient_Allergy ar)
        {
            return new PatientAllergy()
            {
                Id = ar.Id,
                HealthId = ar.Health_Id,
                AppointmentId = ar.Appointment_Id,
                Allergy = ar.Allergy
            };
        }

        public static IEnumerable<Models.Patient_Basic_Record> PbMap(IEnumerable<PatientBasicRecord> records)
        {
            return records.Select(PbMap);
        }

        public static IEnumerable<Models.Patient_Health_Record> HrMap(IEnumerable<PatientHealthRecord> hr)
        {
            return hr.Select(HrMap);
        }

        public static IEnumerable<Models.Patient_Medication> MrMap(IEnumerable<PatientMedication> mr)
        {
            return mr.Select(MrMap);
        }

        public static IEnumerable<Models.Patient_Test> TMap(IEnumerable<PatientTest> tm)
        {
            return tm.Select(TMap);
        }
        public static IEnumerable<Models.Patient_Allergy> AMap(IEnumerable<PatientAllergy> ar)
        {
            return ar.Select(AMap);
        }
    }
}
