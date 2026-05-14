using BotRemesas.Domain.Interfaces.DomainEvent;
using MediatR;

namespace BotRemesas.Domain.Events.Remittance.Create;

public class CreateRemittanceEntityEvent : IDomainEvent, INotification
{
    public string id {get ; }

    public DateTime CreatedAt {get ;}
    public string RemittanceId {get ;}
    public string Customer {get ;}
    public CreateRemittanceEntityEvent(string RemittanceId ,string Customer)
    {
        this.CreatedAt = DateTime.UtcNow;
        this.Customer = Customer;
        this.id = Guid.NewGuid().ToString();
        this.RemittanceId = RemittanceId;
    }
}