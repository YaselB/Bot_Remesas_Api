using AutoMapper;
using BotRemesas.Application.Command.Generic.Create;
using BotRemesas.Application.Common.Error;
using BotRemesas.Application.Interfaces.Repository.Admin;
using BotRemesas.Application.Interfaces.Repository.Generic;
using BotRemesas.Application.Interfaces.Repository.User;
using BotRemesas.Domain.Common.ResultT;
using BotRemesas.Domain.Entities.User;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BotRemesas.Application.Command.User.Create;

public class CreateUserEntityCommandhandler : CreateGenericEntityCommandHandler<UserEntity, CreateUserEntityCommand>
{
    private readonly IUserRepository userRepository;
    private readonly ILogger<UserEntity> logger;
    private readonly IAdminRepository adminRepository;
    public CreateUserEntityCommandhandler(IUserRepository repository, IMapper mapper , ILogger<UserEntity> logger , IAdminRepository adminRepository) : base(repository, mapper)
    {
        userRepository = repository;
        this.logger = logger;
        this.adminRepository = adminRepository;
    }
    public override async Task<Result<Unit>> Handle(CreateUserEntityCommand request, CancellationToken cancellationToken)
    {
        var admin = await adminRepository.GetByIdTelegram(request.IdUserTelegram , cancellationToken);
        if(admin != null)
        {
            logger.LogWarning("Ese id de Telegram ya ha sido usado por un admin: "+request.IdUserTelegram);
            return Result<Unit>.Failure(new AdminIdUserTelegramRegisteredError());
        }
        var user = await userRepository.GetByIdUserTelegram(request.IdUserTelegram , cancellationToken);
        if(user != null)
        {
            logger.LogWarning("Ese id de telegram ya ha sido usado por un usuario: "+request.IdUserTelegram);
            return Result<Unit>.Failure(new UserRegistered());
        }
        var newUser = UserEntity.Create(request.Name , request.IdUserTelegram ,request.AdminId , request.PerCent);
        await userRepository.AddAsync(newUser);
        return Result<Unit>.Success(Unit.Value);
    }
}