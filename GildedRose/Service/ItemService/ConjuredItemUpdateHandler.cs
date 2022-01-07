using GildedRoseKata.Model;

namespace GildedRoseKata.Service.ItemService
{
    [ItemUpdateHandler(ItemCategory.Conjured)]
    public class ConjuredItemUpdateHandler : IItemUpdateHandler
    {
        const int QualityDecrease = GildedRose.NormalItemQualityDecrease;
        const int MinQuality = GildedRose.NonLegendaryItemMinQuality;

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
            return item.Quality < GildedRose.NonLegendaryItemMinQuality;
        }
    }
}
