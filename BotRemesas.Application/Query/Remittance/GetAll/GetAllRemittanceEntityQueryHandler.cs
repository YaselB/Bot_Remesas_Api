using AutoMapper;
using BotRemesas.Application.Features.Remittance.Dto;
using BotRemesas.Application.Interfaces.Repository.Generic;
using BotRemesas.Application.Interfaces.Repository.Remittance;
using BotRemesas.Application.Interfaces.Repository.User;
using BotRemesas.Application.Query.Generic.GetAll;
using BotRemesas.Domain.Common.ResultT;
using BotRemesas.Domain.Entities.Remittance;

namespace BotRemesas.Application.Query.Remittance.GetAll;

public class GetAllRemittanceEntityQueryHandler : GetAllGenericEntityQueryHandler<RemittanceEntity, RemittanceResultDto, GetAllRemittanceEntityQuery>
{
    private readonly IRemittanceRepository remittanceRepository;
    public GetAllRemittanceEntityQueryHandler(IRemittanceRepository genericRepository, IMapper mapper) : base(genericRepository, mapper)
    {
        remittanceRepository = genericRepository;
    }
    public override async Task<Result<IReadOnlyList<RemittanceResultDto>>> Handle(GetAllRemittanceEntityQuery request, CancellationToken cancellationToken)
    {
        var remittances = await remittanceRepository.GetAll(cancellationToken);
        var ListBack = new List<RemittanceResultDto>();
        foreach( var i in remittances)
        {
            var remittance = new RemittanceResultDto
            {
                Address = i.Account?.Account,
                Amount = i.Amount,
                Customer = i.Customer,
                Enabled = i.Enabled,
                UrlImage = i.urlImage,
                userName = i.User?.Name,
                Id = i.Id,
                UserId = i.User?.Id
            };
            ListBack.Add(remittance);
        }
        return Result<IReadOnlyList<RemittanceResultDto>>.Success(ListBack);
    }
}