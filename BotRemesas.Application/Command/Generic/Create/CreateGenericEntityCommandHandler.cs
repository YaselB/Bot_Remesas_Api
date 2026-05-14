using AutoMapper;
using BotRemesas.Application.Interfaces.Repository.Generic;
using BotRemesas.Domain.Common.ResultT;
using BotRemesas.Domain.Entities.Generic;
using MediatR;

namespace BotRemesas.Application.Command.Generic.Create;

public class CreateGenericEntityCommandHandler<T, TCommand> : IRequestHandler<TCommand, Result<Unit>>
where T : GenericEntity<T>, new()
where TCommand : CreateGenericEntityCommand<T>
{
    protected readonly IGenericRepository<T> repository;
    protected readonly IMapper mapper;
    protected CreateGenericEntityCommandHandler(IGenericRepository<T> repository , IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }
    public virtual async Task<Result<Unit>> Handle(TCommand request, CancellationToken cancellationToken)
    {
        var entity = mapper.Map<T>(request);
        await repository.AddAsync(entity);
        return Result<Unit>.Success(Unit.Value);
    }
}