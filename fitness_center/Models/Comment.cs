using System;
using System.Collections.Generic;

namespace Server.Models;

public partial class Comment
{
    public int Id { get; set; }

    public string Comments { get; set; } = null!;

    public string IdClient { get; set; } = null!;

    public virtual Client IdClientNavigation { get; set; } = null!;
}
