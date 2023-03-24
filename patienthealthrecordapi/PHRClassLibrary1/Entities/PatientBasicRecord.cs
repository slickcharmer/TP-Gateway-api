using System;
using System.Collections.Generic;

namespace EntityFrame.Entities;

public partial class PatientBasicRecord
{
    public Guid? Id { get; set; }

    public DateTime? DateTime { get; set; }

    public string PatientId { get; set; } = null!;

    public string? NurseId { get; set; }

    public string? AppointmentId { get; set; }

    public string? Bp { get; set; }

    public int? HeartRate { get; set; }

    public string? SpO2 { get; set; }

    public string? Weight { get; set; }

    public string? Height { get; set; }

    public string? BloodGroup { get; set; }

    public string? Temperature { get; set; }

    public virtual ICollection<PatientAllergy> PatientAllergies { get; } = new List<PatientAllergy>();
}
