using BotRemesas.Application.Interfaces.Repository.Admin;
using BotRemesas.Db;
using BotRemesas.Domain.Entities.Admin;
using BotRemesas.Infrastructure.Repository.Generic;
using Microsoft.EntityFrameworkCore;

namespace BotRemesas.Infrastructure.Repository.Admin;

public class AdminRepository : GenericRepository<AdminEntity>, IAdminRepository
{
    private readonly BotRemesasDbContext context;
    public AdminRepository(BotRemesasDbContext dbContext) : base(dbContext)
    {
        context = dbContext;
    }

    public async Task<AdminEntity?> GetByIdTelegram(long id, CancellationToken cancellationToken)
    {
        return await context.Admins.FirstOrDefaultAsync(a => a.IdUserTelegram == id);
    }
}