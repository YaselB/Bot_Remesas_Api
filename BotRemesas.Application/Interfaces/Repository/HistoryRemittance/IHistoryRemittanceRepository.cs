using BotRemesas.Application.Interfaces.Repository.Generic;
using BotRemesas.Domain.Entities.HistoryRemittances;

namespace BotRemesas.Application.Interfaces.Repository.HistoryRemittance;
public interface IHistoryRemittanceRepository : IGenericRepository<HistoryRemittanceEntity>
{
    public Task<IReadOnlyList<HistoryRemittanceEntity>> GetByUserId(string UserId , CancellationToken cancellationToken);
}