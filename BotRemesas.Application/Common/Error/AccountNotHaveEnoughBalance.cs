using BotRemesas.Domain.Interfaces.Error;
using Microsoft.AspNetCore.Http;

namespace BotRemesas.Application.Common.Error;

public class AccountNotHaveEnoughBalance : IError
{
    public int StatusCode => StatusCodes.Status400BadRequest;

    public string Message => "La cuenta no tiene suficiente saldo para la extraccion";
}