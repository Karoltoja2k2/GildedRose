using GildedRoseKata.Model;
using System.Collections.Generic;

namespace GildedRoseKata.Service.ItemService
{
    public interface IItemService
    {
        void UpdateItem(Item item, ItemCategory category);
    }
}