using System;
using System.Collections.Generic;

namespace AuditFluentApi.Entites;

public partial class Audit
{
    public Guid Id { get; set; }

    public string DateTime { get; set; } = null!;

    public string PatientId { get; set; } = null!;

    public string DoctorId { get; set; } = null!;

    public string AppointmentId { get; set; } = null!;

    public string HealthId { get; set; } = null!;

    public string? Conclusion { get; set; }

    public string? Drug { get; set; }

    public string? Test { get; set; }

    public string? Result { get; set; }
}
