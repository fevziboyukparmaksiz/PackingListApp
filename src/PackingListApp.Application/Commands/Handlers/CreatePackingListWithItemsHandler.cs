using PackingListApp.Application.Exceptions;
using PackingListApp.Application.Services;
using PackingListApp.Domain.Factories;
using PackingListApp.Domain.Repositories;
using PackingListApp.Domain.ValueObjects;
using PackingListApp.Shared.Abstractions.Commands;

namespace PackingListApp.Application.Commands.Handlers;
public class CreatePackingListWithItemsHandler : ICommandHandler<CreatePackingListWithItems>
{
    private readonly IPackingListRepository _repository;
    private readonly IPackingListFactory _packingListFactory;
    private readonly IPackingListReadService _readService;
    private readonly IWeatherService _weatherService;

    public CreatePackingListWithItemsHandler(IPackingListRepository repository, IPackingListFactory packingListFactory, IPackingListReadService readService, IWeatherService weatherService)
    {
        _repository = repository;
        _packingListFactory = packingListFactory;
        _readService = readService;
        _weatherService = weatherService;
    }

    public async Task HandleAsync(CreatePackingListWithItems command)
    {
        var (id, name, days, gender, localizationWriteModel) = command;

        if (await _readService.ExistsAsync(name))
        {
            throw new PackingListAlreadyExistsException(name);
        }

        var localization = new Localization(localizationWriteModel.City, localizationWriteModel.Country);
        var weather = await _weatherService.GetWeatherAsync(localization);

        if (weather is null)
        {
            throw new MissingLocalizationWeatherException(localization);
        }

        var packingList =
            _packingListFactory.CreateWithDefaultItems(id, name, days, gender, weather.Temperature, localization);

        await _repository.AddAsync(packingList);

    }
}

