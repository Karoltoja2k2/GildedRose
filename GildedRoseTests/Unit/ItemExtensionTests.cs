using GildedRoseKata;
using Xunit;

namespace GildedRoseTests.Unit
{
    public class ItemExtensionTests
    {
        [Theory]
        [InlineData(-5)]
        [InlineData(-0)]
        [InlineData(200)]

        public void DecreaseSellIn_ShouldDecreaseBy1(int sellIn)
        {
            var item = new Item { SellIn = sellIn };
            item.DecreaseSellIn();
            Assert.Equal(sellIn - 1, item.SellIn);
        }

        [Theory]
        [InlineData(-5, 2)]
        [InlineData(-0, 1)]
        [InlineData(200, 5)]

        public void DecreaseQuality_ShouldDecreaseByValue(int quality, int value)
        {
            var item = new Item { Quality = quality };
            item.DecreaseQuality(value);
            Assert.Equal(quality - value, item.Quality);
        }

        [Theory]
        [InlineData(-5, 2)]
        [InlineData(-0, 1)]
        [InlineData(200, 5)]

        public void IncreaseQuality_ShouldIncreaseByValue(int quality, int value)
        {
            var item = new Item { Quality = quality };
            item.IncreaseQuality(value);
            Assert.Equal(quality + value, item.Quality);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(-1, 0)]
        [InlineData(52, 50)]

        public void SetQualityValue_ShouldSet(int quality, int value)
        {
            var item = new Item { Quality = quality };
            item.SetQualityValue(value);
            Assert.Equal(value, item.Quality);
        }
    }
}
