using AutoMapper;
using BotRemesas.Application.Common.Error;
using BotRemesas.Application.Features.HistoryRemittance.Dto;
using BotRemesas.Application.Interfaces.Repository.HistoryRemittance;
using BotRemesas.Application.Interfaces.Repository.User;
using BotRemesas.Domain.Common.ResultT;
using BotRemesas.Domain.Entities.HistoryRemittances;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BotRemesas.Application.Query.HistoryRemittance.GetByUserId;

public class GetHistoryRemittanceByUserIdQueryHandler : IRequestHandler<GetHistoryRemittanceByUserIdQuery, Result<IReadOnlyList<HistoryRemittanceDto>>>
{
    private readonly IUserRepository userRepository;
    private readonly IHistoryRemittanceRepository historyRemittance;
    private readonly ILogger<HistoryRemittanceEntity> logger;
    private readonly IMapper mapper;
    public GetHistoryRemittanceByUserIdQueryHandler(IUserRepository user , IHistoryRemittanceRepository historyRemittance , ILogger<HistoryRemittanceEntity> logger , IMapper mapper)
    {
        userRepository = user;
        this.historyRemittance = historyRemittance;
        this.logger = logger;
        this.mapper = mapper;
    }
    public async Task<Result<IReadOnlyList<HistoryRemittanceDto>>> Handle(GetHistoryRemittanceByUserIdQuery request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetById(request.UserId , cancellationToken);
        if(user == null)
        {
            logger.LogWarning("El usuario con id: "+request.UserId+" no existe");
            return Result<IReadOnlyList<HistoryRemittanceDto>>.Failure(new UsernotFoundError());
        }
        var histories = await historyRemittance.GetByUserId(request.UserId , cancellationToken);
        var historiesBack = new List<HistoryRemittanceDto>();
        foreach(var i in histories)
        {
            historiesBack.Add(mapper.Map<HistoryRemittanceDto>(i));
        }
        return Result<IReadOnlyList<HistoryRemittanceDto>>.Success(historiesBack);
    }
}