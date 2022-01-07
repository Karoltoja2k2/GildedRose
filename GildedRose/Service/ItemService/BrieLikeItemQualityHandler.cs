namespace GildedRoseKata.Service.ItemService
{
    internal class BrieLikeItemQualityHandler : IItemQualityHandler
    {
        public void UpdateItem(Item item)
        {
            item.SellIn += GildedRose.DefaultSellInModifierValue;
            item.Quality = item.Quality + GildedRose.DefaultQualityModifierAbsValue;
            if (item.SellIn < 0)
            {
                item.Quality += GildedRose.DefaultQualityModifierAbsValue;
            }

            if (item.Quality > GildedRose.NonLegendaryItemMaxQualityValue)
            {
                item.Quality = GildedRose.NonLegendaryItemMaxQualityValue;
            }
        }
    }
}
