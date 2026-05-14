using BotRemesas.Domain.Interfaces.DomainEvent;
using MediatR;

namespace BotRemesas.Domain.Events.Pay.Delete;

public class DeletePayEntityEvent : IDomainEvent, INotification
{
    public string id {get;}
    public DateTime CreatedAt {get;}
    public string PayId {get ;}
    public double PayAmount {get;}
    public DeletePayEntityEvent(string payId ,double PayAmount)
    {
        this.id = Guid.NewGuid().ToString();
        this.CreatedAt = DateTime.UtcNow;
        this.PayId = payId;
        this.PayAmount = PayAmount;
    }
}