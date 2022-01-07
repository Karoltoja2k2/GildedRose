using System;

namespace GildedRoseKata
{
    public static class ItemExtension
    {
        /// <summary>
        ///     Decrease item's SellIn value
        /// </summary>
        /// <param name="item"></param>
        public static void DecreaseSellIn(this Item item) =>
            item.SellIn -= 1;

        /// <summary>
        ///     Increases item's quality by <paramref name="value"/>
        /// </summary>
        /// <param name="item"></param>
        /// <param name="value"></param>
        public static void IncreaseQuality(this Item item, int value) =>
            item.Quality += Math.Abs(value);

        /// <summary>
        ///     Decreases item's quality by <paramref name="value"/>
        /// </summary>
        /// <param name="item"></param>
        /// <param name="value"></param>
        public static void DecreaseQuality(this Item item, int value) =>
            item.Quality -= Math.Abs(value);

        /// <summary>
        ///     Set item's quality to <paramref name="value"/>
        /// </summary>
        /// <param name="item"></param>
        /// <param name="value"></param>
        public static void SetQualityValue(this Item item, int value) =>
            item.Quality = value;
    }
}
