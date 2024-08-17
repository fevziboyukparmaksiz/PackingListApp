using PackingListApp.Shared.Abstractions.Commands;

namespace PackingListApp.Application.Commands;
public record RemovePackingList(Guid Id) : ICommand;
