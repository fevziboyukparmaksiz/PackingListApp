using PackingListApp.Application.Exceptions;
using PackingListApp.Domain.Entities;
using PackingListApp.Domain.Repositories;
using PackingListApp.Shared.Abstractions.Commands;

namespace PackingListApp.Application.Commands.Handlers;
public class RemovePackingListHandler : ICommandHandler<RemovePackingList>
{
    private readonly IPackingListRepository _repository;

    public RemovePackingListHandler(IPackingListRepository repository)
    {
        _repository = repository;
    }

    public async Task HandleAsync(RemovePackingList command)
    {
        var packingList = await _repository.GetAsync(command.Id);

        if (packingList is null)
        {
            throw new PackingListNotFoundException(command.Id);
        }

        await _repository.DeleteAsync(packingList);
    }
}
