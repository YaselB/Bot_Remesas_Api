using BotRemesas.Domain.Interfaces.Error;
using Microsoft.AspNetCore.Http;

namespace BotRemesas.Application.Common.Error;

public class AdminNotFoundError : IError
{
    public int StatusCode => StatusCodes.Status404NotFound;
    public string Message => "El admin no está registrado";
}