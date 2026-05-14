using BotRemesas.Application.Command.Generic.Delete;
using BotRemesas.Application.Common.Error;
using BotRemesas.Application.Interfaces.Repository.Account;
using BotRemesas.Application.Interfaces.Repository.Generic;
using BotRemesas.Domain.Common.ResultT;
using BotRemesas.Domain.Entities.Account;
using BotRemesas.Domain.Events.Account.Delete;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BotRemesas.Application.Command.Account.Delete;

public class DeleteAccountEntityCommandHandler : DeleteGenericEntityCommandHandler<AccountEntity, DeleteAccountEntityCommand>
{
    private readonly IAccountRepository accountRepository;
    private readonly ILogger<AccountEntity> logger;
    public DeleteAccountEntityCommandHandler(IAccountRepository genericRepository , ILogger<AccountEntity> logger) : base(genericRepository)
    {
        accountRepository = genericRepository;
        this.logger = logger;
    }
    public override async Task<Result<Unit>> Handle(DeleteAccountEntityCommand request, CancellationToken cancellationToken)
    {
        var account = await accountRepository.GetById(request.Id ,cancellationToken);
        if(account == null)
        {
            logger.LogWarning("La cuenta con id: "+request.Id+" no se encuentra");
            return Result<Unit>.Failure(new AccountNotFoundError());
        }
        var DeleteAccountDomainEvent = new DeleteAccountEntityEvent(account.Id , account.Account);
        account.AddDomainEvent(DeleteAccountDomainEvent);
        await accountRepository.Delete(account , cancellationToken);
        return Result<Unit>.Success(Unit.Value);
    }
}