namespace GildedRoseKata.Service.ItemService
{
    internal class ConcertRelatedItemQualityHandler : IItemQualityHandler
    {
        public void UpdateItem(Item item)
        {
            const int SellInFirstThreshold = 11;
            const int SellInSecondThreshold = 6;

            item.SellIn += GildedRose.DefaultSellInModifierValue;
            if (item.SellIn < 0)
            {
                item.Quality = GildedRose.NonLegendaryItemMinQualityValue;
            }
            else
            {
                if (item.Quality < GildedRose.NonLegendaryItemMaxQualityValue)
                {
                    item.Quality = item.Quality + GildedRose.DefaultQualityModifierAbsValue;
                    if (item.SellIn < SellInFirstThreshold)
                    {
                        item.Quality = item.Quality + GildedRose.DefaultQualityModifierAbsValue;
                    }

                    if (item.SellIn < SellInSecondThreshold)
                    {
                        item.Quality = item.Quality + GildedRose.DefaultQualityModifierAbsValue;
                    }

                    if (item.Quality > GildedRose.NonLegendaryItemMaxQualityValue)
                    {
                        item.Quality = GildedRose.NonLegendaryItemMaxQualityValue;
                    }
                }
            }
        }
    }
}
