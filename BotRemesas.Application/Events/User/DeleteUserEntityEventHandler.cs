using BotRemesas.Domain.Events.User.Delete;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BotRemesas.Application.Events.User;

public class DeleteUserEntityEventHandler : INotificationHandler<DeleteUserEntityEvent>
{
    private readonly ILogger<DeleteUserEntityEventHandler> logger;
    public DeleteUserEntityEventHandler(ILogger<DeleteUserEntityEventHandler> logger)
    {
        this.logger = logger;
    }
    public Task Handle(DeleteUserEntityEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("El usuario con id: "+notification.UserId+" y nombre: "+notification.UserName+" ha sido eliminado exitosamente en la fecha: "+notification.CreatedAt+" y con idEvent: "+notification.id);
        return Task.CompletedTask;
    }
}