using BotRemesas.Domain.Interfaces.Error;
using Microsoft.AspNetCore.Http;

namespace BotRemesas.Application.Common.Error;

public class UsernotFoundError : IError
{
    public int StatusCode => StatusCodes.Status404NotFound;

    public string Message => "El usuario con ese id no esta registrado";
}