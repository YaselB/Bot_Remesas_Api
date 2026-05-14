using AutoMapper;
using BotRemesas.Application.Command.Generic.Update;
using BotRemesas.Application.Common.Error;
using BotRemesas.Application.Interfaces.Repository.Admin;
using BotRemesas.Application.Interfaces.Repository.User;
using BotRemesas.Domain.Common.ResultT;
using BotRemesas.Domain.Entities.User;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BotRemesas.Application.Command.User.Update;

public class UpdateUserEntityCommandHandler : UpdateGenericEntityCommandHandler<UserEntity, UpdateUserEntityCommand>
{
    private readonly IUserRepository userRepository;
    private readonly IAdminRepository adminRepository;
    private readonly ILogger<UserEntity> logger;
    public UpdateUserEntityCommandHandler(IMapper mapper, IUserRepository genericRepository, ILogger<UserEntity> logger, IAdminRepository adminRepository) : base(mapper, genericRepository)
    {
        userRepository = genericRepository;
        this.adminRepository = adminRepository;
        this.logger = logger;
    }
    public override async Task<Result<Unit>> Handle(UpdateUserEntityCommand request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetById(request.Id, cancellationToken);
        if (user == null)
        {
            logger.LogWarning("El usuario con ese id: " + request.Id + " no esta registrado");
            return Result<Unit>.Failure(new UsernotFoundError());
        }
        if (user.IdUserTelegram != request.IdUserTelegram)
        {
            var userByIdTelegram = await adminRepository.GetByIdTelegram(request.IdUserTelegram, cancellationToken);
            if (userByIdTelegram != null)
            {
                logger.LogWarning("Ese id de Telegram ya ha sido usado por otro usuario");
                return Result<Unit>.Failure(new UserRegistered());
            }
        }
        var admin = await adminRepository.GetByIdTelegram(request.IdUserTelegram , cancellationToken);
        if(admin != null)
        {
            logger.LogWarning("Ese id de telegram: "+request.IdUserTelegram+" ya ha sido usado por otro admin");
            return Result<Unit>.Failure(new AdminRegistered());
        }
        user.Update(request.Name , request.IdUserTelegram , request.PerCent);
        logger.LogWarning(user.PerCent.ToString());
        await userRepository.Update(user , cancellationToken);
        return Result<Unit>.Success(Unit.Value);
    }
}