using BotRemesas.Domain.Events.User.Update;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BotRemesas.Application.Events.User;

public class UpdateUserEntityEventHandler : INotificationHandler<UpdateUserEntityEvent>
{
    private readonly ILogger<UpdateUserEntityEventHandler> logger;
    public UpdateUserEntityEventHandler(ILogger<UpdateUserEntityEventHandler> logger)
    {
        this.logger = logger;
    }
    public Task Handle(UpdateUserEntityEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("El user con id: "+notification.UserId+" y nombre: "+notification.UserName+" ha sido actualizado en la fecha: "+notification.CreatedAt+" y con idEvent: "+notification.id);
        return Task.CompletedTask;
    }
}