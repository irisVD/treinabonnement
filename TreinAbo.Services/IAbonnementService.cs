using System;
using TreinAbo.Api.Contracts;

namespace TreinAbo.Services;

public interface IAbonnementService
{
    AbonnementResponseContract? GetById(int id);
    void Delete(int id);
    List<AbonnementResponseContract> GetAll();
    AbonnementResponseContract Create(AbonnementRequestContract request);
    void Update(int id, AbonnementRequestContract contract);
}
