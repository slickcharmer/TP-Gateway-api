using System;
using System.Collections.Generic;

namespace FluentApi.Entities;

public partial class DoctorSchedule
{
    public string DoctorId { get; set; } = null!;

    public int Sunday { get; set; }

    public int Monday { get; set; }

    public int Tuesday { get; set; }

    public int Wednesday { get; set; }

    public int Thursday { get; set; }

    public int Friday { get; set; }

    public int Saturday { get; set; }
}
