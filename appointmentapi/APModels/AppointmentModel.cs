namespace Models
{
    public class AppointmentModel
    {
        public Guid AppointmentId { get; set; }

        public string? PatientId { get; set; }

        public string? DoctorId { get; set; }

        public string? NurseId { get; set; }

        public short? Status { get; set; }

        public string? Date { get; set; }


    }
}