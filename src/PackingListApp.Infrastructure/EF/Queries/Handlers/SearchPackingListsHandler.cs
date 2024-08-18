using PackingListApp.Application.DTO;
using PackingListApp.Application.Queries;
using PackingListApp.Shared.Abstractions.Queries;

namespace PackingListApp.Infrastructure.EF.Queries.Handlers;
internal sealed class SearchPackingListsHandler : IQueryHandler<SearchPackingLists,IEnumerable<PackingListDto>>
{
    public async Task<IEnumerable<PackingListDto>> HandleAsync(SearchPackingLists query)
    {
        throw new NotImplementedException();
    }
}
