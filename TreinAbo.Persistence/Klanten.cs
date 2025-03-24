using System;
using System.Collections.Generic;

namespace TreinAbo.Persistence;

public partial class Klanten
{
    public int Id { get; set; }

    public string Naam { get; set; } = null!;

    public string Voornaam { get; set; } = null!;

    public string Email { get; set; } = null!;

    public virtual ICollection<Abonnementen> Abonnementens { get; set; } = new List<Abonnementen>();
}
