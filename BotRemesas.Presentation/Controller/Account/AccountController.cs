using BotRemesas.Application.Command.Account.Create;
using BotRemesas.Application.Command.Account.Delete;
using BotRemesas.Application.Command.Account.Update;
using BotRemesas.Application.Features.Account.Dto;
using BotRemesas.Application.Query.Account.GetAll;
using BotRemesas.Application.Query.Account.GetById;
using BotRemesas.Domain.Entities.Account;
using BotRemesas.Presentation.Controller.Generic;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BotRemesas.Presentation.Controller.Account;
[ApiController]
[Route("api/account")]
public class AccountController : GenericController<AccountEntity, CreateAccountEntityCommand, UpdateAccountEntityCommand, AccountResultDto>
{
    public AccountController(IMediator mediator) : base(mediator)
    {
    }
    [HttpPost()]
    public override async Task<IActionResult> Create(CreateAccountEntityCommand command, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(command);
        if(result.IsFailure && result.error != null)
        {
            return StatusCode(result.error.StatusCode , new { error = result.error.Message});
        }
        return Ok(result.Value);
    }
    [HttpPut()]
    public override async Task<IActionResult> Update(UpdateAccountEntityCommand command, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(command);
        if(result.IsFailure && result.error != null){
            return StatusCode(result.error.StatusCode , new { error = result.error.Message});
        }
        return Ok(result.Value);
    }
    [HttpDelete("{id}")]
    public override async Task<IActionResult> Delete(string id, CancellationToken cancellationToken)
    {
        var command = new DeleteAccountEntityCommand
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
        var query = new GetAccountEntityById
        {
            Id = id
        };
        var result = await mediator.Send(query);
        if(result.IsFailure && result.error != null)
        {
            return StatusCode(result.error.StatusCode , result.error.Message);
        }
        return Ok(result.Value);
    }
    [HttpGet()]
    public override async Task<ActionResult> GetAll(CancellationToken cancellationToken)
    {
        var query = new GetAllAccountEntityQuery();
        var result = await mediator.Send(query);
        if(result.IsFailure && result.error != null)
        {
            return StatusCode(result.error.StatusCode , new { error = result.error.Message});
        }
        return Ok(result.Value);
    }
}