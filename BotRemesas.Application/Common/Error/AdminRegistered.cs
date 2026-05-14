using BotRemesas.Domain.Interfaces.Error;
using Microsoft.AspNetCore.Http;

namespace BotRemesas.Application.Common.Error;

public class AdminRegistered : IError
{
    public int StatusCode => StatusCodes.Status400BadRequest;
    public string Message => "Ese identificador de usuario ya esta registrado";
}