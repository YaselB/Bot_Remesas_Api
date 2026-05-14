using BotRemesas.Application.Interfaces.Repository.Generic;
using BotRemesas.Domain.Entities.Remittance;

namespace BotRemesas.Application.Interfaces.Repository.Remittance;
public interface IRemittanceRepository : IGenericRepository<RemittanceEntity>{}