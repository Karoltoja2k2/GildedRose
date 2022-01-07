using GildedRoseKata.Model;
using System;

namespace GildedRoseKata.Service.ItemService
{
    internal class ItemUpdateHandlerAttribute : Attribute
    {
        internal readonly ItemCategory Category;

        internal ItemUpdateHandlerAttribute(ItemCategory category)
        {
            Category = category;
        }
    }
}
