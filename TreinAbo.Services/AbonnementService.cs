using System;
using TreinAbo.Api.Contracts;
using TreinAbo.Persistence;

namespace TreinAbo.Services;
/*
public class AbonnementService(TreinabonnementenContext treinAboContext): IAbonnementService
{
    public AbonnementResponseContract Create(AbonnementRequestContract request)
    {
        // Alle station entities laden die (door id) verwezen worden in order ^.
        // Op deze manier moeten we straks niet voor elke entity apart naar de database.
        var stations = treinAboContext.Stations
            .Where(s => request.IdStations.Contains(s.Id));
        var entity = new Abonnement()
        {
            StartDatum = request.StartDatum,
            EindDatum = request.EindDatum,
            Klasse = request.Klasse,
            Klant = treinAboContext.Klanten.Find(request.IdKlant),
            Stations = stations.ToList()

        };

        treinAboContext.Abonnementen.Add(entity);
        treinAboContext.SaveChanges();

        return MapToContract(entity);
    }

    public void Delete(int id)
    {
        var entity = treinAboContext.Abonnementen.Find(id);
        if (entity == null)
        {
            throw new InvalidOperationException($"Abonnement met id {id} niet gevonden");
        }

        treinAboContext.Abonnementen.Remove(entity);
        treinAboContext.SaveChanges();
    }

    public List<AbonnementResponseContract> GetAll()
    {
        return treinAboContext.Abonnementen.Select(k => MapToContract(k)).ToList();
    }

    public AbonnementResponseContract? GetById(int id)
    {
        var entity = treinAboContext.Abonnementen.Find(id);
        return entity == null ? null : MapToContract(entity);
    }

    public void Update(int id, AbonnementRequestContract contract)
    {
        var entity = treinAboContext.Abonnementen.Find(id);
        if (entity == null)
        {
            throw new InvalidOperationException($"Abonnement met id {id} niet gevonden");
        }

        entity.Naam = contract.Naam;
        entity.Voornaam = contract.Voornaam;
        entity.Email = contract.Email;

        treinAboContext.Abonnementen.Update(entity);
        treinAboContext.SaveChanges();
        
    }

    private static AbonnementResponseContract MapToContract(Abonnement entity)
    {
        return new AbonnementResponseContract()
        {
            Id = entity.Id,
            Naam = entity.Naam,
            Voornaam = entity.Voornaam,
            Email = entity.Email
        };
    }
}
*/