using BotRemesas.Application.Command.Generic.Create;
using BotRemesas.Domain.Entities.Admin;

namespace BotRemesas.Application.Command.Admin.Create;
public class CreateAdminEntityCommand : CreateGenericEntityCommand<AdminEntity>
{
    public long IdUserTelegram { get ; set ;  }
    public string Name {get ; set ;} = string.Empty;
}