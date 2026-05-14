using BotRemesas.Domain.Events.Pay.Update;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BotRemesas.Application.Events.Pay;

public class UpdatePayEntityEventHandler : INotificationHandler<UpdatePayEntityEvent>
{
    private readonly ILogger<UpdatePayEntityEventHandler> logger;
    public UpdatePayEntityEventHandler(ILogger<UpdatePayEntityEventHandler> logger)
    {
        this.logger = logger;
    }
    public Task Handle(UpdatePayEntityEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("Se ha actualizado el PayId: "+notification.PayId+" con el userId: "+notification.UserId+" en la fecha: "+notification.CreatedAt+" y con idEvent: "+notification.id);
        return Task.CompletedTask;
    }
}