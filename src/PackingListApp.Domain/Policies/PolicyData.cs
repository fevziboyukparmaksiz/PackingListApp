using PackingListApp.Domain.ValueObjects;

namespace PackingListApp.Domain.Policies;

public record PolicyData(
    TravelDays Days,
    Consts.Gender Gender,
    ValueObjects.Temperature Temperature,
    Localization Localization);
