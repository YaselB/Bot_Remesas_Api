using BotRemesas.Application.Command.User.Create;
using BotRemesas.Application.Command.User.Delete;
using BotRemesas.Application.Command.User.Update;
using BotRemesas.Application.Features.User.Dto;
using BotRemesas.Application.Query.User.GetAll;
using BotRemesas.Application.Query.User.GetById;
using BotRemesas.Domain.Entities.User;
using BotRemesas.Presentation.Controller.Generic;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BotRemesas.Presentation.Controller.User;
[ApiController]
[Route("api/user")]
public class UserController : GenericController<UserEntity, CreateUserEntityCommand, UpdateUserEntityCommand, UserResultDto>
{
    public UserController(IMediator mediator) : base(mediator)
    {
    }
    [HttpPost()]
    public override async Task<IActionResult> Create(CreateUserEntityCommand command, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(command);
        if(result.IsFailure && result.error != null)
        {
            return StatusCode(result.error.StatusCode , new { error = result.error.Message});
        }
        return Ok(result.Value);
    }
    [HttpPut()]
    public override async Task<IActionResult> Update(UpdateUserEntityCommand command, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(command);
        if(result.IsFailure && result.error != null)
        {
            StatusCode(result.error.StatusCode , new {error = result.error.Message});
        }
        return Ok(result.Value);
    }
    [HttpDelete("{id}")]
    public override async Task<IActionResult> Delete(string id, CancellationToken cancellationToken)
    {
        var query = new DeleteUserEntityCommand
        {
            Id = id
        };
        var result = await mediator.Send(query);
        if(result.IsFailure && result.error != null)
        {
            return StatusCode(result.error.StatusCode , new {error = result.error.Message});
        }
        return Ok(result.Value);
    }
    [HttpGet("{id}")]
    public override async Task<IActionResult> GetById(string id, CancellationToken cancellationToken)
    {
        var query = new GetUserEntityByIdQuery
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
    public override async Task<ActionResult> GetAll(CancellationToken cancellationToken)
    {
        var query = new GetAllUserEntityQuery();
        var result = await mediator.Send(query);
        if(result.IsFailure && result.error != null)
        {
            return StatusCode(result.error.StatusCode , new { error = result.error.Message});
        }
        return Ok(result.Value);
    }
    
}