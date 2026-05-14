using AutoMapper;
using BotRemesas.Application.Command.Generic.Create;
using BotRemesas.Application.Common.Error;
using BotRemesas.Application.Interfaces.Repository;
using BotRemesas.Application.Interfaces.Repository.Generic;
using BotRemesas.Application.Interfaces.Repository.User;
using BotRemesas.Domain.Common.ResultT;
using BotRemesas.Domain.Entities.Pay;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BotRemesas.Application.Command.Pay.Create;

public class CreatePayEntityCommandHandler : CreateGenericEntityCommandHandler<PayEntity, CreatePayEntityCommand>
{
    private readonly IPayRepository pay;
    private readonly ILogger<PayEntity> logger;
    public CreatePayEntityCommandHandler(IPayRepository repository, IMapper mapper , ILogger<PayEntity> logger1) : base(repository, mapper)
    {
       pay = repository;
       logger = logger1;
    }
    public override async Task<Result<Unit>> Handle(CreatePayEntityCommand request, CancellationToken cancellationToken)
    {
        var payEntity = await pay.GetByUserId(request.UserId , cancellationToken);
        if(payEntity != null)
        {
            logger.LogWarning("El usuario con id: "+request.UserId+" ya tiene registrado su pago");
            return Result<Unit>.Failure(new PayEntityRegistered());
        }
        var newPay = PayEntity.Create(request.UserId);
        await pay.AddAsync(newPay , cancellationToken);
        return Result<Unit>.Success(Unit.Value);
    }
}