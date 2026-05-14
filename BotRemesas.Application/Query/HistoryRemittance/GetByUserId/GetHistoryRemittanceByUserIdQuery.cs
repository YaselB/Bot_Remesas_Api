using BotRemesas.Application.Features.HistoryRemittance.Dto;
using BotRemesas.Domain.Common.ResultT;
using MediatR;

namespace BotRemesas.Application.Query.HistoryRemittance.GetByUserId;
public class GetHistoryRemittanceByUserIdQuery : IRequest<Result<IReadOnlyList<HistoryRemittanceDto>>>
{
    public required string UserId {get ; set ;}
}