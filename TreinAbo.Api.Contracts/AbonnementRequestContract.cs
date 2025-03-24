using System;
using System.ComponentModel.DataAnnotations;

namespace TreinAbo.Api.Contracts;

public class AbonnementRequestContract
{
    [MaxLength(45)]
    public required string Naam { get; set; } = null!;
    public required DateTime StartDatum { get; set; }
    public required DateTime EindDatum { get; set; }
    public required int Klasse { get; set; }
    public required int IdKlant { get; set; }
    public required int[] IdStations { get; set; }

}
