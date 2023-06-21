using System;
using System.Collections.Generic;

namespace projektMVC.Models;

public partial class Student
{
    public int Studentid { get; set; }

    public string Lastname { get; set; } = null!;

    public string Firstname { get; set; } = null!;

    public DateTime Birthdate { get; set; }

    public DateTime Hiredate { get; set; }

    public string Address { get; set; } = null!;

    public string City { get; set; } = null!;

    public string? Region { get; set; }

    public string? Postalcode { get; set; }

    public string Country { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public int Userid { get; set; }

    public virtual Userinfo? User { get; set; } = null!;
}
