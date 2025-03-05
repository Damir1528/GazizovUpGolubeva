using System;
using System.Collections.Generic;

namespace GazizovUP1.Models;

public partial class Event
{
    public int EventsId { get; set; }

    public string EventsName { get; set; } = null!;

    public virtual ICollection<Activity> Activities { get; set; } = new List<Activity>();

    public virtual ICollection<Meropriyatiye> Meropriyatiyes { get; set; } = new List<Meropriyatiye>();

    public virtual ICollection<Moderator> Moderators { get; set; } = new List<Moderator>();
}
