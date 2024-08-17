using PackingListApp.Shared.Abstractions.Exceptions;

namespace PackingListApp.Domain.Exceptions;
public class EmptyPackingListNameException : BaseException
{
    public EmptyPackingListNameException() : base("Packing list name cannot be empty.")
    {
    }
}
