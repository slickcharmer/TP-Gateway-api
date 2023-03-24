using System;
using System.Collections.Generic;

namespace DataLayer.Entities;

public partial class Appointment
{
    public Guid AppointmentId { get; set; }

    public string? PatientId { get; set; }

    public string? DoctorId { get; set; }

    public string? NurseId { get; set; }

    public short? Status { get; set; }

    public string? Date { get; set; }
}
