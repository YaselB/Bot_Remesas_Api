using BotRemesas.Application.Command.Generic.Update;
using BotRemesas.Domain.Entities.User;

namespace BotRemesas.Application.Command.User.Update;
public class UpdateUserEntityCommand : UpdateGenericEntityCommand<UserEntity>
{
    public required string Name {get ;set;}
    public required long IdUserTelegram {get ; set ;}
    public required double PerCent {get ; set ; }
}