using AutoMapper;
using BotRemesas.Application.Common.Error;
using BotRemesas.Application.Interfaces.Repository.Generic;
using BotRemesas.Domain.Common.ResultT;
using BotRemesas.Domain.Entities.Generic;
using MediatR;

namespace BotRemesas.Application.Query.Generic.GetById;

public class GetGenericEntityByIdQueryHandler<T, TQuery , TResultDto> : IRequestHandler<TQuery, Result<TResultDto?>>
where T : GenericEntity<T>, new()
where TQuery : GetGenericEntityByIdQuery<T , TResultDto>
where TResultDto : class
{
    protected readonly IGenericRepository<T> repository;
    protected readonly IMapper mapper;
    protected GetGenericEntityByIdQueryHandler(IGenericRepository<T> genericRepository , IMapper mapper)
    {
        this.repository = genericRepository;
        this.mapper = mapper;
    }
    public virtual async Task<Result<TResultDto?>> Handle(TQuery request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetById(request.Id , cancellationToken);
        if(entity == null)
        {
            return Result<TResultDto?>.Failure(new EntityNotFoundError());
        }
        var result = mapper.Map<TResultDto>(entity);
        return Result<TResultDto?>.Success(result);
    }
}