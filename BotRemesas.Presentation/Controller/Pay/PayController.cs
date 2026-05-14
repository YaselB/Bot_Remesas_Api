using BotRemesas.Application.Command.Pay.Create;
using BotRemesas.Application.Command.Pay.Delete;
using BotRemesas.Application.Command.Pay.Update;
using BotRemesas.Application.Features.Pay.Dto;
using BotRemesas.Application.Query.Pay.GetAll;
using BotRemesas.Application.Query.Pay.GetById;
using BotRemesas.Domain.Entities.Pay;
using BotRemesas.Presentation.Controller.Generic;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BotRemesas.Presentation.Controller.Pay;

[ApiController]
[Route("api/pay")]
public class PayController : GenericController<PayEntity, CreatePayEntityCommand, UpdatePayEntityCommand, PayResultDto>
{
    public PayController(IMediator mediator) : base(mediator)
    {
    }
    [HttpPost()]
    public override async Task<IActionResult> Create(CreatePayEntityCommand command, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(command); 
        if(result.IsFailure && result.error != null)
        {
            return StatusCode(result.error.StatusCode , new { error = result.error.Message});
        }
        return Ok(result.Value);
    }
    [HttpPut()]
    public override async Task<IActionResult> Update(UpdatePayEntityCommand command, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(command);
        if(result.IsFailure && result.error != null)
        {
            return StatusCode(result.error.StatusCode , new { error  = result.error.Message});
        }
        return Ok(result.Value);
    }
    [HttpDelete("{id}")]
    public override async Task<IActionResult> Delete(string id, CancellationToken cancellationToken)
    {
        var command = new DeletePayEntityCommand
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
        var query = new GetPayEntityByIdQuery
        {
            Id = id
        };
        var result = await mediator.Send(query);
        if(result.IsFailure && result.error != null){
            return StatusCode(result.error.StatusCode , new { error = result.error.Message});
        }
        return Ok(result.Value);
    }
    [HttpGet()]
    public override async Task<ActionResult> GetAll(CancellationToken cancellationToken)
    {
        var query = new GetAllPayEntityQuery();
        var result = await mediator.Send(query);
        if(result.IsFailure && result.error != null){
            return StatusCode(result.error.StatusCode , new { error = result.error.Message});
        }
        return Ok(result.Value);
    }
}