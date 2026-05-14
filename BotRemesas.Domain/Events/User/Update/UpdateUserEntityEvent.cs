using BotRemesas.Domain.Interfaces.DomainEvent;
using MediatR;

namespace BotRemesas.Domain.Events.User.Update;

public class UpdateUserEntityEvent : IDomainEvent, INotification
{
    public string id {get;}

    public DateTime CreatedAt {get;}
    public string UserId {get ;}
    public string UserName {get;}
    public UpdateUserEntityEvent(string UserId , string userName)
    {
        id = Guid.NewGuid().ToString();
        CreatedAt = DateTime.UtcNow;
        this.UserId = UserId;
        this.UserName = userName;
    }
}