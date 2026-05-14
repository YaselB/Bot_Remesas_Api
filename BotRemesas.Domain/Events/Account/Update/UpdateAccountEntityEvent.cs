using BotRemesas.Domain.Interfaces.DomainEvent;
using MediatR;

namespace BotRemesas.Domain.Events.Account.Update;

public class UpdateAccountEntityEvent : IDomainEvent, INotification
{
    public string id {get;}

    public DateTime CreatedAt {get;}
    public string Account{get;}
    public double Balance {get;}
    public UpdateAccountEntityEvent(string Account ,double balance)
    {
        this.id = Guid.NewGuid().ToString();
        this.Account = Account;
        this.Balance = balance;
        this.CreatedAt = DateTime.UtcNow;
    }
}