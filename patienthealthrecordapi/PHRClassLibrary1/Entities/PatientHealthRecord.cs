using System;
using System.Collections.Generic;

namespace EntityFrame.Entities;

public partial class PatientHealthRecord
{
    public Guid Id { get; set; }

    public DateTime? DateTime { get; set; }

    public string? PatientId { get; set; }

    public string? DoctorId { get; set; }

    public string? AppointmentId { get; set; }

    public string? Conclusion { get; set; }

    public virtual ICollection<PatientMedication> PatientMedications { get; } = new List<PatientMedication>();

    public virtual ICollection<PatientTest> PatientTests { get; } = new List<PatientTest>();
}
