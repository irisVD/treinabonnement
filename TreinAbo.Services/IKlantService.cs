using System;
using TreinAbo.Api.Contracts;

namespace TreinAbo.Services;

public interface IKlantService
{
    KlantResponseContract? GetById(int id);
    void Delete(int id);
    List<KlantResponseContract> GetAll();
    KlantResponseContract Create(KlantRequestContract request);
    void Update(int id, KlantRequestContract contract);
}
