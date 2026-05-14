using BotRemesas.Application.Command.Generic.Update;
using BotRemesas.Domain.Entities.Account;

namespace BotRemesas.Application.Command.Account.Update;
public class UpdateAccountEntityCommand : UpdateGenericEntityCommand<AccountEntity>
{
    public required string AdminId {get ; set ;}
    public required bool EnabledSum {get ; set ;}
    public required double Value {get ; set ;}

}