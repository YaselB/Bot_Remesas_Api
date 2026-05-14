using BotRemesas.Application.Command.Remittance.Create;
using BotRemesas.Application.Command.Remittance.Delete;
using BotRemesas.Application.Command.Remittance.Update;
using BotRemesas.Application.Features.Remittance.Dto;
using BotRemesas.Application.Query.Remittance.GetAll;
using BotRemesas.Application.Query.Remittance.GetById;
using BotRemesas.Domain.Entities.Remittance;
using BotRemesas.Presentation.Controller.Generic;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BotRemesas.Presentation.Controller.Remittance;

public class RemittanceController : GenericController<RemittanceEntity, CreateRemittanceEntityCommand, UpdateRemittanceEntityCommand, RemittanceResultDto>
{
    
    public RemittanceController(IMediator mediator) : base(mediator)
    {
    }
    [HttpPost()]
    public override async Task<IActionResult> Create(CreateRemittanceEntityCommand command, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(command);
        if(result.IsFailure && result.error != null)
        {
            return StatusCode(result.error.StatusCode , new {error = result.error.Message});
        }
        return Ok(result.Value);
    }
    [HttpPut()]
    public override async Task<IActionResult> Update(UpdateRemittanceEntityCommand command, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(command);
        if(result.IsFailure && result.error != null)
        {
            return StatusCode(result.error.StatusCode , new {error = result.error.Message});
        }
        return Ok(result.Value);
    }
    [HttpDelete("{id}")]
    public override async Task<IActionResult> Delete(string id, CancellationToken cancellationToken)
    {
        var command = new DeleteRemittanceEntityCommand
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
    public override async Task<IActionResult> GetById(string id, CancellationToken cancellationToken)
    {
        var query = new GetRemittanceEntityByIdQuery
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
        var query = new GetAllRemittanceEntityQuery();
        var result = await mediator.Send(query);
        if(result.IsFailure && result.error != null)
        {
            return StatusCode(result.error.StatusCode , new { error = result.error.Message});
        }
        return Ok(result.Value);
    }
}