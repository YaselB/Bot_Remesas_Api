using AutoMapper;
using BotRemesas.Application.Command.Generic.Update;
using BotRemesas.Application.Common.Error;
using BotRemesas.Application.Interfaces.Repository.Account;
using BotRemesas.Application.Interfaces.Repository.Admin;
using BotRemesas.Domain.Common.ResultT;
using BotRemesas.Domain.Entities.Account;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BotRemesas.Application.Command.Account.Update;

public class UpdateAccountEntityCommandHandler : UpdateGenericEntityCommandHandler<AccountEntity, UpdateAccountEntityCommand>
{
    private readonly IAdminRepository adminRepository;
    private readonly IAccountRepository accountRepository;
    private readonly ILogger<AccountEntity> logger;
    public UpdateAccountEntityCommandHandler(IMapper mapper, IAccountRepository genericRepository , ILogger<AccountEntity> logger , IAdminRepository adminRepository) : base(mapper, genericRepository)
    {
        this.adminRepository = adminRepository;
        accountRepository = genericRepository;
        this.logger = logger;
    }
    public override async Task<Result<Unit>> Handle(UpdateAccountEntityCommand request, CancellationToken cancellationToken)
    {
        var adminEntity = await adminRepository.GetById(request.AdminId);
        if(adminEntity == null)
        {
            logger.LogWarning("El admin con id: "+request.AdminId+" no se encuentra");
            return Result<Unit>.Failure(new AdminNotFoundError());
        }
        var account = await accountRepository.GetById(request.Id , cancellationToken);
        if(account == null)
        {
            logger.LogWarning("La cuenta con id: "+request.Id+" no se encuentra");
            return Result<Unit>.Failure(new AccountNotFoundError());
        }
        double newValue;
        if (request.EnabledSum)
        {
            newValue = request.Value + account.Balance;
            account.Update(newValue);
            await accountRepository.Update(account , cancellationToken);
            return Result<Unit>.Success(Unit.Value);
        }
        if (!request.EnabledSum && account.Balance < request.Value)
        {
            logger.LogWarning("La cuenta con direccion: "+account.Account+" no contiene saldo suficiente para el retiro");
            return Result<Unit>.Failure(new AccountNotHaveEnoughBalance());
        }
        newValue = account.Balance - request.Value;
        account.Update(newValue);
        await accountRepository.Update(account , cancellationToken);
        return Result<Unit>.Success(Unit.Value);
    }
}