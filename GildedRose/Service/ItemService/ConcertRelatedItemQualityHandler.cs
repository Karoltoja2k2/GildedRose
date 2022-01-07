namespace GildedRoseKata.Service.ItemService
{
    internal class ConcertRelatedItemQualityHandler : IItemQualityHandler
    {
        const int SellInFirstThreshold = 10;
        const int SellInSecondThreshold = 5;
        const int DefaultQualityIncrease = 1;
        const int FirstThresholdQualityIncrease = 2;
        const int SecondThresholdQualityIncrease = 3;
        const int MaxQuality = GildedRose.NonLegendaryItemMaxQuality;
        const int MinQuality = GildedRose.NonLegendaryItemMinQuality;

        public void UpdateItem(Item item)
        {
            item.DecreaseSellIn();

            if (PassedConcert(item))
            {
                item.SetQualityValue(MinQuality);
                return;
            }

            if (MaxQualityReached(item))
            {
                return;
            }

            int qualityIncrease = ResolveQualityIncrease(item);
            item.IncreaseQuality(qualityIncrease);
            if (MaxQualityReached(item))
            {
                item.SetQualityValue(MaxQuality);
            }
        }

        private static int ResolveQualityIncrease(Item item)
        {
            var qualityIncrease = DefaultQualityIncrease;
            switch (item.SellIn)
            {
                case <= SellInSecondThreshold:
                    qualityIncrease = SecondThresholdQualityIncrease;
                    break;
                case <= SellInFirstThreshold:
                    qualityIncrease = FirstThresholdQualityIncrease;
                    break;
            }

            return qualityIncrease;
        }

        private static bool MaxQualityReached(Item item)
        {
            return item.Quality >= MaxQuality;
        }

        private static bool PassedConcert(Item item)
        {
            return item.SellIn < 0;
        }
    }
}
