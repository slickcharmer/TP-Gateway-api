namespace PHRModels
{
    public class All
    {
        /*public string doctorId { get; set; }
        public string date { get; set; }
        public string conclusion { get; set; }
        public string appointment_id { get; set; }*/
        public IEnumerable<Models.Patient_Health_Record>MoreInfo{ get; set; }
        public IEnumerable<Models.Patient_Test> Tests { get; set; }
        public IEnumerable<Models.Patient_Medication> Drugs { get; set; }
        public IEnumerable<Models.Patient_Allergy> Allergys { get; set; }
        public IEnumerable<Models.Patient_Basic_Record> Basic { get; set; }

    }

    public class BasicsAll
    {
        public DateTime? DateTime { get; set; }

        public string? PatientId { get; set; }

        public string AppointmentId { get; set; } = null!;

        public string? Bp { get; set; }

        public int? HeartRate { get; set; }

        public string? SpO2 { get; set; }

        public string? Weight { get; set; }

        public string? Height { get; set; }

        public string? BloodGroup { get; set; }

        public string? Temperature { get; set; }

        public IEnumerable<Models.Patient_Allergy> Allergies {get; set; }
    }
}
