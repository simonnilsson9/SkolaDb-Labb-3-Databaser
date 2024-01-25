using System;
using System.Collections.Generic;

namespace SkolaDb_Labb_3.Models;

public partial class TblStudent
{
    public int StudentId { get; set; }

    public string? Förnamn { get; set; }

    public string? Efternamn { get; set; }

    public string? Klass { get; set; }

    public DateOnly? Personnummer { get; set; }
}
