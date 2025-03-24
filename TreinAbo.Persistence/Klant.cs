using System;
using System.Collections.Generic;

namespace TreinAbo.Persistence;

public partial class Klant
{
    public int Id { get; set; }

    public string Naam { get; set; } = null!;

    public string Voornaam { get; set; } = null!;

    public string Email { get; set; } = null!;

    public virtual ICollection<Abonnement> Abonnementens { get; set; } = new List<Abonnement>();
}
