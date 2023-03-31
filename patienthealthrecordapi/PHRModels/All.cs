namespace PHRModels
{
    public class All
    {
        public IEnumerable<Models.Patient_Basic_Record> Basics { get; set; }
        public IEnumerable<Models.Patient_Health_Record> Detailed { get; set; }
        public IEnumerable<Models.Patient_Test> Tests { get; set; }
        public IEnumerable<Models.Patient_Medication> Drugs { get; set; }
        public IEnumerable<Models.Patient_Allergy> Allergy { get; set; }
    }
}
