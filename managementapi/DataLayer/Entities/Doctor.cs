using System;
using System.Collections.Generic;

namespace DataLayer.Entities;

public partial class Doctor
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? Gender { get; set; }

    public string? Specialization { get; set; }

    public string? ImgUrl { get; set; }

    public int? Experience { get; set; }

    public long? PhoneNo { get; set; }
}
