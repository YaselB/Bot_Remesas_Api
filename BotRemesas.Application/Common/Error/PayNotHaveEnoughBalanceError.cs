using BotRemesas.Domain.Interfaces.Error;
using Microsoft.AspNetCore.Http;

namespace BotRemesas.Application.Common.Error;

public class PayNotHaveEnoughBalanceError : IError
{
    public int StatusCode => StatusCodes.Status400BadRequest;

    public string Message => "El usuario no contiene suficiente saldo para se retiro";
}