using BotRemesas.Application.Features.Account.Dto;
using BotRemesas.Application.Query.Generic.GetById;
using BotRemesas.Domain.Entities.Account;

namespace BotRemesas.Application.Query.Account.GetById;
public class GetAccountEntityById : GetGenericEntityByIdQuery<AccountEntity , AccountResultDto>{}