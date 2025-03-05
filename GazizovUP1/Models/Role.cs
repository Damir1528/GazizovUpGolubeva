using GazizovUP1.Models;
using System;
using System.Collections.Generic;

namespace GazizovUP1;

public partial class Role
{
    public int RoleId { get; set; }

    public string RoleName { get; set; } = null!;

    public virtual ICollection<Logined> Logineds { get; set; } = new List<Logined>();
}
