using System;

namespace TreinAbo.Api.Contracts;

public class KlantResponseContract
{
    public int Id { get; set; }
    public string Naam { get; set; } = null!;
    public string Voornaam { get; set; } = null!;
    public string Email { get; set; } = null!;
}
