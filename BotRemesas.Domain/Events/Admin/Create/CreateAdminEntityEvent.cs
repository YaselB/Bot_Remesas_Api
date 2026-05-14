using BotRemesas.Domain.Interfaces.DomainEvent;
using MediatR;

namespace BotRemesas.Domain.Events.Admin.Create;

public class CreateAdminEntityEvent : IDomainEvent, INotification
{
    public string id {get; }
    public DateTime CreatedAt {get;}
    public string AdminId { get ;}
    public string Name { get ;}
    public CreateAdminEntityEvent(string AdminId , string Name)
    {
        this.AdminId = AdminId;
        this.Name = Name;
        this.CreatedAt = DateTime.UtcNow;
        this.id = Guid.NewGuid().ToString();
    }
}