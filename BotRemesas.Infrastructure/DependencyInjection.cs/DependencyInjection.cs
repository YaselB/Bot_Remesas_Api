using BotRemesas.Application.Interfaces.Repository;
using BotRemesas.Application.Interfaces.Repository.Account;
using BotRemesas.Application.Interfaces.Repository.Admin;
using BotRemesas.Application.Interfaces.Repository.Generic;
using BotRemesas.Application.Interfaces.Repository.HistoryRemittance;
using BotRemesas.Application.Interfaces.Repository.Remittance;
using BotRemesas.Application.Interfaces.Repository.User;
using BotRemesas.Db;
using BotRemesas.Infrastructure.Repository.Account;
using BotRemesas.Infrastructure.Repository.Admin;
using BotRemesas.Infrastructure.Repository.Generic;
using BotRemesas.Infrastructure.Repository.HistoryRemittance;
using BotRemesas.Infrastructure.Repository.Pay;
using BotRemesas.Infrastructure.Repository.Remittance;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BotRemesas.Infrastructure.DependencyInjection;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services , IConfiguration configuration)
    {
        services.AddDbContext<BotRemesasDbContext>(options => options.UseNpgsql("Host=pstgres.railway.internal;Port=5432;Database=railway;Username=postgres;Password=WBnpLAiTBMjkKwgDcVNdHbLnUdiMALly", b => b.MigrationsAssembly(typeof(BotRemesasDbContext).Assembly.FullName)));
        services.AddScoped(typeof(IGenericRepository<>) , typeof(GenericRepository<>));
        services.AddScoped<IAdminRepository , AdminRepository>();
        services.AddScoped<IUserRepository , UserRepository>();
        services.AddScoped<IRemittanceRepository , RemittanceRepository>();
        services.AddScoped<IPayRepository , PayRepository>();
        services.AddScoped<IAccountRepository , AccountRepository>();
        services.AddScoped<IHistoryRemittanceRepository ,HistoryRemittanceRepository>();
        return services;
    }
}