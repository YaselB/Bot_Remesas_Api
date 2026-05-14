using AutoMapper;
using BotRemesas.Application.Common.Error;
using BotRemesas.Application.Features.Pay.Dto;
using BotRemesas.Application.Interfaces.Repository;
using BotRemesas.Application.Query.Generic.GetById;
using BotRemesas.Domain.Common.ResultT;
using BotRemesas.Domain.Entities.Pay;
using Microsoft.Extensions.Logging;

namespace BotRemesas.Application.Query.Pay.GetById;

public class GetPayEntityByIdQueryHandler : GetGenericEntityByIdQueryHandler<PayEntity, GetPayEntityByIdQuery, PayResultDto>
{
    private readonly ILogger<PayEntity> logger;
    private readonly IPayRepository pay;
    public GetPayEntityByIdQueryHandler(IPayRepository genericRepository, IMapper mapper , ILogger<PayEntity> logger) : base(genericRepository, mapper)
    {
        this.logger = logger;
        pay = genericRepository;
    }
    public override async Task<Result<PayResultDto?>> Handle(GetPayEntityByIdQuery request, CancellationToken cancellationToken)
    {
        var payEntity = await pay.GetById(request.Id , cancellationToken);
        if(payEntity == null)
        {
            logger.LogWarning("El pago con id: "+request.Id+" no se encuentra");
            return Result<PayResultDto?>.Failure(new PayEntityNotFoundError());
        }
        var payEntityBack = new PayResultDto
        {
            Amount = payEntity.UserPay,
            userName = payEntity.Users?.Name,
            Id = payEntity.Id,
            UserId = payEntity.UserId
        };
        return Result<PayResultDto?>.Success(payEntityBack);
    }

}