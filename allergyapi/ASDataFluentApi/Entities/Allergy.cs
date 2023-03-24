using System;
using System.Collections.Generic;

namespace DataFluentApi.Entities;

public partial class Allergy
{
    public Guid AllergyId { get; set; }

    public string AllergyName { get; set; } = null!;
}
