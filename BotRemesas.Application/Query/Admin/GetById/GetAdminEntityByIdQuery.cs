using BotRemesas.Application.Features.Admin.Dto;
using BotRemesas.Application.Query.Generic.GetById;
using BotRemesas.Domain.Entities.Admin;

namespace BotRemesas.Application.Query.Admin.GetById;
public class GetAdminEntityByIdQuery : GetGenericEntityByIdQuery<AdminEntity , AdminResultDto>{}