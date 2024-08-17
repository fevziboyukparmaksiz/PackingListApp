﻿using PackingListApp.Domain.Consts;
using PackingListApp.Domain.Entities;
using PackingListApp.Domain.ValueObjects;

namespace PackingListApp.Domain.Factories;
public interface IPackingListFactory
{
    PackingList Create(PackingListId id, PackingListName name, Localization localization);
    PackingList CreateWithDefaultItems(PackingListId id, PackingListName name,TravelDays days,Gender gender,
        Temperature temperature,Localization localization);
}
