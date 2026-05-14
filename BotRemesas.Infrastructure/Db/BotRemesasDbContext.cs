using BotRemesas.Domain.DomainEvent;
using BotRemesas.Domain.Entities.Account;
using BotRemesas.Domain.Entities.Admin;
using BotRemesas.Domain.Entities.HistoryRemittances;
using BotRemesas.Domain.Entities.Pay;
using BotRemesas.Domain.Entities.Remittance;
using BotRemesas.Domain.Entities.User;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BotRemesas.Db;
public class BotRemesasDbContext : DbContext
{
    private readonly IMediator mediator;
    public BotRemesasDbContext(DbContextOptions<BotRemesasDbContext> options , IMediator mediator): base(options)
    {
        this.mediator = mediator;
    }
    public DbSet<AdminEntity> Admins {get ; set ;}
    public DbSet<UserEntity> Users {get ; set ;}
    public DbSet<RemittanceEntity> Remittances {get ; set ;}
    public DbSet<PayEntity> Pays{get ; set ;}
    public DbSet<AccountEntity> Accounts {get ; set ;}
    public DbSet<HistoryRemittanceEntity> HistoryRemittances {get ; set ;}
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<UserEntity>(entity =>
        {
            entity.HasOne(a => a.Admin).WithMany(a => a.Users).HasForeignKey(a => a.AdminId);
            entity.HasMany(u => u.Remittances).WithOne( u => u.User).HasForeignKey(u => u.UserId);
            entity.HasOne(u => u.Pay).WithOne(u => u.Users).HasForeignKey<PayEntity>(u => u.UserId);
            entity.HasMany(u => u.HistoryRemittances).WithOne(u => u.User).HasForeignKey(u => u.UserId);
        });
        modelBuilder.Entity<RemittanceEntity>(entity =>
        {
            entity.HasOne(a => a.Account).WithMany(a => a.RemittanceEntities).HasForeignKey(a => a.AccountId);
        });
        modelBuilder.Entity<AccountEntity>(entity =>
        {
            entity.HasOne(a => a.Admin).WithMany(a => a.AccountEntities).HasForeignKey(a => a.AdminId);
        });
    }
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var domainEventEntities = ChangeTracker.Entries<IHashDomainEvent>().Select(c => c.Entity).Where(c => c.DomainEvents.Any()).ToList();
        var domainEvents = domainEventEntities.SelectMany(c => c.DomainEvents).ToList();
        var result = await base.SaveChangesAsync(cancellationToken);
        foreach(var i in domainEvents)
        {
            await mediator.Publish(i, cancellationToken);
        }
        foreach(var i in domainEventEntities)
        {
            i.Clear();
        }
        return result;
    }
}