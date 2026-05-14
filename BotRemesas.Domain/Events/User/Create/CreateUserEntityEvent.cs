using BotRemesas.Domain.Interfaces.DomainEvent;
using MediatR;

namespace BotRemesas.Domain.Events.User.Create;

public class CreateUserEntityEvent : IDomainEvent, INotification
{
    public string id {get;}
    public DateTime CreatedAt {get;}
    public string UserId {get ;}
    public string Name{get ;}
    public CreateUserEntityEvent(string userId , string name)
    {
        this.Name = name;
        this.UserId = userId;
        this.id = Guid.NewGuid().ToString();
        this.CreatedAt = DateTime.UtcNow;
    }
}