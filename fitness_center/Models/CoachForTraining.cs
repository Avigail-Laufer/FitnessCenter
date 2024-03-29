using System;
using System.Collections.Generic;

namespace Server.Models;

public partial class CoachForTraining
{
    public int Id { get; set; }

    public string CodeCoach { get; set; } = null!;

    public int CodeTraining { get; set; }

    public virtual Coach CodeCoachNavigation { get; set; } = null!;

    public virtual Training CodeTrainingNavigation { get; set; } = null!;

    public virtual ICollection<TimeTraining> TimeTrainings { get; set; } = new List<TimeTraining>();
}
