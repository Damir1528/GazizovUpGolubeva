using System;
using System.Collections.Generic;

namespace GazizovUP1.Models;

public partial class Logined
{
    public int LoginedId { get; set; }

    public string LoginedPassword { get; set; } = null!;

    public int LoginedRole { get; set; }

    public virtual Role LoginedRoleNavigation { get; set; } = null!;

    public virtual User? User { get; set; }
}
