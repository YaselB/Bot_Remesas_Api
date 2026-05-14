using BotRemesas.Application.Command.Generic.Create;
using BotRemesas.Domain.Entities.Account;

namespace BotRemesas.Application.Command.Account.Create;
public class CreateAccountEntityCommand : CreateGenericEntityCommand<AccountEntity>
{
    public string Account { get ; set ;} = string.Empty;
    public string AdminId {get ; set;} = string.Empty;
}