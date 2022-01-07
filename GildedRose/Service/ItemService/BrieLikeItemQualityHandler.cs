namespace GildedRoseKata.Service.ItemService
{
    internal class BrieLikeItemQualityHandler : IItemQualityHandler
    {
        const int DefaultQualityIncrease = 1;
        const int MaxQuality = GildedRose.NonLegendaryItemMaxQualityValue;

        public void UpdateItem(Item item)
        {
            item.DecreaseSellIn();
            if (MaxQualityReached(item))
            {
                return;
            }

            var qualityIncrease = IsSellInDateExceeded(item) ? DefaultQualityIncrease * 2 : DefaultQualityIncrease;
            item.IncreaseQuality(qualityIncrease);
            if (MaxQualityReached(item))
            {
                item.SetQualityValue(MaxQuality);
            }
        }

        private bool MaxQualityReached(Item item)
        {
            return item.Quality >= MaxQuality;
        }

        private bool IsSellInDateExceeded(Item item)
        {
            return item.SellIn < 0;
        }
    }
}
