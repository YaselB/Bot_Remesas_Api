using BotRemesas.Application.Interfaces.Repository.Generic;
using BotRemesas.Domain.Entities.Account;

namespace BotRemesas.Application.Interfaces.Repository.Account;
public interface IAccountRepository : IGenericRepository<AccountEntity>
{
    public Task<AccountEntity?> GetByAddress(string account);
}