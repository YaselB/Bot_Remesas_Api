using BotRemesas.Domain.Interfaces.Error;
using Microsoft.AspNetCore.Http;

namespace BotRemesas.Application.Common.Error;

public class EntityNotFoundError : IError
{
    public int StatusCode => StatusCodes.Status404NotFound;

    public string Message => "La entidad no se encuentra registrada";
}