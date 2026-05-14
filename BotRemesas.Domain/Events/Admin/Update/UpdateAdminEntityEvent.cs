using BotRemesas.Domain.Interfaces.DomainEvent;
using MediatR;

namespace BotRemesas.Domain.Events.Admin.Update;

public class UpdateAdminEntityEvent : IDomainEvent, INotification
{
    public string id {get;}
    public DateTime CreatedAt {get;}
    public string AdminId {get;}
    public string AdminName {get;}
    public UpdateAdminEntityEvent(string adminId , string adminName)
    {
        this.AdminId = adminId;
        this.AdminName = adminName;
        this.id = Guid.NewGuid().ToString();
        this.CreatedAt = DateTime.UtcNow;
    }
}