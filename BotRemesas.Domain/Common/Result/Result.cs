using BotRemesas.Domain.Common.ResultWithOutT;
using BotRemesas.Domain.Interfaces.Error;

namespace BotRemesas.Domain.Common.ResultT;

public class Result<T> : Result
{
    public T? Value { get ; }
    protected Result(IError? error, bool IsSuccess , T? value) : base(error, IsSuccess)
    {
        this.Value = value;
    }
    public static Result<T> Success(T value) => new Result<T>(null , true , value);
    public new static Result<T> Failure(IError error) => new Result<T>(error , false , default);
}