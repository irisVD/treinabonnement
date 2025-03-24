using System;

namespace TreinAbo.Api.Contracts;

public class KlantResponseContract
{
    public required int Id { get; set; }
    public required string Naam { get; set; } = null!;
    public required string Voornaam { get; set; } = null!;
    public required string Email { get; set; } = null!;
}
