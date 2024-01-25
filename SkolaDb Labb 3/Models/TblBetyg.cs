using System;
using System.Collections.Generic;

namespace SkolaDb_Labb_3.Models;

public partial class TblBetyg
{
    public int BetygId { get; set; }

    public DateOnly? Datum { get; set; }

    public string? Betyg { get; set; }

    public int PersonalId { get; set; }

    public virtual TblPersonal Personal { get; set; } = null!;
}
