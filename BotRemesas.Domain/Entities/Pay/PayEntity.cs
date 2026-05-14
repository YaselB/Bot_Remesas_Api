using BotRemesas.Domain.Entities.Generic;
using BotRemesas.Domain.Entities.User;
using BotRemesas.Domain.Events.Pay.Create;
using BotRemesas.Domain.Events.Pay.Update;

namespace BotRemesas.Domain.Entities.Pay;
public class PayEntity : GenericEntity<PayEntity>
{
    public double UserPay {get ; set ;}
    public string UserId {get ; set ;} = string.Empty;
    public UserEntity? Users {get ; set ;}
    public static PayEntity Create(string UserId)
    {
        var pay = new PayEntity
        {
            UserId = UserId,
            UserPay = 0
        };
        var CreatePayEntityDomainEvent = new CreatePayEntityEvent(pay.UserId ,pay.Id);
        pay.AddDomainEvent(CreatePayEntityDomainEvent);
        return pay;
    }
    public void Update(double pay)
    {
        this.UserPay = pay;
        var UpdatePayEntityDomainEvent = new UpdatePayEntityEvent(this.UserId , this.Id);
        this.AddDomainEvent(UpdatePayEntityDomainEvent);
    }
}