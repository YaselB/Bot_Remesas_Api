using AutoMapper;
using BotRemesas.Application.Command.Generic.Create;
using BotRemesas.Application.Common.Error;
using BotRemesas.Application.Interfaces.Repository.Admin;
using BotRemesas.Application.Interfaces.Repository.User;
using BotRemesas.Domain.Common.ResultT;
using BotRemesas.Domain.Entities.Admin;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BotRemesas.Application.Command.Admin.Create;

public class CreateAdminEntityCommandHandler : CreateGenericEntityCommandHandler<AdminEntity, CreateAdminEntityCommand>
{
    private readonly IAdminRepository adminRepository;
    private readonly ILogger<AdminEntity> logger;
    private readonly IUserRepository userRepository;
    public CreateAdminEntityCommandHandler(IAdminRepository adminRepository, IMapper mapper , ILogger<AdminEntity> logger , IUserRepository repository) : base(adminRepository, mapper)
    {
        this.adminRepository = adminRepository;
        this.logger = logger;
        userRepository = repository;
    }
    public override async Task<Result<Unit>> Handle(CreateAdminEntityCommand request, CancellationToken cancellationToken)
    {
        var admin = await adminRepository.GetByIdTelegram(request.IdUserTelegram ,cancellationToken);
        if(admin != null)
        {
            logger.LogWarning("El admin con id de Telegram: "+request.IdUserTelegram+"ya esta registrado");
            return Result<Unit>.Failure(new AdminRegistered());
        }
        var user = await userRepository.GetByIdUserTelegram(request.IdUserTelegram , cancellationToken);
        if(user != null)
        {
            logger.LogWarning("Ese id de Telegram ya ha sido registrado");
            return Result<Unit>.Failure(new UserRegistered());
        }
        var newAdmin = AdminEntity.Create(request.Name , request.IdUserTelegram);
        await adminRepository.AddAsync(newAdmin , cancellationToken);
        return Result<Unit>.Success(Unit.Value);
    }
}