using System;
using System.Collections.Generic;

namespace PHREntityFrame.Entities;

public partial class PatientHealthRecord
{
    public Guid? Id { get; set; }

    public string? DateTime { get; set; }

    public string? PatientId { get; set; }

    public string? DoctorId { get; set; }

    public string AppointmentId { get; set; } = null!;

    public string? Conclusion { get; set; }
}
