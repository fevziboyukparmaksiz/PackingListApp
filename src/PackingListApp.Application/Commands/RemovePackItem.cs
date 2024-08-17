using PackingListApp.Shared.Abstractions.Commands;

namespace PackingListApp.Application.Commands;

public record RemovePackItem(
    Guid PackingListId, 
    string Name) : ICommand;

