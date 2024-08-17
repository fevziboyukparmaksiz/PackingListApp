using PackingListApp.Shared.Abstractions.Commands;

namespace PackingListApp.Application.Commands;

public record AddPackingItem(
    Guid PackingListId, 
    string Name, 
    uint Quantity) : ICommand;

