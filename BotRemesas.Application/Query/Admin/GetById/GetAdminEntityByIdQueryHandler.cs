using System.Runtime;
using AutoMapper;
using BotRemesas.Application.Common.Error;
using BotRemesas.Application.Features.Admin.AdminProfile;
using BotRemesas.Application.Features.Admin.Dto;
using BotRemesas.Application.Interfaces.Repository.Admin;
using BotRemesas.Application.Interfaces.Repository.Generic;
using BotRemesas.Application.Query.Generic.GetById;
using BotRemesas.Domain.Common.ResultT;
using BotRemesas.Domain.Entities.Admin;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BotRemesas.Application.Query.Admin.GetById;

public class GetAdminEntityByIdQueryHandler : GetGenericEntityByIdQueryHandler<AdminEntity, GetAdminEntityByIdQuery, AdminResultDto>
{
    private readonly IAdminRepository admin;
    private readonly ILogger<AdminEntity> logger;
    private readonly IMapper mapper1;
    public GetAdminEntityByIdQueryHandler(IAdminRepository genericRepository, IMapper mapper , ILogger<AdminEntity> logger) : base(genericRepository, mapper)
    {
        admin = genericRepository;
        this.logger = logger;
        mapper1 = mapper;
    }
    public override async Task<Result<AdminResultDto?>> Handle(GetAdminEntityByIdQuery request, CancellationToken cancellationToken)
    {
        var adminEntity = await admin.GetById(request.Id , cancellationToken);
        if(adminEntity == null)
        {
            logger.LogWarning("El admin con id: "+request.Id+" no se encuentra");
            return Result<AdminResultDto?>.Failure(new AdminNotFoundError());
        }
        var adminResult = mapper1.Map<AdminResultDto>(adminEntity);
        return Result<AdminResultDto?>.Success(adminResult);
    }
}