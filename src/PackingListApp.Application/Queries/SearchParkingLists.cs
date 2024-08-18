using PackingListApp.Application.DTO;
using PackingListApp.Shared.Abstractions.Queries;

namespace PackingListApp.Application.Queries;
public class SearchPackingLists : IQuery<IEnumerable<PackingListDto>>
{
    public string SearchPhrase { get; set; }
}
