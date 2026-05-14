using BotRemesas.Domain.Events.Account.Update;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BotRemesas.Application.Events.Account;

public class UpdateAccountEntityEventHandler : INotificationHandler<UpdateAccountEntityEvent>
{
    private readonly ILogger<UpdateAccountEntityEventHandler> logger;
    public UpdateAccountEntityEventHandler(ILogger<UpdateAccountEntityEventHandler> logger)
    {
        this.logger = logger;
    }
    public Task Handle(UpdateAccountEntityEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("Se ha actualizado la cuenta: "+notification.Account+" con el nuevo balance: "+notification.Balance+" en la fecha: "+notification.CreatedAt+" y con idEvent: "+notification.id);
        return Task.CompletedTask;
    }
}