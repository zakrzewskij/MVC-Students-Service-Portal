using System;
using System.Collections.Generic;

namespace projektMVC.Models;

public partial class Timetableinfo
{
    public int Timetableid { get; set; }

    public string Class { get; set; } = null!;

    public int Courseid { get; set; }

    public string Day { get; set; } = null!;

    public int Period { get; set; }

    public int Groupid { get; set; }

    public virtual Courseinfo? Course { get; set; }

    public virtual Groupinfo? Group { get; set; }

    public virtual ICollection<Userinfo>? Userinfos { get; } = new List<Userinfo>();
}
