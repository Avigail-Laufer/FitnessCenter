using System;
using System.Collections.Generic;

namespace Server.Models;

public partial class Training
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? PurposeOfTraining { get; set; }

    public virtual ICollection<CoachForTraining> CoachForTrainings { get; set; } = new List<CoachForTraining>();
}
