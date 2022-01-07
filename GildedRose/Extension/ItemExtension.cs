using System;

namespace GildedRoseKata
{
    internal static class ItemExtension
    {
        public static void DecreaseSellIn(this Item item) =>
            item.SellIn -= 1;

        public static void IncreaseQuality(this Item item, int value) =>
            item.Quality += Math.Abs(value);

        public static void DecreaseQuality(this Item item, int value) =>
            item.Quality -= Math.Abs(value);

        public static void SetQualityValue(this Item item, int value) =>
            item.Quality = value;
    }
}
