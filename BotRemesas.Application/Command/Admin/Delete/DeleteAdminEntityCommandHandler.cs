using BotRemesas.Application.Command.Generic.Delete;
using BotRemesas.Application.Common.Error;
using BotRemesas.Application.Interfaces.Repository.Admin;
using BotRemesas.Domain.Common.ResultT;
using BotRemesas.Domain.Entities.Admin;
using BotRemesas.Domain.Events.Admin.Delete;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BotRemesas.Application.Command.Admin.Delete;

public class DeleteAdminEntityCommandHandler : DeleteGenericEntityCommandHandler<AdminEntity, DeleteAdminEntityCommand>
{
    private readonly IAdminRepository adminRepository;
    private readonly ILogger<AdminEntity> logger;
    public DeleteAdminEntityCommandHandler(IAdminRepository genericRepository , ILogger<AdminEntity> logger) : base(genericRepository)
    {
        adminRepository = genericRepository;
        this.logger = logger;
    }
    public override async Task<Result<Unit>> Handle(DeleteAdminEntityCommand request, CancellationToken cancellationToken)
    {
        var admin = await adminRepository.GetById(request.Id , cancellationToken);
        if(admin == null)
        {
            logger.LogWarning("El admin con id: "+request.Id+" no se encuentra");
            return Result<Unit>.Failure(new AdminNotFoundError());
        }
        var DeleteAdminDomainEvent = new DeleteAdminEntityEvent(admin.Id , admin.Name);
        admin.AddDomainEvent(DeleteAdminDomainEvent);
        await adminRepository.Delete(admin , cancellationToken);
        return Result<Unit>.Success(Unit.Value);
    }
}