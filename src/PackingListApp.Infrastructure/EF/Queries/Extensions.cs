using PackingListApp.Application.DTO;
using PackingListApp.Infrastructure.EF.Models;

namespace PackingListApp.Infrastructure.EF.Queries;
internal static class Extensions
{
    public static PackingListDto AsDto(this PackingListReadModel packingListReadModel)
    {
        return new PackingListDto()
        {
            Id = packingListReadModel.Id,
            Name = packingListReadModel.Name,
            Localization = new LocalizationDto()
            {
                City = packingListReadModel.Localization.City,
                Country = packingListReadModel.Localization.Country
            },
            Items = packingListReadModel.Items.Select(pi => new PackingItemDto()
            {
                Name = pi.Name,
                Quantity = pi.Quantity,
                IsPacked = pi.IsPacked
            })
        };
    }
}
