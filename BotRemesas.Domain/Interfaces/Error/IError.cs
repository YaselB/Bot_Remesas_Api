namespace BotRemesas.Domain.Interfaces.Error;
public interface IError
{
    public int StatusCode { get ;}
    public string Message { get ;}
}