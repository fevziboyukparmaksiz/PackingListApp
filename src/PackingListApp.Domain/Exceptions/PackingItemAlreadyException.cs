using PackingListApp.Shared.Abstractions.Exceptions;

namespace PackingListApp.Domain.Exceptions;
public class PackingItemAlreadyException : BaseException
{
    public PackingItemAlreadyException(string listName, string itemName) 
        : base($"Packing List : {listName} already defined item {itemName}")
    {
    }
}
