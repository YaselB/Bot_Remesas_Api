using BotRemesas.Domain.Events.Account.Delete;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BotRemesas.Application.Events.Account;

public class DeleteAccountEntityEventHandler : INotificationHandler<DeleteAccountEntityEvent>
{
    private readonly ILogger<DeleteAccountEntityEventHandler> logger;
    public DeleteAccountEntityEventHandler(ILogger<DeleteAccountEntityEventHandler> logger)
    {
        this.logger = logger;
    }
    public Task Handle(DeleteAccountEntityEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("Se ha eliminado la cuenta con id: "+notification.AccountId+" y direccion: "+notification.Account+" en la fecha: "+notification.CreatedAt+" y con idEvent: "+notification.id);
        return Task.CompletedTask;
    }
}