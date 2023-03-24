using System;
using System.Collections.Generic;

namespace DataLayer.Entities;

public partial class Nurse
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public long? PhoneNo { get; set; }
}
