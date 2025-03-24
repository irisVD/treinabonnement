using System;
using System.Collections.Generic;

namespace TreinAbo.Persistence;

public partial class Station
{
    public int Id { get; set; }

    public string Naam { get; set; } = null!;

    public byte[] VerwarmdeWachtruimte { get; set; } = null!;

    public virtual ICollection<Abonnement> IdAbonnements { get; set; } = new List<Abonnement>();
}
