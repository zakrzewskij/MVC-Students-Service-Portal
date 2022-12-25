using System;
using System.Collections.Generic;

namespace projektMVC.Models;

public partial class Employee
{
    public int Empid { get; set; }

    public string Lastname { get; set; } = null!;

    public string Firstname { get; set; } = null!;

    public string Title { get; set; } = null!;

    public string Titleofcourtesy { get; set; } = null!;

    public DateTime Birthdate { get; set; }

    public DateTime Hiredate { get; set; }

    public string Address { get; set; } = null!;

    public string City { get; set; } = null!;

    public string? Region { get; set; }

    public string? Postalcode { get; set; }

    public string Country { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public int Userid { get; set; }

    public virtual ICollection<Lecturer>? Lecturers { get; } = new List<Lecturer>();

    public virtual Userinfo? User { get; set; } = null!;
}
