using System;
using System.Collections.Generic;

namespace Server.Models;

public partial class Coach
{
    public string Id { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public decimal SalaryForHower { get; set; }

    public int Age { get; set; }

    public string Fhone { get; set; } = null!;

    public string? Email { get; set; }

    public virtual ICollection<CoachForTraining> CoachForTrainings { get; set; } = new List<CoachForTraining>();
}
