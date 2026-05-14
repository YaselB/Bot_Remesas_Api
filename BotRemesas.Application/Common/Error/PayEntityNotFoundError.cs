using BotRemesas.Domain.Interfaces.Error;
using Microsoft.AspNetCore.Http;

namespace BotRemesas.Application.Common.Error;

public class PayEntityNotFoundError : IError
{
    public int StatusCode => StatusCodes.Status400BadRequest;
    public string Message => "Ese pago no se encuentra";
}