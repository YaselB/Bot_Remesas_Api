using BotRemesas.Application.Interfaces.Repository;
using BotRemesas.Db;
using BotRemesas.Domain.Entities.Pay;
using BotRemesas.Infrastructure.Repository.Generic;
using Microsoft.EntityFrameworkCore;

namespace BotRemesas.Infrastructure.Repository.Pay;

public class PayRepository : GenericRepository<PayEntity>, IPayRepository
{
    private readonly BotRemesasDbContext context;
    public PayRepository(BotRemesasDbContext dbContext) : base(dbContext)
    {
        context = dbContext;
    }
    public override async Task<PayEntity?> GetById(string id, CancellationToken cancellationToken = default)
    {
        var entity = await context.Pays.Include(p => p.Users).FirstOrDefaultAsync(p => p.Id == id);
        if(entity == null)
        {
            return null;
        }
        return entity;
    }
    public override async Task<IReadOnlyList<PayEntity>> GetAll(CancellationToken cancellationToken = default)
    {
        return await context.Pays.Include( p => p.Users).ToListAsync();
    }

    public async Task<PayEntity?> GetByUserId(string UserId, CancellationToken cancellationToken)
    {
        var pay = await context.Pays.Include(p => p.Users).FirstOrDefaultAsync(p => p.UserId == UserId);
        if(pay == null)
        {
            return null;
        }
        return pay;
    }
}