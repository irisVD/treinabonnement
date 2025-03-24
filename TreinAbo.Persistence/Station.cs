using System;
using System.Collections.Generic;

namespace TreinAbo.Persistence;

public partial class Station
{
    public int Id { get; set; }

    public string Naam { get; set; } = null!;

    public bool VerwarmdeWachtruimte { get; set; }

    public virtual ICollection<Abonnement> Abonnementen { get; set; } = new List<Abonnement>();
}
