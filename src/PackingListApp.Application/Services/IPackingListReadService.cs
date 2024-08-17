using PackingListApp.Domain.ValueObjects;

namespace PackingListApp.Application.Services;
public interface IPackingListReadService
{
    Task<bool> ExistsAsync(PackingListName name);

}
