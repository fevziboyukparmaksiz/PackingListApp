using PackingListApp.Shared.Abstractions.Exceptions;

namespace PackingListApp.Domain.Exceptions;
public class PackingItemNotFoundException : BaseException
{
    public PackingItemNotFoundException(string itemName) : base($"Packing item '{itemName}' was not found")
    {
    }
}
