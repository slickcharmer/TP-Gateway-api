namespace EntityFrame
{
    public class AllBasicDetails
    {
        public AllBasicDetails()
        {

        }
        public Guid Id { get; set; }
        public DateTime Date_Time { get; set; }
        public string Patient_Id { get; set; }
        public string Nurse_Id { get; set; }

        public string Appointment_Id { get; set; }
        public string Bp { get; set; }
        public int Heart_Rate { get; set; }
        public string SpO2 { get; set; }
        public string Health_Id { get; set; }
        public string Allergy { get; set; }

        public string Weight { get; set; }

        public string Height { get; set; }

        public string BloodGroup { get; set; }

        public string Temperature { get; set; }

    }
}