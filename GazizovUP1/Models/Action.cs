using System;
using System.Collections.Generic;

namespace GazizovUP1.Models;

public partial class Action
{
    public int ActionId { get; set; }

    public int ActionTitle { get; set; }

    public DateOnly ActionDateStart { get; set; }

    public int ActionSpisok { get; set; }

    public int? ActionWinner { get; set; }
}
