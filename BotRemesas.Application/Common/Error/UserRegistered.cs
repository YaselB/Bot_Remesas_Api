using BotRemesas.Domain.Interfaces.Error;
using Microsoft.AspNetCore.Http;

namespace BotRemesas.Application.Common.Error;

public class UserRegistered : IError
{
    public int StatusCode => StatusCodes.Status400BadRequest;

    public string Message => "Ese id de Telegram ya ha sido usado por un usuario";
}