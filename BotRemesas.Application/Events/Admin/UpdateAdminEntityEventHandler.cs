using BotRemesas.Domain.Events.Admin.Update;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BotRemesas.Application.Events.Admin;

public class UpdateAdminEntityEventHandler : INotificationHandler<UpdateAdminEntityEvent>
{
    private readonly ILogger<UpdateAdminEntityEventHandler> logger;
    public UpdateAdminEntityEventHandler(ILogger<UpdateAdminEntityEventHandler> logger)
    {
        this.logger = logger;
    }
    public Task Handle(UpdateAdminEntityEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("Se ha actualizado el admin con id: "+notification.AdminId+" con el nombre: "+notification.AdminName+" en la fecha: "+notification.CreatedAt+" con idEvent: "+notification.id);
        return Task.CompletedTask;
    }
}