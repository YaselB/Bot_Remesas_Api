using BotRemesas.Domain.Interfaces.DomainEvent;
using MediatR;

namespace BotRemesas.Domain.Events.Remittance.Update;

public class UpdateRemittanceEvent : IDomainEvent, INotification
{
    public string id {get ;}

    public DateTime CreatedAt {get;}
    public string RemittanceId {get ;}
    public string Customer {get ;}
    public UpdateRemittanceEvent(string RemittanceId ,string Customer)
    {
        this.id = Guid.NewGuid().ToString();
        this.CreatedAt = DateTime.UtcNow;
        this.RemittanceId = RemittanceId;
        this.Customer = Customer;
    }
}