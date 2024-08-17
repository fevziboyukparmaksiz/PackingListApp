using PackingListApp.Domain.ValueObjects;
using PackingListApp.Shared.Abstractions.Exceptions;

namespace PackingListApp.Application.Exceptions;
public class MissingLocalizationWeatherException : BaseException
{
    public Localization Localization { get; }

    public MissingLocalizationWeatherException(Localization localization) 
        : base($"Couldn't fetch weather data for localization '{localization.Country}/{localization.City}'.")
    {
        Localization = localization;
    }
}
