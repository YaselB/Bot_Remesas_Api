using BotRemesas.Application.Common.Error;
using BotRemesas.Application.Interfaces.Repository.Generic;
using BotRemesas.Domain.Common.ResultT;
using BotRemesas.Domain.Entities.Generic;
using MediatR;

namespace BotRemesas.Application.Command.Generic.Delete;

public class DeleteGenericEntityCommandHandler<T, TCommand> : IRequestHandler<TCommand, Result<Unit>>
where T : GenericEntity<T>, new()
where TCommand : DeleteGenericEntityCommand<T>
{
    protected readonly IGenericRepository<T> repository;
    protected DeleteGenericEntityCommandHandler(IGenericRepository<T> genericRepository)
    {
        this.repository = genericRepository;
    }
    public virtual async Task<Result<Unit>> Handle(TCommand request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetById(request.Id ,cancellationToken);
        if(entity == null)
        {
            return Result<Unit>.Failure(new EntityNotFoundError());
        }
        await repository.Delete(entity);
        return Result<Unit>.Success(Unit.Value);
    }
}