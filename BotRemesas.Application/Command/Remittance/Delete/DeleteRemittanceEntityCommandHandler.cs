using BotRemesas.Application.Command.Generic.Delete;
using BotRemesas.Application.Common.Error;
using BotRemesas.Application.Interfaces.Repository.Generic;
using BotRemesas.Application.Interfaces.Repository.Remittance;
using BotRemesas.Domain.Common.ResultT;
using BotRemesas.Domain.Entities.Remittance;
using BotRemesas.Domain.Events.Remittance.Delete;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BotRemesas.Application.Command.Remittance.Delete;

public class DeleteRemittanceEntityCommandHandler : DeleteGenericEntityCommandHandler<RemittanceEntity, DeleteRemittanceEntityCommand>
{
    private readonly IRemittanceRepository remittanceRepository;
    private readonly ILogger<RemittanceEntity> logger;
    public DeleteRemittanceEntityCommandHandler(IRemittanceRepository genericRepository , ILogger<RemittanceEntity> logger) : base(genericRepository)
    {
        remittanceRepository = genericRepository;
        this.logger = logger;
    }
    public override async Task<Result<Unit>> Handle(DeleteRemittanceEntityCommand request, CancellationToken cancellationToken)
    {
        var remittance = await remittanceRepository.GetById(request.Id , cancellationToken);
        if(remittance == null)
        {
            logger.LogWarning(" La remesa con id: "+request.Id+" no esta registrada");
            return Result<Unit>.Failure(new RemittanceNotFoundError());
        }
        var DeleteRemittanceEntityDomainEvent = new DeleteRemittanceEntityEvent(remittance.Id , remittance.UserId);
        remittance.AddDomainEvent(DeleteRemittanceEntityDomainEvent);
        await remittanceRepository.Delete(remittance , cancellationToken);
        return Result<Unit>.Success(Unit.Value);
    }
}