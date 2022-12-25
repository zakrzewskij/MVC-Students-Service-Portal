using System;
using System.Collections.Generic;

namespace projektMVC.Models;

public partial class Courseinfo
{
    public int Courseid { get; set; }

    public string Thema { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<Timetableinfo>? Timetableinfos { get; } = new List<Timetableinfo>();
}
