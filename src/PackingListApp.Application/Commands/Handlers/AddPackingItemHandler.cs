using PackingListApp.Application.Services;
using PackingListApp.Domain.Repositories;
using PackingListApp.Domain.ValueObjects;
using PackingListApp.Shared.Abstractions.Commands;

namespace PackingListApp.Application.Commands.Handlers;
public class AddPackingItemHandler : ICommandHandler<AddPackingItem>
{
    private readonly IPackingListRepository _repository;

    public AddPackingItemHandler(IPackingListRepository repository)
    {
        _repository = repository;
    }

    public async Task HandleAsync(AddPackingItem command)
    {
        var packingList = await _repository.GetAsync(command.PackingListId);

        if (packingList is null)
        {
            throw new Exception();
        }

        var packingItem = new PackingItem(command.Name, command.Quantity);
        packingList.AddItem(packingItem);

        await _repository.UpdateAsync(packingList);
    }
}
