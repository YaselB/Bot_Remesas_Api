namespace BotRemesas.Application.Features.Remittance.Dto;
public class RemittanceResultDto
{
    public required string? userName {get ; set ;}
    public required string? Address {get ; set ;}
    public required string Customer {get ; set ;}
    public required double Amount {get ; set ;}
    public required string UrlImage {get ; set ;}
    public required bool Enabled {get ; set ;}
    public required string Id {get ; set ;}
    public required string? UserId {get ; set ;}
}