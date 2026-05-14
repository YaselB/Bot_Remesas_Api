using System.ComponentModel.DataAnnotations;
using BotRemesas.Domain.DomainEvent;
using BotRemesas.Domain.Interfaces.DomainEvent;

namespace BotRemesas.Domain.Entities.Generic;
public class GenericEntity<T> : IHashDomainEvent where T : GenericEntity<T>
{
    private readonly List<IDomainEvent> domainEvents = new ();
    [Key]
    public string Id {get ; set ;} = Guid.NewGuid().ToString();
    public DateTime CreatedAt {get ; set ;} = DateTime.UtcNow;
    public DateTime UpdateAt { get ; set ;} = DateTime.UtcNow;

    public IReadOnlyCollection<IDomainEvent> DomainEvents => domainEvents.AsReadOnly();

    public void AddDomainEvent(IDomainEvent domainEvent)
    {
        domainEvents.Add(domainEvent);
    }

    public void Clear()
    {
        domainEvents.Clear();
    }

    public void RemoveDomainEvent(IDomainEvent domainEvent)
    {
        domainEvents.Remove(domainEvent);
    }
}