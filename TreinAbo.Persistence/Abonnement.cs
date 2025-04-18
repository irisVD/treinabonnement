﻿using System;
using System.Collections.Generic;

namespace TreinAbo.Persistence;

public partial class Abonnement
{
    public int Id { get; set; }

    public DateTime StartDatum { get; set; }

    public DateTime EindDatum { get; set; }

    public int Klasse { get; set; }

    public int? IdKlant { get; set; }

    public virtual Klant? Klant { get; set; }

    public virtual ICollection<Station> Stations { get; set; } = new List<Station>();
}
