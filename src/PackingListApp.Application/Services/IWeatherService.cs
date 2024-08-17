using PackingListApp.Application.DTO.External;
using PackingListApp.Domain.ValueObjects;

namespace PackingListApp.Application.Services;
public interface IWeatherService
{
    Task<WeatherDto> GetWeatherAsync(Localization localization);
}
