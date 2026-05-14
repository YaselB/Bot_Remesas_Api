using BotRemesas.Application.Interfaces.Repository.Generic;
using BotRemesas.Domain.Entities.User;

namespace BotRemesas.Application.Interfaces.Repository.User;
public interface IUserRepository : IGenericRepository<UserEntity>
{
    public Task<UserEntity?> GetByIdUserTelegram(long idUserTelegram , CancellationToken cancellationToken);
}