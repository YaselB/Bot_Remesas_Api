using BotRemesas.Domain.Common.ResultT;
using BotRemesas.Domain.Entities.Generic;
using MediatR;

namespace BotRemesas.Application.Command.Generic.Delete;
public class DeleteGenericEntityCommand<T> : IRequest<Result<Unit>>
where T : GenericEntity<T>
{
    public required string Id { get ; set ; }
}