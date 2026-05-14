using BotRemesas.Application.Features.Account.Dto;
using BotRemesas.Application.Query.Generic.GetAll;
using BotRemesas.Domain.Entities.Account;

namespace BotRemesas.Application.Query.Account.GetAll;
public class GetAllAccountEntityQuery : GetAllGenericEntityQuery<AccountEntity ,AccountResultDto>{}