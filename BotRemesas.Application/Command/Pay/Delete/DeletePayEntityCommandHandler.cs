using System.ComponentModel;
using BotRemesas.Application.Command.Generic.Delete;
using BotRemesas.Application.Common.Error;
using BotRemesas.Application.Interfaces.Repository;
using BotRemesas.Application.Interfaces.Repository.Generic;
using BotRemesas.Domain.Common.ResultT;
using BotRemesas.Domain.Entities.Pay;
using BotRemesas.Domain.Events.Pay.Delete;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BotRemesas.Application.Command.Pay.Delete;

public class DeletePayEntityCommandHandler : DeleteGenericEntityCommandHandler<PayEntity, DeletePayEntityCommand>
{
    private readonly IPayRepository pay;
    private readonly ILogger<PayEntity> logger;
    public DeletePayEntityCommandHandler(IPayRepository genericRepository , ILogger<PayEntity> logger) : base(genericRepository)
    {
        pay = genericRepository;
        this.logger = logger;
    }
    public override async Task<Result<Unit>> Handle(DeletePayEntityCommand request, CancellationToken cancellationToken)
    {
        var payEntity = await pay.GetById(request.Id , cancellationToken);
        if(payEntity == null)
        {
            logger.LogWarning("El pago con id: "+request.Id+" no se encuentra");
            return Result<Unit>.Failure(new PayEntityNotFoundError());
        }
        var DeletePayEntityDomainEvent = new DeletePayEntityEvent(payEntity.Id ,payEntity.UserPay);
        payEntity.AddDomainEvent(DeletePayEntityDomainEvent);
        await pay.Delete(payEntity);
        return Result<Unit>.Success(Unit.Value);
    }
}