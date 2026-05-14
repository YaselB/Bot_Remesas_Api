using AutoMapper;
using BotRemesas.Application.Features.Pay.Dto;
using BotRemesas.Application.Interfaces.Repository;
using BotRemesas.Application.Interfaces.Repository.Generic;
using BotRemesas.Application.Query.Generic.GetAll;
using BotRemesas.Domain.Common.ResultT;
using BotRemesas.Domain.Entities.Pay;
using Microsoft.Extensions.Logging;

namespace BotRemesas.Application.Query.Pay.GetAll;

public class GetAllPayEntityQueryHandler : GetAllGenericEntityQueryHandler<PayEntity, PayResultDto, GetAllPayEntityQuery>
{
    private readonly IPayRepository pay;
    private readonly ILogger<PayEntity> logger;
    public GetAllPayEntityQueryHandler(IPayRepository genericRepository, IMapper mapper , ILogger<PayEntity> logger) : base(genericRepository, mapper)
    {
        pay = genericRepository;
        this.logger = logger;
    }
    public override async Task<Result<IReadOnlyList<PayResultDto>>> Handle(GetAllPayEntityQuery request, CancellationToken cancellationToken)
    {
        var payEntities = await pay.GetAll(cancellationToken);
        var payEntitiesBackList = new List<PayResultDto>();
        foreach(var i in payEntities)
        {
            var payEntityBackList = new PayResultDto
            {
                Amount = i.UserPay,
                userName = i.Users?.Name,
                Id = i.Id,
                UserId = i.UserId
            };
            payEntitiesBackList.Add(payEntityBackList);
        }
        return Result<IReadOnlyList<PayResultDto>>.Success(payEntitiesBackList);
    }
}