using AutoMapper;
using BotRemesas.Application.Command.Generic.Update;
using BotRemesas.Application.Common.Error;
using BotRemesas.Application.Interfaces.Repository.Admin;
using BotRemesas.Application.Interfaces.Repository.Generic;
using BotRemesas.Application.Interfaces.Repository.Remittance;
using BotRemesas.Application.Interfaces.Repository.User;
using BotRemesas.Domain.Common.ResultT;
using BotRemesas.Domain.Entities.Remittance;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BotRemesas.Application.Command.Remittance.Update;

public class UpdateRemittanceEntityCommandHandler : UpdateGenericEntityCommandHandler<RemittanceEntity, UpdateRemittanceEntityCommand>
{
    private readonly IUserRepository user;
    private readonly IAdminRepository adminRepository;
    private readonly ILogger<RemittanceEntity> logger;
    private readonly IRemittanceRepository remittanceRepository;
    public UpdateRemittanceEntityCommandHandler(IMapper mapper, IRemittanceRepository genericRepository , IUserRepository userRepository, ILogger<RemittanceEntity> logger , IAdminRepository adminRepository) : base(mapper, genericRepository)
    {
        this.user = userRepository;
        this.adminRepository = adminRepository;
        this.logger = logger;
        this.remittanceRepository = genericRepository;
    }
    public override async Task<Result<Unit>> Handle(UpdateRemittanceEntityCommand request, CancellationToken cancellationToken)
    {
        var remittance = await remittanceRepository.GetById(request.Id , cancellationToken);
        if(remittance == null)
        {
            logger.LogWarning("La remesa con id: "+request.Id+" no esta registrada");
            return Result<Unit>.Failure(new RemittanceNotFoundError());
        }
        if(request.AdminId != null)
        {
            var admin = await adminRepository.GetById(request.AdminId , cancellationToken);
            if(admin == null)
            {
                logger.LogWarning("El admin con id: "+request.AdminId+" no esta registrado");
                return Result<Unit>.Failure(new AdminNotFoundError());
            }
            remittance.Update(null ,null ,true);
            logger.LogInformation(remittance.Enabled.ToString());
            await remittanceRepository.Update(remittance , cancellationToken);
        }
        if(request.UserId != null)
        {
            var userEntity = await user.GetById(request.UserId , cancellationToken);
            if(userEntity == null)
            {
                logger.LogWarning("El usuario con id: "+request.UserId+" no esta registrado");
                return Result<Unit>.Failure(new UsernotFoundError());
            }
            remittance.Update(request.Amount , request.Address , false);
            await remittanceRepository.Update(remittance , cancellationToken);
        }
        return Result<Unit>.Success(Unit.Value);
    }
}