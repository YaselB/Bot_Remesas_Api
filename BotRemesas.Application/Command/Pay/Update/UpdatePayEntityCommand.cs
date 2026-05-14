using BotRemesas.Application.Command.Generic.Update;
using BotRemesas.Domain.Entities.Pay;

namespace BotRemesas.Application.Command.Pay.Update;
public class UpdatePayEntityCommand : UpdateGenericEntityCommand<PayEntity>
{
    public required string UserId {get ; set ;}
    public required double amount {get ; set ;}
    public required bool EnabledSum {get ; set ;}
}