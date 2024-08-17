using PackingListApp.Shared.Abstractions.Exceptions;

namespace PackingListApp.Domain.Exceptions;
public class EmptyPackingListIdException : BaseException
{
    public EmptyPackingListIdException() : base("Packing List Id cannot be empty.")
    {
    }
}
