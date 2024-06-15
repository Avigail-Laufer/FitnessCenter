using System;
using System.Collections.Generic;

namespace Server.Models;

public partial class Client
{
    public string Id { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? Email { get; set; }

    public string Fhone { get; set; } = null!;

    public int TypeMemberCode { get; set; }

    public DateTime BirthDate { get; set; }

    public string? Password { get; set; }

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual ICollection<SignTo> SignTos { get; set; } = new List<SignTo>();

    public virtual TypeMember TypeMemberCodeNavigation { get; set; } = null!;
}
