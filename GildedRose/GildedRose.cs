using GildedRoseKata.Service.ItemService;
using GildedRoseKata.Service;
using System.Collections.Generic;

namespace GildedRoseKata
{
    public class GildedRose
    {
        public const int NormalItemQualityDecrease = -1;

        public const int NonLegendaryItemMinQuality = 0;

        public const int NonLegendaryItemMaxQuality = 50;

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
