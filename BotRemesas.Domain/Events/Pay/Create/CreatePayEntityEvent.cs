using BotRemesas.Domain.Interfaces.DomainEvent;
using MediatR;

namespace BotRemesas.Domain.Events.Pay.Create;

public class CreatePayEntityEvent : IDomainEvent, INotification
{
    public string id {get ;}

    public DateTime CreatedAt {get; }
    public string UserId {get ;}
    public string PayId {get;}
    public CreatePayEntityEvent(string UserId , string PayId)
    {
        this.CreatedAt = DateTime.UtcNow;
        this.id = Guid.NewGuid().ToString();
        this.PayId = PayId;
        this.UserId = UserId;
    }
}