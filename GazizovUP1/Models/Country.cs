using System;
using System.Collections.Generic;

namespace GazizovUP1.Models;

public partial class Country
{
    public int CountryId { get; set; }

    public string CountryName { get; set; } = null!;

    public string CountryEnName { get; set; } = null!;

    public string CountryKod { get; set; } = null!;

    public int CountryKod2 { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
