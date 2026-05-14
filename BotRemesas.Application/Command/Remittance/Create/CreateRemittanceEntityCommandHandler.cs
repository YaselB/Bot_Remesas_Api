using AutoMapper;
using BotRemesas.Application.Command.Generic.Create;
using BotRemesas.Application.Common.Error;
using BotRemesas.Application.Interfaces.Repository.Generic;
using BotRemesas.Application.Interfaces.Repository.Remittance;
using BotRemesas.Application.Interfaces.Repository.User;
using BotRemesas.Domain.Common.ResultT;
using BotRemesas.Domain.Entities.Remittance;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BotRemesas.Application.Command.Remittance.Create;

public class CreateRemittanceEntityCommandandler : CreateGenericEntityCommandHandler<RemittanceEntity, CreateRemittanceEntityCommand>
{
    private readonly IUserRepository user;
    private readonly IRemittanceRepository remittanceRepository;
    private readonly ILogger<RemittanceEntity> logger;
    public CreateRemittanceEntityCommandandler(IRemittanceRepository repository, IMapper mapper , ILogger<RemittanceEntity> logger , IUserRepository userRepository) : base(repository, mapper)
    {
        this.user = userRepository;
        this.remittanceRepository = repository;
        this.logger = logger;
    }
    public override async Task<Result<Unit>> Handle(CreateRemittanceEntityCommand request, CancellationToken cancellationToken)
    {
        var userEntity = await user.GetById(request.UserId , cancellationToken);
        if(userEntity == null)
        {
            logger.LogWarning("El usuario con id: "+request.UserId+" no se encuentra");
            return Result<Unit>.Failure(new UsernotFoundError());
        }
        var remittance = RemittanceEntity.Create(request.UserId ,request.Amount , request.urlImage ,request.AccountId ,request.Customer);
        await remittanceRepository.AddAsync(remittance);
        return Result<Unit>.Success(Unit.Value);
    }
}