using PackingListApp.Domain.ValueObjects;

namespace PackingListApp.Domain.Policies;
public interface IPackingItemsPolicy
{
    bool IsApplicable(PolicyData policyData);
    IEnumerable<PackingItem> GenerateItems(PolicyData policyData);
}
