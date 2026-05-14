using AutoMapper;
using BotRemesas.Application.Features.Admin.Dto;
using BotRemesas.Application.Interfaces.Repository.Generic;
using BotRemesas.Application.Query.Generic.GetAll;
using BotRemesas.Domain.Entities.Admin;

namespace BotRemesas.Application.Query.Admin.GetAll;

public class GetAllAdminEntityQueryHandler : GetAllGenericEntityQueryHandler<AdminEntity, AdminResultDto, GetAllAdminEntityQuery>
{
    public GetAllAdminEntityQueryHandler(IGenericRepository<AdminEntity> genericRepository, IMapper mapper) : base(genericRepository, mapper)
    {
    }
}