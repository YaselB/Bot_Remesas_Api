using BotRemesas.Domain.Events.Pay.Delete;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BotRemesas.Application.Events.Pay;

public class DeletePayEntityEventHandler : INotificationHandler<DeletePayEntityEvent>
{
    private readonly ILogger<DeletePayEntityEventHandler> logger;
    public DeletePayEntityEventHandler(ILogger<DeletePayEntityEventHandler> logger)
    {
        this.logger = logger;
    }
    public Task Handle(DeletePayEntityEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("Se ha eliminado el pago con id: "+notification.PayId+" con un monto de: "+notification.PayAmount+" en la fecha: "+notification.CreatedAt+" y idEvent: "+notification.id);
        return Task.CompletedTask;
    }
}