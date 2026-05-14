using BotRemesas.Domain.Interfaces.DomainEvent;

namespace BotRemesas.Domain.DomainEvent;
public interface IHashDomainEvent
{
    public IReadOnlyCollection<IDomainEvent> DomainEvents {get ;}
    public void AddDomainEvent(IDomainEvent domainEvent);
    public void RemoveDomainEvent(IDomainEvent domainEvent);
    public void Clear();
}