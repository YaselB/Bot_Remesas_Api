using BotRemesas.Domain.Events.Remittance.Delete;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BotRemesas.Application.Events.Remittance;

public class DeleteRemittanceEntityCommandHandler : INotificationHandler<DeleteRemittanceEntityEvent>
{
    private readonly ILogger<DeleteRemittanceEntityCommandHandler> logger;
    public DeleteRemittanceEntityCommandHandler(ILogger<DeleteRemittanceEntityCommandHandler> logger)
    {
        this.logger = logger;
    }
    public Task Handle(DeleteRemittanceEntityEvent notification, CancellationToken cancellationToken)
    {
        logger.LogWarning("Se ha eliminado exitosamente la remesa con id: "+notification.RemittanceId+" hecha por el usuario con id: "+notification.UserId+" en la fecha: "+notification.CreatedAt+" y idEvent: "+notification.id);
        return Task.CompletedTask;
    }
}