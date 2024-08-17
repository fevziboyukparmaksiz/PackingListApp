using PackingListApp.Domain.ValueObjects;

namespace PackingListApp.Domain.Policies.Universal;
public class BasicPolicy : IPackingItemsPolicy
{
    public bool IsApplicable(PolicyData _)
        => true;

    public IEnumerable<PackingItem> GenerateItems(PolicyData policyData)
        => new List<PackingItem>
        {
            new("Jeans", (uint) Math.Ceiling(policyData.Days / 7m)),
            new("Socks", policyData.Days),
            new("T-shirt", policyData.Days),
            new("Shampoo", 1),
            new("Toothbrush", 1),
            new("Toothpaste", 1),
            new("Towel", 1),
            new("Bag pack", 1),
            new("Passport", 1),
            new("Phone Charger", 1)
        };
}
