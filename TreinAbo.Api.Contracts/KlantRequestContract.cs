using System;
using System.ComponentModel.DataAnnotations;

namespace TreinAbo.Api.Contracts;

public class KlantRequestContract
{
    [MaxLength(30)]
    public required string Naam { get; set; } = null!;

    [MaxLength(30)]
    public required string Voornaam { get; set; } = null!;

    [EmailAddress]
    public required string Email { get; set; } = null!;
}
