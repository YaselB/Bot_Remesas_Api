using BotRemesas.Domain.Events.Admin.Delete;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BotRemesas.Application.Events.Admin;

public class DeleteAdminEntityEventHandler : INotificationHandler<DeleteAdminEntityEvent>
{
    private readonly ILogger<DeleteAdminEntityEventHandler> logger;
    public DeleteAdminEntityEventHandler(ILogger<DeleteAdminEntityEventHandler> logger)
    {
        this.logger = logger;
    }
    public Task Handle(DeleteAdminEntityEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("El admin con id: "+notification.AdminId+" y nombre: "+notification.AdminName+" ha sido eliminado en la fecha: "+notification.CreatedAt+" y con idEvent: "+notification.id);
        return Task.CompletedTask;
    }
}