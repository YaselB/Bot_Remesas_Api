using BotRemesas.Application.Command.Generic.Create;
using BotRemesas.Application.Command.Generic.Delete;
using BotRemesas.Application.Command.Generic.Update;
using BotRemesas.Application.Query.Generic.GetAll;
using BotRemesas.Application.Query.Generic.GetById;
using BotRemesas.Domain.Entities.Generic;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BotRemesas.Presentation.Controller.Generic;
[ApiController]
[Route("api/[controller]")]
public class GenericController<T ,TCreateCommand , TUpdateCommand , TResultDto> : ControllerBase
where T : GenericEntity<T>, new ()
where TCreateCommand : CreateGenericEntityCommand<T>, new ()
where TUpdateCommand : UpdateGenericEntityCommand<T>
where TResultDto : class
{
    protected readonly IMediator mediator;
    public GenericController(IMediator mediator)
    {
        this.mediator = mediator;
    }
    [HttpPost()]
    public virtual async Task<IActionResult> Create(TCreateCommand command , CancellationToken cancellationToken)
    {
        var result = await mediator.Send(command);
        if(result.IsFailure && result.error != null)
        {
            return StatusCode(result.error.StatusCode ,new {error = result.error.Message});
        }
        return Ok(result.Value);
    }
    [HttpPut()]
    public virtual async Task<IActionResult> Update(TUpdateCommand command , CancellationToken cancellationToken)
    {
        var result = await mediator.Send(command);
        if(result.IsFailure && result.error != null)
        {
            return StatusCode(result.error.StatusCode , new { error = result.error.Message });
        }
        return Ok(result.Value);
    }
    [HttpDelete("{id}")]
    public virtual async Task<IActionResult> Delete(string id , CancellationToken cancellationToken)
    {
        var command = new DeleteGenericEntityCommand<T>
        {
            Id = id
        };
        var result = await mediator.Send(command);
        if(result.IsFailure && result.error != null)
        {
            return StatusCode(result.error.StatusCode , new { error = result.error.Message});
        }
        return Ok(result.Value);
    }
    [HttpGet("{id}")]
    public virtual async Task<IActionResult> GetById(string id , CancellationToken cancellationToken)
    {
        var query = new GetGenericEntityByIdQuery<T , TResultDto>
        {
            Id = id
        };
        var result = await mediator.Send(query);
        if(result.IsFailure && result.error != null)
        {
            return StatusCode(result.error.StatusCode , new { error = result.error.Message});
        }
        return Ok(result.Value);
    }
    [HttpGet()]
    public virtual async Task<ActionResult> GetAll(CancellationToken cancellationToken)
    {
        var query = new GetAllGenericEntityQuery<T , TResultDto>();
        var result = await mediator.Send(query);
        if(result.IsFailure && result.error != null)
        {
            return StatusCode(result.error.StatusCode , new { error = result.error.Message});
        }
        return Ok(result.Value);
    }
}