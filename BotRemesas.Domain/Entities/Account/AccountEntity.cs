using BotRemesas.Domain.Entities.Admin;
using BotRemesas.Domain.Entities.Generic;
using BotRemesas.Domain.Entities.Remittance;
using BotRemesas.Domain.Events.Account.Create;
using BotRemesas.Domain.Events.Account.Update;

namespace BotRemesas.Domain.Entities.Account;
public class AccountEntity : GenericEntity<AccountEntity>
{
    public string Account{ get ; set ;} = string.Empty;
    public double Balance {get ; set ;}
    public string AdminId {get ; set ;} = string.Empty;
    public AdminEntity? Admin {get ; set ;}
    public ICollection<RemittanceEntity> ? RemittanceEntities{get ; set ;}
    
    public static AccountEntity Create(string address , string AdminId)
    {
        var account = new AccountEntity
        {
            Account = address,
            Balance = 0,
            AdminId = AdminId
        };
        var createAccountDomainEvent = new CreateAccountEntityEvent(account.Id , account.Account);
        account.AddDomainEvent(createAccountDomainEvent);
        return account;
    }
    public void Update(double balance)
    {
        this.Balance = balance;
        var updateAccountDomainEvent = new UpdateAccountEntityEvent(this.Account , this.Balance);
        this.AddDomainEvent(updateAccountDomainEvent);
    }

}