using System;
using TreinAbo.Api.Contracts;
using TreinAbo.Persistence;

namespace TreinAbo.Services;

public class KlantService(TreinabonnementenContext treinAboContext) : IKlantService
{
    public KlantResponseContract Create(KlantRequestContract request)
    {
        var entity = new Klant()
        {
            Naam = request.Naam,
            Voornaam = request.Voornaam,
            Email = request.Email
        };

        treinAboContext.Klanten.Add(entity);
        treinAboContext.SaveChanges();

        return MapToContract(entity);
    }

    public void Delete(int id)
    {
        var entity = treinAboContext.Klanten.Find(id);
        if (entity == null)
        {
            throw new InvalidOperationException($"Klant met id {id} niet gevonden");
        }

        treinAboContext.Klanten.Remove(entity);
        treinAboContext.SaveChanges();
    }

    public List<KlantResponseContract> GetAll()
    {
        return treinAboContext.Klanten.Select(k => MapToContract(k)).ToList();
    }

    public KlantResponseContract? GetById(int id)
    {
        var entity = treinAboContext.Klanten.Find(id);
        return entity == null ? null : MapToContract(entity);
    }

    public void Update(int id, KlantRequestContract contract)
    {
        var entity = treinAboContext.Klanten.Find(id);
        if (entity == null)
        {
            throw new InvalidOperationException($"Klant met id {id} niet gevonden");
        }

        entity.Naam = contract.Naam;
        entity.Voornaam = contract.Voornaam;
        entity.Email = contract.Email;

        treinAboContext.Klanten.Update(entity);
        treinAboContext.SaveChanges();
        
    }

    private static KlantResponseContract MapToContract(Klant entity)
    {
        return new KlantResponseContract()
        {
            Id = entity.Id,
            Naam = entity.Naam,
            Voornaam = entity.Voornaam,
            Email = entity.Email
        };
    }
}
