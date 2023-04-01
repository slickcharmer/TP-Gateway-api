using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using PHRModels;

namespace BusinessLogic
{
    public interface ILogic
    {
        List<PHRModels.All> Alls(string pid);
        List<PHRModels.BasicsAll> Basics(string pid, string aid);

        List<PHREntityFrame.Entities.PatientHealthRecord> GetAllHR(string id);
        List<PHREntityFrame.Entities.PatientBasicRecord> GetAllBR(string id);
        List<PHREntityFrame.Entities.PatientTest> GetTRByAID(string id, string AID);
        List<PHREntityFrame.Entities.PatientMedication> GetMRByAID(string id, string AID);
        List<PHREntityFrame.Entities.PatientAllergy> GetARByAID(string id, string AID);




        /// <summary>
        /// Method to Add
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        Patient_Basic_Record AddBasicR(Patient_Basic_Record record);
        /// <summary>
        /// Add Health Record Data
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        Patient_Health_Record AddHealthR(Patient_Health_Record record);
        /// <summary>
        /// Add Medical Reports
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        Patient_Medication AddMedicalReport(Patient_Medication record);
        /// <summary>
        /// Add Test Report
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        Patient_Test AddTestReport(Patient_Test record);
        /// <summary>
        /// Add Allergy Reports
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        Patient_Allergy AddAllergyReport(Patient_Allergy record);
        /// <summary>
        /// This method is for to get all Patient basic details
        /// </summary>
        /// <returns></returns>

        IEnumerable<EntityFrame.AllBasicDetails> GetBasicDetail();
        /// <summary>
        /// Get Patient Basic details by id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        IEnumerable<EntityFrame.AllBasicDetails> GetById(string id);
        /// <summary>
        /// Get All Patients Health Details
        /// </summary>
        /// <returns></returns>

        IEnumerable<EntityFrame.AllHealthDetails> GetHealthDetails();
        /// <summary>
        /// Get Patient health details by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        IEnumerable<EntityFrame.AllHealthDetails> GetByHealthID(string id);

        /// <summary>
        /// Method to Update 
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        Patient_Basic_Record UpdateBR(string id, Patient_Basic_Record record);

        Models.Patient_Allergy UpdatePA(string id, Patient_Allergy record);

        Patient_Health_Record UpdateHealthR(string id, Patient_Health_Record record);
        Patient_Medication UpdateMedicalReport(string guid, Patient_Medication record);
        Patient_Test UpdatePatientTest(string id, Patient_Test record);
    }
}
