using System;
using System.Collections.Generic;

namespace SkolaDb_Labb_3.Models;

public partial class TblStudentKursBetyg
{
    public int StudentId { get; set; }

    public int KursId { get; set; }

    public int BetygId { get; set; }

    public virtual TblBetyg Betyg { get; set; } = null!;

    public virtual TblKur Kurs { get; set; } = null!;

    public virtual TblStudent Student { get; set; } = null!;
}
