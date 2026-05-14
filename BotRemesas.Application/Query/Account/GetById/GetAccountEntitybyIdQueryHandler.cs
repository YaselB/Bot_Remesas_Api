using AutoMapper;
using BotRemesas.Application.Common.Error;
using BotRemesas.Application.Features.Account.Dto;
using BotRemesas.Application.Interfaces.Repository.Account;
using BotRemesas.Application.Interfaces.Repository.Generic;
using BotRemesas.Application.Query.Generic.GetById;
using BotRemesas.Domain.Common.ResultT;
using BotRemesas.Domain.Entities.Account;
using Microsoft.Extensions.Logging;

namespace BotRemesas.Application.Query.Account.GetById;

public class GetAccountEntityByIdQueryHandler : GetGenericEntityByIdQueryHandler<AccountEntity, GetAccountEntityById, AccountResultDto>
{
    private readonly IAccountRepository accountRepository;
    private readonly ILogger<AccountEntity> logger;
    public GetAccountEntityByIdQueryHandler(IAccountRepository genericRepository, IMapper mapper , ILogger<AccountEntity> logger) : base(genericRepository, mapper)
    {
        accountRepository = genericRepository;
        this.logger = logger;
    }
    public override async Task<Result<AccountResultDto?>> Handle(GetAccountEntityById request, CancellationToken cancellationToken)
    {
        var account = await accountRepository.GetById(request.Id , cancellationToken);
        if(account == null)
        {
            logger.LogWarning("La cuenta con id: "+request.Id+" no esta registrado");
            return Result<AccountResultDto?>.Failure(new AccountNotFoundError());
        }
        var accountBack = mapper.Map<AccountResultDto>(account);
        return Result<AccountResultDto?>.Success(accountBack);
    }
}