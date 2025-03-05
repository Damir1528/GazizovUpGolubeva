using GazizovUP1.Models;
using System;
using System.Collections.Generic;

namespace GazizovUP1;

public partial class User
{
    public int UsersId { get; set; }

    public string UsersFio { get; set; } = null!;

    public int UsersGender { get; set; }

    public string UsersEmail { get; set; } = null!;

    public DateOnly UsersBirthday { get; set; }

    public int UsersCountry { get; set; }

    public string UsersPhone { get; set; } = null!;

    public string UsersImage { get; set; } = null!;

    public virtual ICollection<Activity> Activities { get; set; } = new List<Activity>();

    public virtual Jury? Jury { get; set; }

    public virtual Moderator? Moderator { get; set; }

    public virtual Logined Users { get; set; } = null!;

    public virtual Country UsersCountryNavigation { get; set; } = null!;

    public virtual Gender UsersGenderNavigation { get; set; } = null!;
}
