using PackingListApp.Shared.Abstractions.Exceptions;

namespace PackingListApp.Domain.Exceptions;
public class InvalidTemperatureException :BaseException
{
    public double Temperature { get; }

    public InvalidTemperatureException(double temperature) : base($"Value '{temperature}' is invalid temperature.")
        => Temperature = temperature;
}
