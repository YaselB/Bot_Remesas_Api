using BotRemesas.Domain.Interfaces.Error;
using BotRemesas.Domain.Interfaces.Result;

namespace BotRemesas.Domain.Common.ResultWithOutT;

public class Result : IResult
{
    public bool IsSuccess {get ;}

    public bool IsFailure => !IsSuccess;

    public IError? error { get ;}
    protected Result(IError? error , bool IsSuccess)
    {
        this.IsSuccess = IsSuccess;
        this.error = error;
    }
    public static Result Success() => new Result(null ,true);
    public static Result Failure(IError error) => new Result(error , false);
}