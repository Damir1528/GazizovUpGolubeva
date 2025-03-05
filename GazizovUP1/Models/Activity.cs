using System;
using System.Collections.Generic;

namespace GazizovUP1.Models;

public partial class Activity
{
    public int Id { get; set; }

    public int NameEvent { get; set; }

    public DateOnly StartDate { get; set; }

    public int Countdays { get; set; }

    public string Activity1 { get; set; } = null!;

    public int Activityday { get; set; }

    public TimeOnly Starttime { get; set; }

    public int Moderator { get; set; }

    public int? Expert1 { get; set; }

    public int? Expert2 { get; set; }

    public int? Expert3 { get; set; }

    public int? Expert4 { get; set; }

    public int? Expert5 { get; set; }

    public int? Winner { get; set; }

    public virtual Jury? Expert1Navigation { get; set; }

    public virtual Jury? Expert2Navigation { get; set; }

    public virtual Jury? Expert3Navigation { get; set; }

    public virtual Jury? Expert4Navigation { get; set; }

    public virtual Jury? Expert5Navigation { get; set; }

    public virtual Moderator ModeratorNavigation { get; set; } = null!;

    public virtual Event NameEventNavigation { get; set; } = null!;

    public virtual User? WinnerNavigation { get; set; }
}
