using System;
using System.Collections.Generic;

namespace projektMVC.Models;

public partial class Groupinfo
{
    public int Groupid { get; set; }

    public string Groupname { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<Timetableinfo>? Timetableinfos { get; } = new List<Timetableinfo>();
}
