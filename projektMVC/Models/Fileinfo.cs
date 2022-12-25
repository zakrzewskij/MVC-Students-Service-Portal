using System;
using System.Collections.Generic;

namespace projektMVC.Models;

public partial class Fileinfo
{
    public int Fileid { get; set; }

    public string FileName { get; set; } = null!;

    public DateTime FileDate { get; set; }

    public decimal FileWeight { get; set; }

    public string FileType { get; set; } = null!;

    public virtual ICollection<Diplomainfo>? Diplomainfos { get; } = new List<Diplomainfo>();
}
