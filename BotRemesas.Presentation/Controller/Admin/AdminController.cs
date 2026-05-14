using BotRemesas.Application.Command.Admin.Create;
using BotRemesas.Application.Command.Admin.Delete;
using BotRemesas.Application.Command.Admin.Update;
using BotRemesas.Application.Features.Admin.Dto;
using BotRemesas.Application.Query.Admin.GetAll;
using BotRemesas.Application.Query.Admin.GetById;
using BotRemesas.Domain.Entities.Admin;
using BotRemesas.Presentation.Controller.Generic;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BotRemesas.Presentation.Controller.Admin;

[ApiController]
[Route("api/admin")]
public class AdminController : GenericController<AdminEntity, CreateAdminEntityCommand, UpdateAdminEntityCommand, AdminResultDto>
{
    private readonly IMediator mediator1;
    public AdminController(IMediator mediator) : base(mediator)
    {
        mediator1 = mediator;
    }
    [HttpPost()]
    public override async Task<IActionResult> Create(CreateAdminEntityCommand command, CancellationToken cancellationToken)
    {
        var result = await mediator1.Send(command);
        if(result.IsFailure && result.error != null)
        {
            return StatusCode(result.error.StatusCode , new { error = result.error.Message});
        }
        return Ok(result.Value);
    }
    [HttpPut()]
    public override async Task<IActionResult> Update(UpdateAdminEntityCommand command, CancellationToken cancellationToken)
    {
        var result = await mediator1.Send(command);
        if(result.IsFailure && result.error != null)
        {
            return StatusCode(result.error.StatusCode , new { error = result.error.Message});
        }
        return Ok(result.Value);
    }
    [HttpDelete("{id}")]
    public override async Task<IActionResult> Delete(string id, CancellationToken cancellationToken)
    {
        var command = new DeleteAdminEntityCommand
        {
            Id = id
        };
        var result = await mediator1.Send(command);
        if(result.IsFailure && result.error != null)
        {
            return StatusCode(result.error.StatusCode , new { error = result.error.Message});
        }
        return Ok(result.Value);
    }
    [HttpGet("{id}")]
    public override async Task<IActionResult> GetById(string id, CancellationToken cancellationToken)
    {
        var query = new GetAdminEntityByIdQuery
        {
            Id = id
        };
        var result = await mediator1.Send(query);
        if(result.IsFailure && result.error != null)
        {
            StatusCode(result.error.StatusCode , new { error = result.error.Message});
        }
        return Ok(result.Value);
    }
    public override async Task<ActionResult> GetAll(CancellationToken cancellationToken)
    {
        var query = new GetAllAdminEntityQuery();
        var result = await mediator.Send(query);
        if(result.IsFailure && result.error != null)
        {
            return StatusCode(result.error.StatusCode , new { error = result.error.Message});
        }
        return Ok(result.Value);
    }
    
}