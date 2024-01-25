using System;
using System.Collections.Generic;

namespace SkolaDb_Labb_3.Models;

public partial class TblKur
{
    public int KursId { get; set; }

    public string? KursNamn { get; set; }

    public int? PersonalId { get; set; }

    public virtual TblPersonal? Personal { get; set; }
}
