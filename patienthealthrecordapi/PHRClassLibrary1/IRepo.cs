using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrame
{
    public interface IRepo
    {
        Entities.PatientBasicRecord AddBRecord(Entities.PatientBasicRecord record);
        Entities.PatientHealthRecord AddHRecord(Entities.PatientHealthRecord record);
        Entities.PatientMedication AddMRecord(Entities.PatientMedication medication);
        Entities.PatientTest AddTrecord(Entities.PatientTest test);
        Entities.PatientAllergy AddAReport(Entities.PatientAllergy record);

        IEnumerable<AllBasicDetails> GetBasicRecords();

        IEnumerable<AllHealthDetails> GetHealthRecords();

        List<Entities.PatientBasicRecord> GetAllBasicRecords();

        List<Entities.PatientAllergy> GetAllAllergy();
        List<Entities.PatientHealthRecord> GetAllHealthRecords();
        List<Entities.PatientMedication> GetAllMedication();
        List<Entities.PatientTest> GetAllTestRecords();


        Entities.PatientBasicRecord UpdateBasicRecord(Entities.PatientBasicRecord record);
        Entities.PatientAllergy UpdateAllergy(Entities.PatientAllergy record);
        Entities.PatientHealthRecord UpdateHealthRecord(Entities.PatientHealthRecord record);
        Entities.PatientMedication UpdateMedication(Entities.PatientMedication medication);
        Entities.PatientTest UpdateTest(Entities.PatientTest test);
    }
}
