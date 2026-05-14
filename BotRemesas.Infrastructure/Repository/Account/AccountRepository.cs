using BotRemesas.Application.Interfaces.Repository.Account;
using BotRemesas.Db;
using BotRemesas.Domain.Entities.Account;
using BotRemesas.Infrastructure.Repository.Generic;
using Microsoft.EntityFrameworkCore;

namespace BotRemesas.Infrastructure.Repository.Account;

public class AccountRepository : GenericRepository<AccountEntity>, IAccountRepository
{
    private readonly BotRemesasDbContext context;
    public AccountRepository(BotRemesasDbContext dbContext) : base(dbContext)
    {
        context = dbContext;
    }

    public async Task<AccountEntity?> GetByAddress(string account)
    {
        var entity = await context.Accounts.FirstOrDefaultAsync(a => a.Account == account);
        if(entity == null)
        {
            return null;
        }
        return entity;
    }
}