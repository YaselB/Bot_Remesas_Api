using BotRemesas.Application.Interfaces.Repository.Remittance;
using BotRemesas.Db;
using BotRemesas.Domain.Entities.Remittance;
using BotRemesas.Infrastructure.Repository.Generic;
using Microsoft.EntityFrameworkCore;

namespace BotRemesas.Infrastructure.Repository.Remittance;

public class RemittanceRepository : GenericRepository<RemittanceEntity>, IRemittanceRepository
{
    private readonly BotRemesasDbContext context;
    public RemittanceRepository(BotRemesasDbContext dbContext) : base(dbContext)
    {
        this.context = dbContext;
    }
    public override async Task<RemittanceEntity?> GetById(string id, CancellationToken cancellationToken = default)
    {
        var remittance = await context.Remittances.Include(u => u.User).Include(u => u.Account).FirstOrDefaultAsync(r => r.Id == id);
        if(remittance == null)
        {
            return null;
        }
        return remittance;
    }
    public override async Task<IReadOnlyList<RemittanceEntity>> GetAll(CancellationToken cancellationToken = default)
    {
        return await context.Remittances.Include(r => r.User).Include(u => u.Account).ToListAsync();
    }
}