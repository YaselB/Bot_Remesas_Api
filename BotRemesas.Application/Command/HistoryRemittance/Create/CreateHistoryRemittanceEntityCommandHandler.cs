using AutoMapper;
using BotRemesas.Application.Command.Generic.Create;
using BotRemesas.Application.Common.Error;
using BotRemesas.Application.Interfaces.Repository.HistoryRemittance;
using BotRemesas.Application.Interfaces.Repository.User;
using BotRemesas.Domain.Common.ResultT;
using BotRemesas.Domain.Entities.HistoryRemittances;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BotRemesas.Application.Command.HistoryRemittance.Create;



public class CreateHistoryRemittanceEntityCommandHandler : CreateGenericEntityCommandHandler<HistoryRemittanceEntity, CreateHistoryRemittanceEntityCommand>
{
    private readonly IUserRepository userRepository;
    private readonly IHistoryRemittanceRepository historyRemittance;
    private readonly ILogger<HistoryRemittanceEntity> logger;
    public CreateHistoryRemittanceEntityCommandHandler(IHistoryRemittanceRepository repository, IMapper mapper , IUserRepository userRepository , ILogger<HistoryRemittanceEntity> logger) : base(repository, mapper)
    {
        this.userRepository = userRepository;
        historyRemittance = repository;
        this.logger = logger;
    }
    public override async Task<Result<Unit>> Handle(CreateHistoryRemittanceEntityCommand request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetById(request.UserId , cancellationToken);
        if(user == null)
        {
            logger.LogWarning("El usuario con id: "+request.UserId+" no existe");
            return Result<Unit>.Failure(new UsernotFoundError());
        }
        var factor = user.PerCent / 100;
        var amount = request.Amount - request.Amount * factor;
        logger.LogWarning(amount.ToString());
        var history = HistoryRemittanceEntity.Create( amount ,request.Amount ,request.Customer ,request.UserId ,request.Account);
        await historyRemittance.AddAsync(history , cancellationToken);
        return Result<Unit>.Success(Unit.Value);
    }
}