using BotRemesas.Domain.Events.Remittance.Update;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BotRemesas.Application.Events.Remittance;

public class UpdateRemittanceEntityEventHandler : INotificationHandler<UpdateRemittanceEvent>
{
    private readonly ILogger<UpdateRemittanceEntityEventHandler> logger;
    public UpdateRemittanceEntityEventHandler(ILogger<UpdateRemittanceEntityEventHandler> logger)
    {
        this.logger = logger;
    }
    public Task Handle(UpdateRemittanceEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("Se ha actualizado la remesa con id: "+notification.RemittanceId+" con el Cliente: "+notification.Customer+" fecha: "+notification.CreatedAt+" y con idEvent: "+notification.id);
        return Task.CompletedTask;
    }
}