using System;
using System.Collections.Generic;

namespace Server.Models;

public partial class SignTo
{
    public int Id { get; set; }

    public string IdClient { get; set; } = null!;

    public int CodeDate { get; set; }

    public virtual TimeTraining CodeDateNavigation { get; set; } = null!;

    public virtual Client IdClientNavigation { get; set; } = null!;
}
