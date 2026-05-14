using BotRemesas.Domain.Interfaces.Error;
using Microsoft.AspNetCore.Http;

namespace BotRemesas.Application.Common.Error;

public class RemittanceNotFoundError : IError
{
    public int StatusCode => StatusCodes.Status404NotFound;
    public string Message => "Esa remesa no ha sido registrada";
}