using System;
using System.Collections.Generic;

namespace PHREntityFrame.Entities;

public partial class PatientMedication
{
    public Guid Id { get; set; }

    public string? HealthId { get; set; }

    public string? AppointmentId { get; set; }

    public string? Drug { get; set; }

    public string? Quantity { get; set; }

    public virtual PatientHealthRecord? Appointment { get; set; }
}
