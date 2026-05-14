using AutoMapper;
using BotRemesas.Application.Features.Admin.Dto;
using BotRemesas.Domain.Entities.Admin;

namespace BotRemesas.Application.Features.Admin.AdminProfile;
public class AdminProfileDto : Profile
{
    public AdminProfileDto()
    {
        CreateMap<AdminEntity , AdminResultDto>()
        .ReverseMap();
    }
}