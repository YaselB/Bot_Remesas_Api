using BotRemesas.Application.Command.Generic.Delete;
using BotRemesas.Application.Common.Error;
using BotRemesas.Application.Interfaces.Repository.Generic;
using BotRemesas.Application.Interfaces.Repository.User;
using BotRemesas.Domain.Common.ResultT;
using BotRemesas.Domain.Entities.User;
using BotRemesas.Domain.Events.User.Delete;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BotRemesas.Application.Command.User.Delete;

public class DeleteUserEntityCommandHandler : DeleteGenericEntityCommandHandler<UserEntity, DeleteUserEntityCommand>
{
    private readonly IUserRepository user;
    private readonly ILogger<UserEntity> logger;
    public DeleteUserEntityCommandHandler(IUserRepository genericRepository , ILogger<UserEntity> logger) : base(genericRepository)
    {
        user = genericRepository;
        this.logger = logger;
    }
    public override async Task<Result<Unit>> Handle(DeleteUserEntityCommand request, CancellationToken cancellationToken)
    {
        var userDelete = await user.GetById(request.Id , cancellationToken);
        if(userDelete == null)
        {
            logger.LogWarning("El usuario con id: "+request.Id+" no esta registrado");
            return Result<Unit>.Failure(new UsernotFoundError());
        }
        var DeleteUserDomainEvent = new DeleteUserEntityEvent(userDelete.Id , userDelete.Name);
        userDelete.AddDomainEvent(DeleteUserDomainEvent);
        await user.Delete(userDelete);
        return Result<Unit>.Success(Unit.Value);
    }
}