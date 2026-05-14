using BotRemesas.Domain.Interfaces.DomainEvent;
using MediatR;

namespace BotRemesas.Domain.Events.Admin.Delete;

public class DeleteAdminEntityEvent : IDomainEvent, INotification
{
    public string id { get ;}
    public DateTime CreatedAt {get;}
    public string AdminId {get ;}
    public string AdminName {get ;}
    public DeleteAdminEntityEvent(string AdminId ,string AdminName)
    {
        this.AdminId = AdminId;
        this.AdminName = AdminName;
        id = Guid.NewGuid().ToString();
        CreatedAt = DateTime.UtcNow;
    }
}