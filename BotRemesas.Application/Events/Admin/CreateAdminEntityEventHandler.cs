using BotRemesas.Domain.Events.Admin.Create;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BotRemesas.Application.Events.Admin;

public class CreateAdminEntityEventHandler : INotificationHandler<CreateAdminEntityEvent>
{
    private readonly ILogger<CreateAdminEntityEventHandler> logger;
    public CreateAdminEntityEventHandler(ILogger<CreateAdminEntityEventHandler> logger)
    {
        this.logger = logger;
    }
    public Task Handle(CreateAdminEntityEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("Se ha creado un Admin con id: "+notification.AdminId+", con nombre: "+notification.Name+" ,en la fecha: "+notification.CreatedAt+" y idEvent: "+notification.id);
        return Task.CompletedTask;
    }
}