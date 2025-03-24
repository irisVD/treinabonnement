using System;

namespace TreinAbo.Api.Contracts;

public class StationResponseContract
{
    public required int Id { get; set; }
    public required string Naam { get; set; }
    public required bool VerwarmdeWachtruimte { get; set; }

}
