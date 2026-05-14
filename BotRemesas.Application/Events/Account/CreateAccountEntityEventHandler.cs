using BotRemesas.Domain.Events.Account.Create;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BotRemesas.Application.Events.Account;

public class CreateAccountEntityEventHandler : INotificationHandler<CreateAccountEntityEvent>
{
    private readonly ILogger<CreateAccountEntityEventHandler> logger;
    public CreateAccountEntityEventHandler(ILogger<CreateAccountEntityEventHandler> logger)
    {
        this.logger = logger;
    }
    public Task Handle(CreateAccountEntityEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("Se ha creado una cuenta nueva con id: "+notification.AccountId+" y direccion: "+notification.AccountAddress+" en la fecha: "+notification.CreatedAt+" y con idEvent: "+notification.id);
        return Task.CompletedTask;
    }
}