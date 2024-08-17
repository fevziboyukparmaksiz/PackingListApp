using PackingListApp.Shared.Abstractions.Exceptions;

namespace PackingListApp.Application.Exceptions;
public class PackingListAlreadyExistsException : BaseException
{
    public string Name { get; }

    public PackingListAlreadyExistsException(string name) 
        : base($"Packing list with name '{name} is already exists.'")
    {
        Name = name;
    }
}
