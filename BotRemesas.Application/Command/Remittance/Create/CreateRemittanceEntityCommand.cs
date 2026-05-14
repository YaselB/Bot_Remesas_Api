using BotRemesas.Application.Command.Generic.Create;
using BotRemesas.Domain.Entities.Remittance;

namespace BotRemesas.Application.Command.Remittance.Create;
public class CreateRemittanceEntityCommand : CreateGenericEntityCommand<RemittanceEntity>
{
    public string UserId { get; set; } = string.Empty;
    public double Amount { get; set; }
    public string Customer { get; set; } = string.Empty;
    public string urlImage { get; set; } = string.Empty;
    public string AccountId { get; set; } = string.Empty;
}