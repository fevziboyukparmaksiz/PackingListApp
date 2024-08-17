using PackingListApp.Shared.Abstractions.Exceptions;

namespace PackingListApp.Domain.Exceptions;
public class InvalidTravelDaysException : BaseException
{
    public ushort Days { get;}

    public InvalidTravelDaysException(ushort days) : base($"Value '{days}' is invalid travel days.")
        => Days = days;
}
