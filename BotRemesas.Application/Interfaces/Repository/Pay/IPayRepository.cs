using BotRemesas.Application.Interfaces.Repository.Generic;
using BotRemesas.Domain.Entities.Pay;

namespace BotRemesas.Application.Interfaces.Repository;
public interface IPayRepository : IGenericRepository<PayEntity>
{
   public Task<PayEntity?> GetByUserId(string UserId , CancellationToken cancellationToken);  
}