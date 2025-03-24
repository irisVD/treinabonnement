using System;
using System.ComponentModel.DataAnnotations;

namespace TreinAbo.Api.Contracts;

public class StationRequestContract
{
    [MaxLength(45)]
    public required string Naam { get; set; } = null!;
    public bool VerwarmdeWachtruimte { get; set; }
}
