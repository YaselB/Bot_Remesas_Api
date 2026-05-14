using BotRemesas.Application.Features.Pay.Dto;
using BotRemesas.Application.Query.Generic.GetById;
using BotRemesas.Domain.Entities.Pay;

namespace BotRemesas.Application.Query.Pay.GetById;
public class GetPayEntityByIdQuery : GetGenericEntityByIdQuery<PayEntity , PayResultDto>{}