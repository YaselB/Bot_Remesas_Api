namespace BotRemesas.Application.Features.User.Dto;
public class UserResultDto
{
    public required string Id {get ; set ;}
    public required string Name {get ; set ;}
    public required long IdUserTelegram {get ; set ;}
    public required string AdminId {get ; set ;}
    public required double PerCent {get ; set ;}
}