using AutoMapper;
using BotRemesas.Application.Features.HistoryRemittance.Dto;
using BotRemesas.Domain.Entities.HistoryRemittances;

namespace BotRemesas.Application.Features.HistoryRemittance.HistoryProfile;
public class HistoryRemittanceProfile : Profile
{
    public HistoryRemittanceProfile()
    {
        CreateMap<HistoryRemittanceEntity , HistoryRemittanceDto>()
        .ReverseMap();
    }
}