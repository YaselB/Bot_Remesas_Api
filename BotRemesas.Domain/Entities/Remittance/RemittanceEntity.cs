using BotRemesas.Domain.Entities.Account;
using BotRemesas.Domain.Entities.Generic;
using BotRemesas.Domain.Entities.User;
using BotRemesas.Domain.Events.Remittance.Create;
using BotRemesas.Domain.Events.Remittance.Update;

namespace BotRemesas.Domain.Entities.Remittance;

public class RemittanceEntity : GenericEntity<RemittanceEntity>
{
    public string UserId { get; set; } = string.Empty;
    public UserEntity? User { get; set; }
    public double Amount { get; set; }
    public string AccountId {get ; set ;} = string.Empty;
    public AccountEntity ? Account {get ; set ;}
    public string urlImage { get; set; } = string.Empty;
    public string Customer { get; set; } = string.Empty;
    public bool Enabled { get; set; }
    public static RemittanceEntity Create(string UserId, double Amount, string urlImage, string AccountId, string Customer)
    {
        var remittance = new RemittanceEntity
        {
            Amount = Amount,
            urlImage = urlImage,
            UserId = UserId,
            Customer = Customer,
            Enabled = false,
            AccountId = AccountId
        };
        var CreateRemittanceDomainEvent = new CreateRemittanceEntityEvent(remittance.Id, remittance.Customer);
        remittance.AddDomainEvent(CreateRemittanceDomainEvent);
        return remittance;
    }
    public void Update(double? amount, string? Address, bool? Enabled)
    {
        if (amount != null && Address != null)
        {
            this.Amount = Amount;
        }
        if(Enabled != null)
        {
            this.Enabled = Enabled.Value;
        }
        var UpdateRemittanceDomainEvent = new UpdateRemittanceEvent(this.Id, this.Customer);
        this.AddDomainEvent(UpdateRemittanceDomainEvent);
    }
}