using System;
using System.Collections.Generic;

namespace SkolaDb_Labb_3.Models;

public partial class TblPersonal
{
    public int PersonalId { get; set; }

    public string? Förnamn { get; set; }

    public string? Efternamn { get; set; }

    public DateOnly? Personnummer { get; set; }

    public string? Befattning { get; set; }

    public virtual ICollection<TblBetyg> TblBetygs { get; set; } = new List<TblBetyg>();

    public virtual ICollection<TblKur> TblKurs { get; set; } = new List<TblKur>();
}
