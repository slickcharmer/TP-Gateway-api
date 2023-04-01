using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PHREntityFrame;
using PHREntityFrame.Entities;

namespace EntityFrame
{
    public interface IRepo
    {
        
        List<PHREntityFrame.Entities.PatientBasicRecord> getBasicByPID(string id);
        List<PHREntityFrame.Entities.PatientHealthRecord> getHealthByPID(string id);
        List<PHREntityFrame.Entities.PatientTest> getTestByPID(string id, string AID);
        List<PHREntityFrame.Entities.PatientMedication> getMedByPID(string id, string AID);
        List<PHREntityFrame.Entities.PatientAllergy> getAllergyByPID(string id, string AID);

        PatientBasicRecord AddBRecord(PatientBasicRecord record);
        PatientHealthRecord AddHRecord(PatientHealthRecord record);
        PatientMedication AddMRecord(PatientMedication medication);
        PatientTest AddTrecord(PatientTest test);
        PatientAllergy AddAReport(PatientAllergy record);

        IEnumerable<AllBasicDetails> GetBasicRecords();

        IEnumerable<AllHealthDetails> GetHealthRecords();

        List<PatientBasicRecord> GetAllBasicRecords();

        List<PatientAllergy> GetAllAllergy();
        List<PatientHealthRecord> GetAllHealthRecords();
        List<PatientMedication> GetAllMedication();
        List<PatientTest> GetAllTestRecords();


        PatientBasicRecord UpdateBasicRecord(PatientBasicRecord record);
        PatientAllergy UpdateAllergy(PatientAllergy record);
        PatientHealthRecord UpdateHealthRecord(PatientHealthRecord record);
        PatientMedication UpdateMedication(PatientMedication medication);
        PatientTest UpdateTest(PatientTest test);
    }
}
