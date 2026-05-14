using BotRemesas.Application.Features.Admin.Dto;
using BotRemesas.Application.Query.Generic.GetAll;
using BotRemesas.Domain.Entities.Admin;

namespace BotRemesas.Application.Query.Admin.GetAll;
public class GetAllAdminEntityQuery : GetAllGenericEntityQuery<AdminEntity , AdminResultDto>
{
    
}