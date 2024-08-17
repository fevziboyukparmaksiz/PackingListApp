using PackingListApp.Shared.Abstractions.Exceptions;

namespace PackingListApp.Domain.Exceptions;
public class EmptyPackingListItemNameException : BaseException
{
    public EmptyPackingListItemNameException() : base("Packing item name cannot be empty.")
    {
    }
}
