using AutoMapper;
using BotRemesas.Application.Command.Generic.Create;
using BotRemesas.Application.Common.Error;
using BotRemesas.Application.Interfaces.Repository.Account;
using BotRemesas.Application.Interfaces.Repository.Admin;
using BotRemesas.Application.Interfaces.Repository.Generic;
using BotRemesas.Domain.Common.ResultT;
using BotRemesas.Domain.Entities.Account;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BotRemesas.Application.Command.Account.Create;

public class CreateAccoutEntityCommandHandler : CreateGenericEntityCommandHandler<AccountEntity, CreateAccountEntityCommand>
{
    private readonly IAccountRepository account;
    private readonly IAdminRepository adminRepository;
    private readonly ILogger<AccountEntity> logger;

    public CreateAccoutEntityCommandHandler(IAccountRepository repository, IMapper mapper , IAdminRepository adminRepository , ILogger<AccountEntity> logger) : base(repository, mapper)
    {
        this.account = repository;
        this.adminRepository = adminRepository;
        this.logger = logger;
    }
    public override async Task<Result<Unit>> Handle(CreateAccountEntityCommand request, CancellationToken cancellationToken)
    {
        var admin = await adminRepository.GetById(request.AdminId, cancellationToken);
        if(admin == null)
        {
            logger.LogWarning("El admin con id: "+request.AdminId+" no esta registrado");
            return Result<Unit>.Failure(new AdminNotFoundError());
        }
        var entity = await account.GetByAddress(request.Account);
        if(entity != null)
        {
            logger.LogWarning("La cuenta con direccion: "+request.Account+" ya esta registrada");
            return Result<Unit>.Failure(new AccountRegisteredError());
        }
        var newAccount = AccountEntity.Create(request.Account , request.AdminId);
        await account.AddAsync(newAccount);
        return Result<Unit>.Success(Unit.Value);
    }
}