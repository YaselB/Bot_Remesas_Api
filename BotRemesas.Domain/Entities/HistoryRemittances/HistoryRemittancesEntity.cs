using BotRemesas.Domain.Entities.Generic;
using BotRemesas.Domain.Entities.User;

namespace BotRemesas.Domain.Entities.HistoryRemittances;
public class HistoryRemittanceEntity : GenericEntity<HistoryRemittanceEntity>
{
    public double AmountPay {get ; set ;}
    public double Amount {get ; set ;}
    public string Customer {get ; set ; } = string.Empty;
    public string UserId {get ; set ;} = string.Empty;
    public string Account {get ; set ;} = string.Empty;
    public UserEntity? User {get ; set ;}
    public static HistoryRemittanceEntity Create(double AmountPay , double Amount , string Customer , string UserId , string Account)
    {
        var history = new HistoryRemittanceEntity
        {
            Account = Account,
            Amount = Amount,
            Customer = Customer,
            UserId = UserId,
            AmountPay = AmountPay
        };
        return history;
    }
}