using System;
using System.Collections.Generic;

namespace Server.Models;

public partial class CreditCard
{
    public int Id { get; set; }

    public string Number { get; set; } = null!;

    public string Expiry { get; set; } = null!;

    public string Cvc { get; set; } = null!;

    public virtual ICollection<Client> Clients { get; set; } = new List<Client>();
}
