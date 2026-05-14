using AutoMapper;
using BotRemesas.Application.Command.Generic.Update;
using BotRemesas.Application.Common.Error;
using BotRemesas.Application.Interfaces.Repository;
using BotRemesas.Domain.Common.ResultT;
using BotRemesas.Domain.Entities.Pay;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BotRemesas.Application.Command.Pay.Update;

public class UpdatePayEntityCommandHandler : UpdateGenericEntityCommandHandler<PayEntity, UpdatePayEntityCommand>
{
    private readonly IPayRepository pay;
    private readonly ILogger<PayEntity> logger;
    public UpdatePayEntityCommandHandler(IMapper mapper, IPayRepository genericRepository, ILogger<PayEntity> logger) : base(mapper, genericRepository)
    {
        this.logger = logger;
        pay = genericRepository;
    }
    public override async Task<Result<Unit>> Handle(UpdatePayEntityCommand request, CancellationToken cancellationToken)
    {
        var payEntity = await pay.GetByUserId(request.UserId, cancellationToken);
        if (payEntity == null)
        {
            logger.LogWarning("El usuario con id: " + request.UserId + " no tiene un pago registrado");
            return Result<Unit>.Failure(new PayEntityNotFoundByUserIdError());
        }
        if (request.EnabledSum)
        {
            double percent = payEntity.Users?.PerCent ?? 0.0;
            double percentToQuit = request.amount * (percent / 100.0);
            double QuantityToSum = request.amount - percentToQuit;
            payEntity.UserPay += QuantityToSum;
            payEntity.Update(payEntity.UserPay);
            await pay.Update(payEntity, cancellationToken);
            return Result<Unit>.Success(Unit.Value);
        }
        if (payEntity.UserPay < request.amount)
        {
            logger.LogWarning("No se puede realizar el retiro ,porque el pago: " + payEntity.Id + " no contiene saldo suficiente");
            return Result<Unit>.Failure(new PayNotHaveEnoughBalanceError());
        }
        payEntity.UserPay -= request.amount;
        payEntity.Update(payEntity.UserPay);
        await pay.Update(payEntity);
        return Result<Unit>.Success(Unit.Value);
    }
}