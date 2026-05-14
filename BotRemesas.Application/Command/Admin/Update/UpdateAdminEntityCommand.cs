using BotRemesas.Application.Command.Generic.Update;
using BotRemesas.Domain.Entities.Admin;

namespace BotRemesas.Application.Command.Admin.Update;
public class UpdateAdminEntityCommand : UpdateGenericEntityCommand<AdminEntity>
{
    public required string Name {get ; set ; }
}