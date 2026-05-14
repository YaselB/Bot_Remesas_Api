using BotRemesas.Domain.Events.Pay.Create;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BotRemesas.Application.Events.Pay;

public class CreatePayEntityEventHandler : INotificationHandler<CreatePayEntityEvent>
{
    private readonly ILogger<CreatePayEntityEventHandler> logger;
    public CreatePayEntityEventHandler(ILogger<CreatePayEntityEventHandler> logger)
    {
        this.logger = logger;
    }
    public Task Handle(CreatePayEntityEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("Se ha creado un nuevo pago para el usuario con id: "+notification.UserId+" con id de pag: "+notification.PayId+" en la fecha: "+notification.CreatedAt+" y con idEvent: "+notification.id);
        return Task.CompletedTask;
    }
}