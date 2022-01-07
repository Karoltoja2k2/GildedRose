namespace GildedRoseKata.Service.ItemService
{
    internal class DefaultItemQualityHandler : IItemQualityHandler
    {
        public void UpdateItem(Item item)
        {
            item.SellIn += GildedRose.DefaultSellInModifierValue;
            item.Quality = item.Quality - GildedRose.DefaultQualityModifierAbsValue;
            if (item.SellIn < 0)
            {
                item.Quality = item.Quality - GildedRose.DefaultQualityModifierAbsValue;

            }

            if (item.Quality < GildedRose.NonLegendaryItemMinQualityValue)
            {
                item.Quality = GildedRose.NonLegendaryItemMinQualityValue;
            }
        }
    }
}
