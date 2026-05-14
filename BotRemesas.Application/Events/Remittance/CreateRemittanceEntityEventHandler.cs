using BotRemesas.Domain.Events.Remittance.Create;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BotRemesas.Application.Events.Remittance;

public class CreateRemittanceEntityEventHandler : INotificationHandler<CreateRemittanceEntityEvent>
{
    private readonly ILogger<CreateRemittanceEntityEventHandler> logger;
    public CreateRemittanceEntityEventHandler(ILogger<CreateRemittanceEntityEventHandler> logger)
    {
        this.logger = logger;
    }
    public Task Handle(CreateRemittanceEntityEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("Se ha creado una remesa con id: "+notification.RemittanceId+" al cliente: "+notification.Customer+" en la fecha: "+notification.CreatedAt+" y idEvent: "+notification.id);
        return Task.CompletedTask;
    }
}