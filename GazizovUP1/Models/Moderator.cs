using System;
using System.Collections.Generic;

namespace GazizovUP1.Models;

public partial class Moderator
{
    public int ModeratorId { get; set; }

    public int ModeratorEvents { get; set; }

    public int ModeratorDirection { get; set; }

    public virtual ICollection<Activity> Activities { get; set; } = new List<Activity>();

    public virtual DirectionType ModeratorDirectionNavigation { get; set; } = null!;

    public virtual Event ModeratorEventsNavigation { get; set; } = null!;

    public virtual User ModeratorNavigation { get; set; } = null!;
}
