using System;
using System.Collections.Generic;

namespace projektMVC.Models;

public partial class Userinfo
{
    public int Userid { get; set; }

    public string Password { get; set; } = null!;

    public string? Prefix { get; set; }

    public string Username { get; set; } = null!;

    public string Login { get; set; } = null!;

    public DateTime LastLoginDate { get; set; }

    public DateTime CreateAccountDate { get; set; }

    public bool StatusAccount { get; set; }

    public int? Timetableid { get; set; }

    public virtual ICollection<Diplomainfo> DiplomainfoReviewers { get; } = new List<Diplomainfo>();

    public virtual ICollection<Diplomainfo> DiplomainfoStudents { get; } = new List<Diplomainfo>();

    public virtual ICollection<Diplomainfo> DiplomainfoWhouploadNavigations { get; } = new List<Diplomainfo>();

    public virtual ICollection<Employee> Employees { get; } = new List<Employee>();

    public virtual ICollection<Settlementinfo> Settlementinfos { get; } = new List<Settlementinfo>();

    public virtual ICollection<Student> Students { get; } = new List<Student>();

    public virtual Timetableinfo? Timetable { get; set; }
}
