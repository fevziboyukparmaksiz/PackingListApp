using PackingListApp.Domain.Events;
using PackingListApp.Domain.Exceptions;
using PackingListApp.Domain.ValueObjects;
using PackingListApp.Shared.Abstractions.Domain;

namespace PackingListApp.Domain.Entities;
public class PackingList : AggregateRoot<PackingListId>
{
    public PackingListId Id { get; private set; }

    public PackingListName Name { get;}
    public Localization Localization { get;}

    private readonly LinkedList<PackingItem> _items = new();

    private PackingList(PackingListId id, PackingListName name,Localization localization,LinkedList<PackingItem> items)
        : this(id,name,localization)
    {
        _items = items;
    }

    internal PackingList(PackingListId id, PackingListName name,Localization localization)
    {
        Id = id;
        Name = name;
        Localization = localization;
    }

    public void AddItem(PackingItem packingListItem)
    {
        var alreadyExists = _items.Any(i => i.Name == packingListItem.Name);

        if (alreadyExists)
        {
            throw new PackingItemAlreadyException(Name, packingListItem.Name);
        }

        _items.AddLast(packingListItem);

        AddEvent(new PackingItemAdded(this, packingListItem));
    }

    public void AddItems(IEnumerable<PackingItem> packingListItem)
    {
        foreach (var item in packingListItem)
        {
            AddItem(item);
        }
    }

    public void PackItem(string itemName)
    {
        var item = GetItem(itemName);
        var packedItem = item with { IsPacked = true };

        _items.Find(item)!.Value = packedItem;

        AddEvent(new PackingItemPacked(this,item));
    }

    private PackingItem GetItem(string itemName)
    {
        var item = _items.SingleOrDefault(i => i.Name == itemName);
        if (item is null)
        {
            throw new PackingItemNotFoundException(itemName);
        }

        return item;
    }


    public void RemoveItem(string itemName)
    {
        var item = GetItem(itemName);

        _items.Remove(item);

        AddEvent(new PackingItemRemoved(this,item));
    }
}
