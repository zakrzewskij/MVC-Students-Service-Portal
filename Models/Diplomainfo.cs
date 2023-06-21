using System;
using System.Collections.Generic;

namespace projektMVC.Models;

public partial class Diplomainfo
{
    public int Diplomaid { get; set; }

    public string? Description { get; set; }

    public int Reviewerid { get; set; }

    public int Promotorid { get; set; }

    public string Theme { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public DateTime FinishDate { get; set; }

    public bool Status { get; set; }

    public int Studentid { get; set; }

    public int? Fileid { get; set; }

    public int? Whoupload { get; set; }

    public virtual Fileinfo? File { get; set; }

    public virtual Userinfo? Reviewer { get; set; } = null!;

    public virtual Userinfo? Student { get; set; } = null!;

    public virtual Userinfo? WhouploadNavigation { get; set; }
}
