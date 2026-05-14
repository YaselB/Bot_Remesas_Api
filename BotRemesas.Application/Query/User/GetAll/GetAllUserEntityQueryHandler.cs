using AutoMapper;
using BotRemesas.Application.Features.User.Dto;
using BotRemesas.Application.Interfaces.Repository.User;
using BotRemesas.Application.Query.Generic.GetAll;
using BotRemesas.Domain.Entities.User;

namespace BotRemesas.Application.Query.User.GetAll;

public class GetAllUserEntityQueryHandler : GetAllGenericEntityQueryHandler<UserEntity, UserResultDto, GetAllUserEntityQuery>
{
    public GetAllUserEntityQueryHandler(IUserRepository genericRepository, IMapper mapper) : base(genericRepository, mapper)
    {
    }
}