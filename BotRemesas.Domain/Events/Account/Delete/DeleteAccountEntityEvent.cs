using BotRemesas.Domain.Interfaces.DomainEvent;
using MediatR;

namespace BotRemesas.Domain.Events.Account.Delete;

public class DeleteAccountEntityEvent : IDomainEvent, INotification
{
    public string id {get;}

    public DateTime CreatedAt {get;}
    public string AccountId {get;}
    public string Account {get ;}
    public DeleteAccountEntityEvent(string accountId , string address)
    {
        this.id = Guid.NewGuid().ToString();
        this.CreatedAt = DateTime.UtcNow;
        Account = address;
        AccountId = accountId;
    }
}