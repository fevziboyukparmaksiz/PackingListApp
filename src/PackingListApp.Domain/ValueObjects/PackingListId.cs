using PackingListApp.Domain.Exceptions;

namespace PackingListApp.Domain.ValueObjects;
public record PackingListId
{
    public Guid Value { get; }

    public PackingListId(Guid value)
    {
        if (Value == Guid.Empty)
        {
            throw new EmptyPackingListIdException();
        }

        Value = value;
    }

    public static implicit operator Guid(PackingListId packingListId) 
        => packingListId.Value;

    public static implicit operator PackingListId(Guid Id) 
        => new(Id);
}
