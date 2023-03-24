using System;
using System.Collections.Generic;

namespace PatientFluentApi.Entities;

public partial class PatientLogin
{
    public string LoginId { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;
}
