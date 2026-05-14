using BotRemesas.Domain.Common.ResultT;
using BotRemesas.Domain.Entities.Generic;
using MediatR;

namespace BotRemesas.Application.Command.Generic.Create;
public class CreateGenericEntityCommand<T> : IRequest<Result<Unit>>
where T : GenericEntity<T>
{}