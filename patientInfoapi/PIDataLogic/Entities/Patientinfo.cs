using System;
using System.Collections.Generic;

namespace PIDataLogic.Entities;

public partial class Patientinfo
{
    public Guid PatId { get; set; }

    public string? Fullname { get; set; }

    public int? Age { get; set; }

    public string? Gender { get; set; }

    public string Email { get; set; } = null!;

    public string Pasword { get; set; } = null!;

    public long? Phone { get; set; }

    public string? AdressLine { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public string? Created { get; set; }
}
