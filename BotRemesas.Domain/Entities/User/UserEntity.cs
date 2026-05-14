using BotRemesas.Domain.Entities.Admin;
using BotRemesas.Domain.Entities.Generic;
using BotRemesas.Domain.Entities.HistoryRemittances;
using BotRemesas.Domain.Entities.Pay;
using BotRemesas.Domain.Entities.Remittance;
using BotRemesas.Domain.Events.User.Create;
using BotRemesas.Domain.Events.User.Update;

namespace BotRemesas.Domain.Entities.User;
public class UserEntity : GenericEntity<UserEntity>
{
    public string Name{ get ; set ;} = string.Empty;
    public long IdUserTelegram { get ; set ;}
    public double PerCent {get ; set ;}
    public AdminEntity? Admin{ get ; set; }
    public string AdminId {get ; set ;}= string.Empty;
    public ICollection<RemittanceEntity>? Remittances { get ; set ;}
    public PayEntity? Pay {get ; set;}
    public ICollection<HistoryRemittanceEntity>? HistoryRemittances {get ; set ;}
    public static UserEntity Create(string name , long IdUserTelegram , string Adminid , double perCent)
    {
        var user = new UserEntity
        {
            AdminId = Adminid,
            IdUserTelegram = IdUserTelegram,
            Name = name,
            PerCent = perCent
        };
        var CreateUserDomainEvent = new CreateUserEntityEvent(user.Id , user.Name);
        user.AddDomainEvent(CreateUserDomainEvent);
        return user;
    }
    public void Update(string name , long IdUserTelegram , double perCent)
    {
        this.Name = name;
        this.UpdateAt = DateTime.UtcNow;
        this.IdUserTelegram = IdUserTelegram;
        this.PerCent = perCent;
        var UpdateUserDomainEvent = new UpdateUserEntityEvent(this.Id , this.Name);
        this.AddDomainEvent(UpdateUserDomainEvent);
    }
}