using BotRemesas.Domain.Interfaces.Error;
using Microsoft.AspNetCore.Http;

namespace BotRemesas.Application.Common.Error;

public class PayEntityRegistered : IError
{
    public int StatusCode => StatusCodes.Status400BadRequest;
    public string Message => "Ese usuario ya tiene un pago creado";
}