using System;
using System.Collections.Generic;

namespace Server.Models;

public partial class TimeTraining
{
    public int Id { get; set; }

    public string Day { get; set; } = null!;

    public TimeSpan Time { get; set; }

    public int? NumberRoom { get; set; }

    public int CoachForTrainingCode { get; set; }

    public virtual CoachForTraining CoachForTrainingCodeNavigation { get; set; } = null!;

    public virtual ICollection<SignTo> SignTos { get; set; } = new List<SignTo>();
}
