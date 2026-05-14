using BotRemesas.Domain.Interfaces.Error;

namespace BotRemesas.Domain.Interfaces.Result;
public interface IResult
{
    public bool IsSuccess {get ;}
    public bool IsFailure { get ;}
    public IError? error { get ;}
}