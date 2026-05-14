using BotRemesas.Application.Interfaces.Repository.HistoryRemittance;
using BotRemesas.Db;
using BotRemesas.Domain.Entities.HistoryRemittances;
using BotRemesas.Infrastructure.Repository.Generic;
using Microsoft.EntityFrameworkCore;

namespace BotRemesas.Infrastructure.Repository.HistoryRemittance;

public class HistoryRemittanceRepository : GenericRepository<HistoryRemittanceEntity>, IHistoryRemittanceRepository
{
    private readonly BotRemesasDbContext context;
    public HistoryRemittanceRepository(BotRemesasDbContext dbContext) : base(dbContext)
    {
        context = dbContext;
    }

    public async Task<IReadOnlyList<HistoryRemittanceEntity>> GetByUserId(string UserId, CancellationToken cancellationToken)
    {
        var historyEntities = await context.HistoryRemittances.Where(h => h.UserId == UserId).ToListAsync();
        return historyEntities;
    }
}