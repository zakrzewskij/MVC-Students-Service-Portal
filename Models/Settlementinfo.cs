using System;
using System.Collections.Generic;

namespace projektMVC.Models;

public partial class Settlementinfo
{
    public int Settlemenid { get; set; }

    public string Accountbanknumber { get; set; } = null!;

    public string? Description { get; set; }

    public int Status { get; set; }

    public int Userid { get; set; }

    public virtual Userinfo? User { get; set; } = null!;
}
