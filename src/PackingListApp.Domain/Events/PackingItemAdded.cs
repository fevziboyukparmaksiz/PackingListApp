using PackingListApp.Domain.Entities;
using PackingListApp.Domain.ValueObjects;
using PackingListApp.Shared.Abstractions.Domain;

namespace PackingListApp.Domain.Events;
public record PackingItemAdded(
    PackingList PackingList,
    PackingItem PackingItem) : IDomainEvent;
  
