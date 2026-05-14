using BotRemesas.Application.Command.Generic.Create;
using BotRemesas.Domain.Entities.Pay;

namespace BotRemesas.Application.Command.Pay.Create;
public class CreatePayEntityCommand : CreateGenericEntityCommand<PayEntity>
{
    public string UserId {get ; set ;} = string.Empty;
}