using BotRemesas.Domain.Interfaces.DomainEvent;
using MediatR;

namespace BotRemesas.Domain.Events.Pay.Update;

public class UpdatePayEntityEvent : IDomainEvent , INotification
{
    public string id {get ;}

    public DateTime CreatedAt {get ;}
    public string UserId {get ;}
    public string PayId {get ;}
    public UpdatePayEntityEvent(string userId , string payId)
    {
        this.id = Guid.NewGuid().ToString();
        this.CreatedAt = DateTime.UtcNow;
        this.UserId = userId;
        this.PayId = payId;
    }
}