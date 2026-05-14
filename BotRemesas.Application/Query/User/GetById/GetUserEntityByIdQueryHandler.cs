using AutoMapper;
using BotRemesas.Application.Common.Error;
using BotRemesas.Application.Features.User.Dto;
using BotRemesas.Application.Interfaces.Repository.User;
using BotRemesas.Application.Query.Generic.GetById;
using BotRemesas.Domain.Common.ResultT;
using BotRemesas.Domain.Entities.User;
using Microsoft.Extensions.Logging;

namespace BotRemesas.Application.Query.User.GetById;

public class GetUserEntityByIdQueryHandler : GetGenericEntityByIdQueryHandler<UserEntity, GetUserEntityByIdQuery, UserResultDto>
{
    private readonly IUserRepository userRepository;
    private readonly ILogger<UserEntity> logger;
    public GetUserEntityByIdQueryHandler(IUserRepository genericRepository, IMapper mapper , ILogger<UserEntity> logger) : base(genericRepository, mapper)
    {
        userRepository = genericRepository;
        this.logger = logger;
    }
    public override async Task<Result<UserResultDto?>> Handle(GetUserEntityByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetById(request.Id , cancellationToken);
        if(user == null)
        {
            logger.LogWarning("El usuario con id: "+request.Id+" no esta registrado");
            return Result<UserResultDto?>.Failure(new UsernotFoundError());
        }
        var userResult = mapper.Map<UserResultDto>(user);
        return Result<UserResultDto?>.Success(userResult);
    }
}