using BotRemesas.Application.Command.Generic.Create;
using BotRemesas.Domain.Entities.User;

namespace BotRemesas.Application.Command.User.Create;
public class CreateUserEntityCommand : CreateGenericEntityCommand<UserEntity>
{
    public string Name { get ; set ;} = string.Empty;
    public long IdUserTelegram {get ; set ;} 
    public string AdminId {get ; set ;} = string.Empty;
    public double PerCent {get ; set ; } 
    
}