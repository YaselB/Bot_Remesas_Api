using AutoMapper;
using BotRemesas.Application.Interfaces.Repository.Generic;
using BotRemesas.Domain.Common.ResultT;
using BotRemesas.Domain.Entities.Generic;
using MediatR;

namespace BotRemesas.Application.Query.Generic.GetAll;

public class GetAllGenericEntityQueryHandler<T, TResultDto, TQuery> : IRequestHandler<TQuery, Result<IReadOnlyList<TResultDto>>>
where T : GenericEntity<T>, new()
where TQuery : GetAllGenericEntityQuery<T, TResultDto>
where TResultDto : class
{
    protected readonly IGenericRepository<T> repository;
    protected readonly IMapper mapper;
    protected GetAllGenericEntityQueryHandler(IGenericRepository<T> genericRepository , IMapper mapper)
    {
        this.repository = genericRepository;
        this.mapper = mapper;
    }
    public virtual async Task<Result<IReadOnlyList<TResultDto>>> Handle(TQuery request, CancellationToken cancellationToken)
    {
        var entities = await repository.GetAll(cancellationToken);
        var backList = new List<TResultDto>();
        foreach(var i in entities)
        {
            var entityback = mapper.Map<TResultDto>(i);
            backList.Add(entityback);
        }
        return Result<IReadOnlyList<TResultDto>>.Success(backList);
    }
}