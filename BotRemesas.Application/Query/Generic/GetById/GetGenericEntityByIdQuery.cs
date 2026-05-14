using BotRemesas.Domain.Common.ResultT;
using BotRemesas.Domain.Entities.Generic;
using MediatR;

namespace BotRemesas.Application.Query.Generic.GetById;
public class GetGenericEntityByIdQuery<T , TResultDto> : IRequest<Result<TResultDto?>>
where TResultDto : class
{
    public required string Id { get ; set ;}
}