using BotRemesas.Domain.Interfaces.DomainEvent;
using MediatR;

namespace BotRemesas.Domain.Events.Remittance.Delete;

public class DeleteRemittanceEntityEvent : IDomainEvent, INotification
{
    public string id {get ;}

    public DateTime CreatedAt {get ;}
    public string RemittanceId {get ;}
    public string UserId {get ;}
    public DeleteRemittanceEntityEvent(string RemittanceId , string UserId)
    {
        this.id = Guid.NewGuid().ToString();
        this.CreatedAt = DateTime.UtcNow;
        this.RemittanceId = RemittanceId;
        this.UserId = UserId;
    }
}