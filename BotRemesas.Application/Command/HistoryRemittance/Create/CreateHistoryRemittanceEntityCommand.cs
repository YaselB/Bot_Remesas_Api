using BotRemesas.Application.Command.Generic.Create;
using BotRemesas.Domain.Entities.HistoryRemittances;

namespace BotRemesas.Application.Command.HistoryRemittance.Create;
public class CreateHistoryRemittanceEntityCommand : CreateGenericEntityCommand<HistoryRemittanceEntity>
{
    public string UserId {get ; set ; } = string.Empty;
    public string Account {get ; set ;} = string.Empty;
    public double Amount {get ; set ;}
    public string Customer {get ; set ;} = string.Empty;
}