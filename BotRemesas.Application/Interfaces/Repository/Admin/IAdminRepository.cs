using BotRemesas.Application.Interfaces.Repository.Generic;
using BotRemesas.Domain.Entities.Admin;

namespace BotRemesas.Application.Interfaces.Repository.Admin;
public interface IAdminRepository : IGenericRepository<AdminEntity>
{
    public Task<AdminEntity?> GetByIdTelegram(long id , CancellationToken cancellationToken);
}