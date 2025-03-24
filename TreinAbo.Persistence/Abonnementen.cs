using System;
using System.Collections.Generic;

namespace TreinAbo.Persistence;

public partial class Abonnementen
{
    public int Id { get; set; }

    public DateTime StartDatum { get; set; }

    public DateTime PeriodeGeldig { get; set; }

    public int Klasse { get; set; }

    public int? IdKlant { get; set; }

    public virtual Klanten? IdKlantNavigation { get; set; }

    public virtual ICollection<Station> IdStations { get; set; } = new List<Station>();
}
