using AutoMapper;
using BotRemesas.Application.Common.Error;
using BotRemesas.Application.Interfaces.Repository.Generic;
using BotRemesas.Domain.Common.ResultT;
using BotRemesas.Domain.Entities.Generic;
using MediatR;

namespace BotRemesas.Application.Command.Generic.Update;

public class UpdateGenericEntityCommandHandler<T, TCommand> : IRequestHandler<TCommand, Result<Unit>>
where T : GenericEntity<T>, new()
where TCommand : UpdateGenericEntityCommand<T>
{
    protected readonly IMapper mapper;
    protected readonly IGenericRepository<T> repository;
    protected UpdateGenericEntityCommandHandler(IMapper mapper , IGenericRepository<T> genericRepository)
    {
        this.mapper = mapper;
        this.repository = genericRepository;
    }
    public virtual async Task<Result<Unit>> Handle(TCommand request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetById(request.Id , cancellationToken);
        if(entity == null)
        {
            return Result<Unit>.Failure(new EntityNotFoundError());
        }
        mapper.Map<T>(request);
        await repository.Update(entity , cancellationToken);
        return Result<Unit>.Success(Unit.Value);
    }
}