using System;
using System.Collections.Generic;

namespace EntityFrame.Entities;

public partial class PatientAllergy
{
    public Guid Id { get; set; }

    public string? HealthId { get; set; }

    public string? AppointmentId { get; set; }

    public string? Allergy { get; set; }

    public virtual PatientBasicRecord? Health { get; set; }
}
