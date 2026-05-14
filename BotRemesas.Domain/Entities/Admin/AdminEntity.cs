using BotRemesas.Domain.Entities.Account;
using BotRemesas.Domain.Entities.Generic;
using BotRemesas.Domain.Entities.User;
using BotRemesas.Domain.Events.Admin.Create;
using BotRemesas.Domain.Events.Admin.Update;

namespace BotRemesas.Domain.Entities.Admin;
public class AdminEntity : GenericEntity<AdminEntity>
{
    public string Name {get ; set ;} = string.Empty;
    public long IdUserTelegram {get ; set ;} 
    public ICollection<UserEntity> ? Users {get ; set ;}
    public ICollection<AccountEntity> ? AccountEntities {get ; set ;}

    public static AdminEntity Create(string name , long IdUserTelegram)
    {
        var admin = new AdminEntity
        {
            Name = name,
            IdUserTelegram = IdUserTelegram
        };
        var CreateAdminDomainEvent = new CreateAdminEntityEvent(admin.Id ,admin.Name);
        admin.AddDomainEvent(CreateAdminDomainEvent);
        return admin;
    }
    public void Update(string name)
    {
        this.Name = name;
        this.UpdateAt = DateTime.UtcNow;
        var UpdateAdminEntityDomainEvent = new UpdateAdminEntityEvent(this.Id ,this.Name);
        this.AddDomainEvent(UpdateAdminEntityDomainEvent);
    }
}