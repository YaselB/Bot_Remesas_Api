using BotRemesas.Domain.Common.ResultT;
using BotRemesas.Domain.Entities.Generic;
using MediatR;

namespace BotRemesas.Application.Query.Generic.GetAll;
public class GetAllGenericEntityQuery<T , TResultDto> : IRequest<Result<IReadOnlyList<TResultDto>>>
where T : GenericEntity<T>, new ()
where TResultDto : class
{}