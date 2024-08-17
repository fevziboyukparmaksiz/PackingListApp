using PackingListApp.Shared.Abstractions.Commands;

namespace PackingListApp.Application.Commands;

public record PackItem(
    Guid PackingListId, 
    string Name) : ICommand;
