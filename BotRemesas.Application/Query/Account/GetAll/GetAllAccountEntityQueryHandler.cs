using AutoMapper;
using BotRemesas.Application.Features.Account.Dto;
using BotRemesas.Application.Interfaces.Repository.Generic;
using BotRemesas.Application.Query.Generic.GetAll;
using BotRemesas.Domain.Entities.Account;

namespace BotRemesas.Application.Query.Account.GetAll;

public class GetAllAccountEntityQueryHandler : GetAllGenericEntityQueryHandler<AccountEntity, AccountResultDto, GetAllAccountEntityQuery>
{
    public GetAllAccountEntityQueryHandler(IGenericRepository<AccountEntity> genericRepository, IMapper mapper) : base(genericRepository, mapper)
    {
    }
}