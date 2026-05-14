using AutoMapper;
using BotRemesas.Application.Features.User.Dto;
using BotRemesas.Domain.Entities.User;

namespace BotRemesas.Application.Features.User.UserProfile;
public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<UserEntity , UserResultDto>()
        .ReverseMap();
    }
}