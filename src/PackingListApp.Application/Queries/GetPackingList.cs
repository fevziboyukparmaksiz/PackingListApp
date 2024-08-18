using PackingListApp.Application.DTO;
using PackingListApp.Shared.Abstractions.Queries;

namespace PackingListApp.Application.Queries;
public class GetPackingList : IQuery<PackingListDto>
{
    public Guid Id { get; set; }
}
