using AutoMapper;
using BotRemesas.Application.Command.Generic.Update;
using BotRemesas.Application.Common.Error;
using BotRemesas.Application.Interfaces.Repository.Admin;
using BotRemesas.Application.Interfaces.Repository.Generic;
using BotRemesas.Domain.Common.ResultT;
using BotRemesas.Domain.Entities.Admin;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BotRemesas.Application.Command.Admin.Update;

public class UpdateAdminEntityCommandHandler : UpdateGenericEntityCommandHandler<AdminEntity, UpdateAdminEntityCommand>
{
    private readonly IAdminRepository adminRepository;
    private readonly ILogger<AdminEntity> logger;
    public UpdateAdminEntityCommandHandler(IMapper mapper, IAdminRepository repository , ILogger<AdminEntity> logger) : base(mapper, repository)
    {
        adminRepository = repository;
        this.logger = logger;
    }
    public override async Task<Result<Unit>> Handle(UpdateAdminEntityCommand request, CancellationToken cancellationToken)
    {
        var admin = await adminRepository.GetById(request.Id , cancellationToken);
        if(admin == null)
        {
            logger.LogWarning("El admin con id: "+request.Id+" no se encuentra");
            return Result<Unit>.Failure(new AdminNotFoundError());
        }
        admin.Update(request.Name);
        await adminRepository.Update(admin);
        return Result<Unit>.Success(Unit.Value);
    }
}