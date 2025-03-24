using System;

namespace TreinAbo.Api.Contracts;

public class AbonnementResponseContract
{
    public required int Id { get; set; }
    public required DateTime StartDatum { get; set; }
    public required DateTime EindDatum { get; set; }
    public required int Klasse { get; set; }
    public required AbonnementKlantResponseContract? Klant { get; set; }
    public required AbonnementStationResponseContract[] Stations { get; set; }
}

public class AbonnementKlantResponseContract
{
    public required int Id { get; set; }
    public required string Naam { get; set; } = null!;
    public required string Voornaam { get; set; } = null!;
}

public class AbonnementStationResponseContract
{
    public required int Id { get; set; }
    public required string Naam { get; set; } = null!;
}
