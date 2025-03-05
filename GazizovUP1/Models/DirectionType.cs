using System;
using System.Collections.Generic;

namespace GazizovUP1.Models;

public partial class DirectionType
{
    public int DirectionId { get; set; }

    public string DirectionTitle { get; set; } = null!;

    public virtual ICollection<Jury> Juries { get; set; } = new List<Jury>();

    public virtual ICollection<Moderator> Moderators { get; set; } = new List<Moderator>();
}
