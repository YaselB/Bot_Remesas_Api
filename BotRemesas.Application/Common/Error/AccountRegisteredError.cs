using BotRemesas.Domain.Interfaces.Error;
using Microsoft.AspNetCore.Http;

namespace BotRemesas.Application.Common.Error;

public class AccountRegisteredError : IError
{
    public int StatusCode => StatusCodes.Status400BadRequest;

    public string Message => "La cuenta con esa direccion ya ha sido registrada";
}