using System;
using System.Collections.Generic;

namespace Server.Models;

public partial class TypeMember
{
    public int Id { get; set; }

    public string Type { get; set; } = null!;

    public int MonthlyPayment { get; set; }

    public virtual ICollection<Client> Clients { get; set; } = new List<Client>();
}
