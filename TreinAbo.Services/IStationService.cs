using System;
using TreinAbo.Api.Contracts;

namespace TreinAbo.Services;

public interface IStationService
{
    StationResponseContract? GetById(int id);
    void Delete(int id);
    List<StationResponseContract> GetAll();
    StationResponseContract Create(StationRequestContract request);
    void Update(int id, StationRequestContract contract);
}
