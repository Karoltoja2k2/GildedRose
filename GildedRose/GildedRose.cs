using GildedRoseKata.Service.ItemService;
using GildedRoseKata.Service;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;

namespace GildedRoseKata
{
    public class GildedRose
    {
        public const int DefaultQualityModifierAbsValue = 1;

        public const int DefaultSellInModifierValue = -1;

        public const int NonLegendaryItemMinQualityValue = 0;

        public const int NonLegendaryItemMaxQualityValue = 50;

        private readonly IItemService itemService;

        IList<Item> Items;

        public GildedRose(IList<Item> Items, IItemService itemService)
        {
            this.Items = Items;
            this.itemService = itemService;
        }

        public GildedRose(IList<Item> Items) : this (Items, new ItemService(new ItemQualityHandlerStorage()))
        {
        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                itemService.UpdateItem(item);
            }
        }
    }
}
