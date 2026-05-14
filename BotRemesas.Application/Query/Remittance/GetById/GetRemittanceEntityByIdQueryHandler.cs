using AutoMapper;
using BotRemesas.Application.Common.Error;
using BotRemesas.Application.Features.Remittance.Dto;
using BotRemesas.Application.Interfaces.Repository.Generic;
using BotRemesas.Application.Interfaces.Repository.Remittance;
using BotRemesas.Application.Query.Generic.GetById;
using BotRemesas.Domain.Common.ResultT;
using BotRemesas.Domain.Entities.Remittance;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BotRemesas.Application.Query.Remittance.GetById;

public class GetRemittanceEntityByIdQueryHandler : GetGenericEntityByIdQueryHandler<RemittanceEntity, GetRemittanceEntityByIdQuery, RemittanceResultDto>
{
    private readonly IRemittanceRepository remittance;
    private readonly ILogger<RemittanceEntity> logger;
    public GetRemittanceEntityByIdQueryHandler(IRemittanceRepository genericRepository, IMapper mapper , ILogger<RemittanceEntity> logger) : base(genericRepository, mapper)
    {
        this.remittance = genericRepository;
        this.logger = logger;
    }
    public override async Task<Result<RemittanceResultDto?>> Handle(GetRemittanceEntityByIdQuery request, CancellationToken cancellationToken)
    {
        var remittanceEntity = await remittance.GetById(request.Id , cancellationToken);
        if(remittanceEntity == null)
        {
            logger.LogWarning("La remesa con id: "+request.Id+" no se encuentra");
            return Result<RemittanceResultDto?>.Failure(new RemittanceNotFoundError());
        }
        var remittanceBack = new RemittanceResultDto
        {
            Address = remittanceEntity.Account?.Account,
            Amount = remittanceEntity.Amount,
            Customer = remittanceEntity.Customer,
            Enabled = remittanceEntity.Enabled,
            UrlImage = remittanceEntity.urlImage,
            userName = remittanceEntity.User?.Name,
            Id = remittanceEntity.Id,
            UserId = remittanceEntity.User?.Id
        };
        return Result<RemittanceResultDto?>.Success(remittanceBack);
    }
}