using BotRemesas.Application.Features.Pay.Dto;
using BotRemesas.Application.Query.Generic.GetAll;
using BotRemesas.Domain.Entities.Pay;

namespace BotRemesas.Application.Query.Pay.GetAll;
public class GetAllPayEntityQuery : GetAllGenericEntityQuery<PayEntity , PayResultDto>
{
    
}