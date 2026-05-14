using BotRemesas.Application.Interfaces.Repository.User;
using BotRemesas.Db;
using BotRemesas.Domain.Entities.User;
using BotRemesas.Infrastructure.Repository.Generic;
using Microsoft.EntityFrameworkCore;

namespace BotRemesas.Infrastructure.Repository.Admin;

public class UserRepository : GenericRepository<UserEntity>, IUserRepository
{
    private readonly BotRemesasDbContext context;
    public UserRepository(BotRemesasDbContext dbContext) : base(dbContext)
    {
        context = dbContext;
    }

    public async Task<UserEntity?> GetByIdUserTelegram(long idUserTelegram, CancellationToken cancellationToken)
    {
        var user = await context.Users.FirstOrDefaultAsync( u => u.IdUserTelegram == idUserTelegram);
        if(user == null)
        {
            return null;
        }
        return user;
    }
}