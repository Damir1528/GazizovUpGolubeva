using System;
using System.Collections.Generic;

namespace GazizovUP1.Models;

public partial class Meropriyatiye
{
    public int MeropriyatiyeId { get; set; }

    public int MeropriyatiyeEvent { get; set; }

    public string MeropriyatiyeName { get; set; } = null!;

    public DateOnly MeropriyatiyeDate { get; set; }

    public int MeropriyatiyeDays { get; set; }

    public int MeropriyatiyeCity { get; set; }

    public virtual Event MeropriyatiyeEventNavigation { get; set; } = null!;
}
