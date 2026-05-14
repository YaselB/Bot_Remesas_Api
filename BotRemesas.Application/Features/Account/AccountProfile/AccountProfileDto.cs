using AutoMapper;
using BotRemesas.Application.Features.Account.Dto;
using BotRemesas.Domain.Entities.Account;

namespace BotRemesas.Application.Features.Account.AccountProfile;
public class AccountProfile : Profile
{
    public AccountProfile()
    {
        CreateMap<AccountEntity ,AccountResultDto>()
        .ReverseMap();
    }
}