using BotRemesas.Application.Features.User.Dto;
using BotRemesas.Application.Query.Generic.GetById;
using BotRemesas.Domain.Entities.User;

namespace BotRemesas.Application.Query.User.GetById;
public class GetUserEntityByIdQuery : GetGenericEntityByIdQuery<UserEntity  ,UserResultDto>{}