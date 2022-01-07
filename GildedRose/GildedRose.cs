using System.Collections.Generic;

namespace GildedRoseKata
{
    public class GildedRose
    {
        public const int DefaultQualityModifierAbsValue = 1;

        public const int DefaultSellInModifierValue = -1;

        public const int NonLegendaryItemMinQualityValue = 0;

        public const int NonLegendaryItemMaxQualityValue = 50;

        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }
        
        private void DecreaseSellInDate(Item item)
        {
            if (item.Name != "Sulfuras, Hand of Ragnaros")
            {
                item.SellIn += DefaultSellInModifierValue;
            }
        }

        private void HandleAgedBrie(Item item)
        {
            item.Quality = item.Quality + DefaultQualityModifierAbsValue;
            if (item.SellIn < 0)
            {
                item.Quality += DefaultQualityModifierAbsValue;
            }

            if (item.Quality > NonLegendaryItemMaxQualityValue)
            {
                item.Quality = NonLegendaryItemMaxQualityValue;
            }
        }

        private void HandleBackstage(Item item)
        {
            const int SellInFirstThreshold = 11;
            const int SellInSecondThreshold = 6;
            if (item.SellIn < 0)
            {
                item.Quality = NonLegendaryItemMinQualityValue;
            }
            else
            {
                if (item.Quality < NonLegendaryItemMaxQualityValue)
                {
                    item.Quality = item.Quality + DefaultQualityModifierAbsValue;
                    if (item.SellIn < SellInFirstThreshold)
                    {
                        item.Quality = item.Quality + DefaultQualityModifierAbsValue;
                    }

                    if (item.SellIn < SellInSecondThreshold)
                    {
                        item.Quality = item.Quality + DefaultQualityModifierAbsValue;
                    }

                    if (item.Quality > NonLegendaryItemMaxQualityValue)
                    {
                        item.Quality = NonLegendaryItemMaxQualityValue;
                    }
                }
            }
        }

        private void HandleDefaultItem(Item item)
        {
            item.Quality = item.Quality - DefaultQualityModifierAbsValue;
            if (item.SellIn < 0)
            {
                item.Quality = item.Quality - DefaultQualityModifierAbsValue;

            }

            if (item.Quality < NonLegendaryItemMinQualityValue)
            {
                item.Quality = NonLegendaryItemMinQualityValue;
            }
        }

        private void HandleLegendaryItem(Item item)
        {
        }

        private void HandleConjuredItem(Item item)
        {
            var qualityModifier = (item.SellIn < 0 ? DefaultQualityModifierAbsValue + 1 : DefaultQualityModifierAbsValue) * 2;
            item.Quality -= qualityModifier;
            if (item.Quality < NonLegendaryItemMinQualityValue)
            {
                item.Quality = NonLegendaryItemMinQualityValue;
            }
        }

        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                var item = Items[i];
                DecreaseSellInDate(item);
                switch (item.Name)
                {
                    case "Aged Brie":
                        HandleAgedBrie(item);
                        break;
                    case "Backstage passes to a TAFKAL80ETC concert":
                        HandleBackstage(item);
                        break;
                    case "Sulfuras, Hand of Ragnaros":
                        HandleLegendaryItem(item);
                        break;
                    case "Conjured Mana Cake":
                        HandleConjuredItem(item);
                        break;
                    default:
                        HandleDefaultItem(item);
                        break;
                }
            }
        }
    }
}
