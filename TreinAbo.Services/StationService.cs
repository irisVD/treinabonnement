using System;
using TreinAbo.Api.Contracts;
using TreinAbo.Persistence;

namespace TreinAbo.Services;

public class StationService
{
public StationResponseContract Create(StationRequestContract request)
    {
        var entity = new Station()
        {
            Naam = request.Naam,
            
        };

        treinAboContext.Stations.Add(entity);
        treinAboContext.SaveChanges();

        return MapToContract(entity);
    }

    public void Delete(int id)
    {
        var entity = treinAboContext.Stations.Find(id);
        if (entity == null)
        {
            throw new InvalidOperationException($"Station met id {id} niet gevonden");
        }

        treinAboContext.Stations.Remove(entity);
        treinAboContext.SaveChanges();
    }

    public List<StationResponseContract> GetAll()
    {
        return treinAboContext.Stations.Select(k => MapToContract(k)).ToList();
    }

    public StationResponseContract? GetById(int id)
    {
        var entity = treinAboContext.Stations.Find(id);
        return entity == null ? null : MapToContract(entity);
    }

    public void Update(int id, StationRequestContract contract)
    {
        var entity = treinAboContext.Stations.Find(id);
        if (entity == null)
        {
            throw new InvalidOperationException($"Station met id {id} niet gevonden");
        }

        entity.Naam = contract.Naam;
        entity.Voornaam = contract.Voornaam;
        entity.Email = contract.Email;

        treinAboContext.Stations.Update(entity);
        treinAboContext.SaveChanges();
        
    }

    private static StationResponseContract MapToContract(Station entity)
    {
        return new StationResponseContract()
        {
            Id = entity.Id,
            Naam = entity.Naam,
            Voornaam = entity.Voornaam,
            Email = entity.Email
        };
    }
}
