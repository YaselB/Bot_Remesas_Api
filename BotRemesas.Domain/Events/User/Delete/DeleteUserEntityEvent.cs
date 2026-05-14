using BotRemesas.Domain.Interfaces.DomainEvent;
using MediatR;

namespace BotRemesas.Domain.Events.User.Delete;

public class DeleteUserEntityEvent : IDomainEvent, INotification
{
    public string id {get ;}

    public DateTime CreatedAt {get;}
    public string UserId {get ; }
    public string UserName {get ;}
    public DeleteUserEntityEvent(string userId, string userName)
    {
        this.UserId = userId;
        this.UserName = userName;
        this.id = Guid.NewGuid().ToString();
        this.CreatedAt = DateTime.UtcNow;
    }
}