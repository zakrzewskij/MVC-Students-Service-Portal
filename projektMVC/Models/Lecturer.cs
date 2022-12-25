using System;
using System.Collections.Generic;

namespace projektMVC.Models;

public partial class Lecturer
{
    public int Lecturerid { get; set; }

    public string Lastname { get; set; } = null!;

    public string Firstname { get; set; } = null!;

    public DateTime Birthdate { get; set; }

    public DateTime Hiredate { get; set; }

    public string Title { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string City { get; set; } = null!;

    public string? Region { get; set; }

    public string? Postalcode { get; set; }

    public string Country { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public int? Emplid { get; set; }

    public virtual Employee? Empl { get; set; }
}
