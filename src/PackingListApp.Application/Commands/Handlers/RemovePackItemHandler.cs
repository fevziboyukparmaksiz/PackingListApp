using PackingListApp.Application.Exceptions;
using PackingListApp.Domain.Repositories;
using PackingListApp.Shared.Abstractions.Commands;

namespace PackingListApp.Application.Commands.Handlers;
public class RemovePackItemHandler : ICommandHandler<RemovePackItem>
{
    private readonly IPackingListRepository _repository;

    public RemovePackItemHandler(IPackingListRepository repository)
    {
        _repository = repository;
    }

    public async Task HandleAsync(RemovePackItem command)
    {
        var packingList = await _repository.GetAsync(command.PackingListId);

        if (packingList is null)
        {
            throw new PackingListNotFoundException(command.PackingListId);
        }

        packingList.RemoveItem(command.Name);
        await _repository.UpdateAsync(packingList);
    }
}
