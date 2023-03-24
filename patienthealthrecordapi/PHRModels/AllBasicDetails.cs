namespace Models
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

        public string AllBasicDetailRecords()
        {
            return $@"Date Time: {Date_Time}\n,Patient_Id: {Patient_Id}\n,Appointment_Id: {Appointment_Id}\n,Nurse_Id: {Nurse_Id}\n,Bp: {Bp}\n,HeartRate: {Heart_Rate}\n,Spo2: {SpO2}\n,HealthId: {Health_Id}\n,Height: {Height}\n,Weight: {Weight}\n,BloodGroup:{BloodGroup}\n,Temparature:{Temperature}\n,Allergy: {Allergy}\n";
        }

    }
}