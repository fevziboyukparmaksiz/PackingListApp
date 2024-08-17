using PackingListApp.Shared.Abstractions.Exceptions;

namespace PackingListApp.Application.Exceptions;
public class PackingListNotFoundException : BaseException
{
    public Guid Id { get; }

    public PackingListNotFoundException(Guid id) : base($"Packing list with ID '{id}' was not found.")
    {
        Id = id;
    }



}
