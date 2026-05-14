using BotRemesas.Domain.Events.User.Create;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BotRemesas.Application.Events.User;

public class CreateUserEntityEventHandler : INotificationHandler<CreateUserEntityEvent>
{
    private readonly ILogger<CreateUserEntityEventHandler> logger;
    public CreateUserEntityEventHandler(ILogger<CreateUserEntityEventHandler> logger)
    {
        this.logger = logger;
    }
    public Task Handle(CreateUserEntityEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("se creo un usuario con id: "+notification.UserId+" y nombre : "+notification.Name+" en la fecha: "+notification.CreatedAt+" y con idEvent: "+notification.id);
        return Task.CompletedTask;
    }
}