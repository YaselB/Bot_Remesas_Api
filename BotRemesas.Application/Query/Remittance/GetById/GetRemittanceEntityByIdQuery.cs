using BotRemesas.Application.Features.Remittance.Dto;
using BotRemesas.Application.Query.Generic.GetById;
using BotRemesas.Domain.Entities.Remittance;

namespace BotRemesas.Application.Query.Remittance.GetById;
public class GetRemittanceEntityByIdQuery : GetGenericEntityByIdQuery<RemittanceEntity, RemittanceResultDto>
{
    
}