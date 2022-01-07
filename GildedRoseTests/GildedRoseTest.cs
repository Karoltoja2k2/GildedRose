using Xunit;
using System.Collections.Generic;
using GildedRoseKata;

namespace GildedRoseTests
{
    public class GildedRoseTest
    {
        [Fact]
        public void UpdateQuality_ShouldIncreaseQuality_WhenItemIsAgedBrie()
        {
            // Arrange
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 5, Quality = 5 } };
            GildedRose app = new GildedRose(Items);

            // Act
            app.UpdateQuality();

            // Assert
            Assert.Equal(6, Items[0].Quality);
        }

        [Fact]
        public void UpdateQuality_ShouldUpdateSellIn_WhenItemIsAgedBrie()
        {
            // Arrange
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 5, Quality = 5 } };
            GildedRose app = new GildedRose(Items);

            // Act
            app.UpdateQuality();

            // Assert
            Assert.Equal(4, Items[0].SellIn);
        }

        [Fact]
        public void UpdateQuality_ShouldIncreaseQualityTwiceFast_WhenItemIsAgedBrieAndSellDateExceeded()
        {
            // Arrange
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 0, Quality = 5 } };
            GildedRose app = new GildedRose(Items);

            // Act
            app.UpdateQuality();

            // Assert
            Assert.Equal(7, Items[0].Quality);
        }

        [Fact]
        public void UpdateQuality_ShouldNotUpdateQuality_WhenItemIsSulfuras()
        {
            // Arrange
            IList<Item> Items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 5, Quality = 80 } };
            GildedRose app = new GildedRose(Items);

            // Act
            app.UpdateQuality();

            // Assert
            Assert.Equal(80, Items[0].Quality);
        }

        [Fact]
        public void UpdateQuality_ShouldNotUpdateSellIn_WhenItemIsSulfuras()
        {
            // Arrange
            IList<Item> Items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 5, Quality = 80 } };
            GildedRose app = new GildedRose(Items);

            // Act
            app.UpdateQuality();

            // Assert
            Assert.Equal(5, Items[0].SellIn);
        }

        [Theory]
        [InlineData(15, 11)]
        [InlineData(10, 12)]
        [InlineData(5, 13)]
        [InlineData(-1, 0)]

        public void UpdateQuality_ShouldUpdateQuality_WhenItemIsConcert(int sellIn, int expectedQuality)
        {
            // Arrange
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = sellIn, Quality = 10 } };
            GildedRose app = new GildedRose(Items);

            // Act
            app.UpdateQuality();

            // Assert
            Assert.Equal(expectedQuality, Items[0].Quality);
        }

        [Theory]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", 50, 1)]
        [InlineData("Aged Brie", 50, 2)]
        [InlineData("+5 Dexterity Vest", 0, 5)]
        [InlineData("any item", 0, 5)]

        public void UpdateQuality_ShouldNotUpdateQuality_WhenItWouldReach0Or50(string itemName, int quality, int sellIn)
        {
            // Arrange
            IList<Item> Items = new List<Item> { new Item { Name = itemName, SellIn = sellIn, Quality = quality } };
            GildedRose app = new GildedRose(Items);

            // Act
            app.UpdateQuality();

            // Assert
            Assert.Equal(quality, Items[0].Quality);
        }

        [Theory]
        [InlineData("+5 Dexterity Vest", 10)]
        [InlineData("any item", 10)]

        public void UpdateQuality_ShouldDecreaseQualityTwiceFast_WhenItExceededSellInDate(string itemName, int quality)
        {
            // Arrange
            IList<Item> Items = new List<Item> { new Item { Name = itemName, SellIn = 0, Quality = quality } };
            GildedRose app = new GildedRose(Items);

            // Act
            app.UpdateQuality();

            // Assert
            Assert.Equal(8, Items[0].Quality);
        }
    }
}
