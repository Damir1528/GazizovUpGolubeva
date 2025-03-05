using System;
using System.Collections.Generic;

namespace GazizovUP1.Models;

public partial class Jury
{
    public int JuryId { get; set; }

    public int JuryDirection { get; set; }

    public virtual ICollection<Activity> ActivityExpert1Navigations { get; set; } = new List<Activity>();

    public virtual ICollection<Activity> ActivityExpert2Navigations { get; set; } = new List<Activity>();

    public virtual ICollection<Activity> ActivityExpert3Navigations { get; set; } = new List<Activity>();

    public virtual ICollection<Activity> ActivityExpert4Navigations { get; set; } = new List<Activity>();

    public virtual ICollection<Activity> ActivityExpert5Navigations { get; set; } = new List<Activity>();

    public virtual DirectionType JuryDirectionNavigation { get; set; } = null!;

    public virtual User JuryNavigation { get; set; } = null!;
}
