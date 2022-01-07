namespace GildedRoseKata.Service.ItemService
{
    internal class ConjuredItemQualityHandler : IItemQualityHandler
    {
        const int QualityDecrease = GildedRose.NormalItemQualityDecrease;
        const int MinQuality = GildedRose.NonLegendaryItemMinQualityValue;

        public void UpdateItem(Item item)
        {
            item.DecreaseSellIn();
            if (MinQualityReached(item))
            {
                return;
            }

            var qualityModifier = (item.SellIn < 0 ? QualityDecrease * 2 : QualityDecrease) * 2;
            item.DecreaseQuality(qualityModifier);
            if (MinQualityReached(item))
            {
                item.SetQualityValue(MinQuality);
            }
        }

        private static bool MinQualityReached(Item item)
        {
            return item.Quality < GildedRose.NonLegendaryItemMinQualityValue;
        }
    }
}
