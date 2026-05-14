using BotRemesas.Domain.Interfaces.Error;
using Microsoft.AspNetCore.Http;

namespace BotRemesas.Application.Common.Error;

public class PayEntityNotFoundByUserIdError : IError
{
    public int StatusCode => StatusCodes.Status400BadRequest;
    public string Message => "Ese usuario no tiene una cuenta de pago";
}