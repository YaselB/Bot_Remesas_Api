using BotRemesas.Application.Command.Generic.Update;
using BotRemesas.Domain.Entities.Remittance;

namespace BotRemesas.Application.Command.Remittance.Update;
public class UpdateRemittanceEntityCommand : UpdateGenericEntityCommand<RemittanceEntity>
{
    public required double? Amount {get ; set ;}
    public required string? urlImage {get ; set ;}
    public required string? Address {get ; set ;}
    public required string? UserId {get ; set ;}
    public required string? AdminId {get ; set ;}
}