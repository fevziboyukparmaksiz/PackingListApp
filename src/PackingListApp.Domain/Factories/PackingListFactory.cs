using PackingListApp.Domain.Consts;
using PackingListApp.Domain.Entities;
using PackingListApp.Domain.Policies;
using PackingListApp.Domain.ValueObjects;

namespace PackingListApp.Domain.Factories;
public sealed class PackingListFactory : IPackingListFactory
{
    private readonly IEnumerable<IPackingItemsPolicy> _policies;

    public PackingListFactory(IEnumerable<IPackingItemsPolicy> policies)
        => _policies = policies;

    public PackingList Create(PackingListId id, PackingListName name, Localization localization)
        => new (id, name, localization);

    public PackingList CreateWithDefaultItems(PackingListId id, PackingListName name, TravelDays days, Gender gender,
        Temperature temperature, Localization localization)
    {
        var policyData = new PolicyData(days, gender, temperature, localization);
        var applicablePolicies = _policies.Where(p => p.IsApplicable(policyData));

        var items = applicablePolicies.SelectMany(p => p.GenerateItems(policyData));
        var packingList = new PackingList(id, name, localization);

        packingList.AddItems(items);
        return packingList;
    }
}
