namespace BotRemesas.Application.Features.HistoryRemittance.Dto;
public class HistoryRemittanceDto
{
    public required string Id {get ; set ; }
    public required DateTime CreatedAt {get ; set ;}
    public required string Customer {get ; set ;}
    public required string UserId {get ; set ; }
    public required string Account {get ; set ;}
    public required double AmountPay {get ; set ;} 
    public required double Amount {get ; set ;}
}