using BotRemesas.Domain.Interfaces.DomainEvent;
using MediatR;

namespace BotRemesas.Domain.Events.Account.Create;

public class CreateAccountEntityEvent : IDomainEvent, INotification
{
    public string id {get; }

    public DateTime CreatedAt {get;}
    public string AccountId {get;}
    public string AccountAddress{ get ;}
    public CreateAccountEntityEvent(string accountId , string accountAddress)
    {
        this.id = Guid.NewGuid().ToString();
        this.CreatedAt = DateTime.UtcNow;
        this.AccountAddress = accountAddress;
        this.AccountId = accountId;
    }
}