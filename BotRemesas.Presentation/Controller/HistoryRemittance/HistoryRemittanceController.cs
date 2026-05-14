using BotRemesas.Application.Command.HistoryRemittance.Create;
using BotRemesas.Application.Query.HistoryRemittance.GetByUserId;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BotRemesas.Presentation.Controller.HistoryRemittance;
[ApiController]
[Route("api/historyRemittance")]
public class HistoryRemittanceController : ControllerBase
{
    private readonly IMediator mediator;
    public HistoryRemittanceController(IMediator mediator)
    {
        this.mediator = mediator;
    }
    [HttpPost()]
    public async Task<IActionResult> Create(CreateHistoryRemittanceEntityCommand command , CancellationToken cancellationToken)
    {
        var result = await mediator.Send(command);
        if(result.IsFailure && result.error != null)
        {
            return StatusCode(result.error.StatusCode , new { error = result.error.Message});
        }
        return Ok(result.Value);
    }
    [HttpGet("{id}")]
    public async Task<ActionResult> GetByUserId(string id , CancellationToken cancellationToken)
    {
        var query = new GetHistoryRemittanceByUserIdQuery
        {
            UserId = id
        };
        var result = await mediator.Send(query);
        if(result.IsFailure && result.error != null)
        {
            return StatusCode(result.error.StatusCode , new { error = result.error.Message});
        }
        return Ok(result.Value);
    }
}