using BotRemesas.Application.Features.Remittance.Dto;
using BotRemesas.Application.Query.Generic.GetAll;
using BotRemesas.Domain.Entities.Remittance;

namespace BotRemesas.Application.Query.Remittance.GetAll;
public class GetAllRemittanceEntityQuery : GetAllGenericEntityQuery<RemittanceEntity , RemittanceResultDto>
{
    
}