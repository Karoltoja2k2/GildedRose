namespace GildedRoseKata.Service.ItemService
{
    internal class ConjuredItemQualityHandler : IItemQualityHandler
    {
        public void UpdateItem(Item item)
        {
            item.SellIn += GildedRose.DefaultSellInModifierValue;
            var qualityModifier = (item.SellIn < 0 ? GildedRose.DefaultQualityModifierAbsValue + 1 : GildedRose.DefaultQualityModifierAbsValue) * 2;
            item.Quality -= qualityModifier;
            if (item.Quality < GildedRose.NonLegendaryItemMinQualityValue)
            {
                item.Quality = GildedRose.NonLegendaryItemMinQualityValue;
            }
        }
    }
}
