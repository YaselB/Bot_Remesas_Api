using BotRemesas.Application.Features.User.Dto;
using BotRemesas.Application.Query.Generic.GetAll;
using BotRemesas.Domain.Entities.User;

namespace BotRemesas.Application.Query.User.GetAll;
public class GetAllUserEntityQuery : GetAllGenericEntityQuery<UserEntity , UserResultDto>
{
    
}