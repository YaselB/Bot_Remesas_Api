using BotRemesas.Domain.Interfaces.Error;
using Microsoft.AspNetCore.Http;

namespace BotRemesas.Application.Common.Error;

public class AdminIdUserTelegramRegisteredError : IError
{
    public int StatusCode => StatusCodes.Status400BadRequest;
    public string Message => "Ese id de Telegram ya ha sido registrado por un admin";
}