using Xunit;
using System.Collections.Generic;
using GildedRoseKata;
using GildedRoseKata.Service.ItemService;

namespace GildedRoseTests
{
    public class GildedRoseTest
    {
        private readonly List<Item> items = new();

        private readonly GildedRose _sut;

        public GildedRoseTest()
        {
            _sut = new GildedRose(items);
        }

        [Theory]
        [InlineData(5, 8)]
        [InlineData(0, 6)]
        public void UpdateQuality_ShouldDecreaseQuality_WhenItemIsConjured(int sellIn, int expectedQuality)
        {
            // Arrange
            items.Clear();
            items.Add(new Item { Name = "Conjured Mana Cake", SellIn = sellIn, Quality = 10 });
            
            // Act
            _sut.UpdateQuality();

            // Assert
            Assert.Equal(expectedQuality, items[0].Quality);
        }

        [Fact]
        public void UpdateQuality_ShouldIncreaseQuality_WhenItemIsAgedBrie()
        {
            // Arrange
            items.Clear();
            items.Add(new Item { Name = "Aged Brie", SellIn = 5, Quality = 5 });
            
            // Act
            _sut.UpdateQuality();

            // Assert
            Assert.Equal(6, items[0].Quality);
        }

        [Fact]
        public void UpdateQuality_ShouldUpdateSellIn_WhenItemIsAgedBrie()
        {
            // Arrange
            items.Clear();
            items.Add(new Item { Name = "Aged Brie", SellIn = 5, Quality = 5 });
            
            // Act
            _sut.UpdateQuality();

            // Assert
            Assert.Equal(4, items[0].SellIn);
        }

        [Fact]
        public void UpdateQuality_ShouldIncreaseQualityTwiceFast_WhenItemIsAgedBrieAndSellDateExceeded()
        {
            // Arrange
            items.Clear();
            items.Add(new Item { Name = "Aged Brie", SellIn = 0, Quality = 5 });
            
            // Act
            _sut.UpdateQuality();

            // Assert
            Assert.Equal(7, items[0].Quality);
        }

        [Fact]
        public void UpdateQuality_ShouldNotUpdateQuality_WhenItemIsSulfuras()
        {
            // Arrange
            items.Clear();
            items.Add(new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 5, Quality = 80 });
            
            // Act
            _sut.UpdateQuality();

            // Assert
            Assert.Equal(80, items[0].Quality);
        }

        [Fact]
        public void UpdateQuality_ShouldNotUpdateSellIn_WhenItemIsSulfuras()
        {
            // Arrange
            items.Clear();
            items.Add(new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 5, Quality = 80 });
            
            // Act
            _sut.UpdateQuality();

            // Assert
            Assert.Equal(5, items[0].SellIn);
        }

        [Theory]
        [InlineData(15, 11)]
        [InlineData(10, 12)]
        [InlineData(5, 13)]
        [InlineData(-1, 0)]

        public void UpdateQuality_ShouldUpdateQuality_WhenItemIsConcert(int sellIn, int expectedQuality)
        {
            // Arrange
            items.Clear();
            items.Add(new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = sellIn, Quality = 10 });
            
            // Act
            _sut.UpdateQuality();

            // Assert
            Assert.Equal(expectedQuality, items[0].Quality);
        }

        [Theory]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", 50, 1)]
        [InlineData("Aged Brie", 50, 2)]
        [InlineData("+5 Dexterity Vest", 0, 5)]
        [InlineData("any item", 0, 5)]

        public void UpdateQuality_ShouldNotUpdateQuality_WhenItWouldReach0Or50(string itemName, int quality, int sellIn)
        {
            // Arrange
            items.Clear();
            items.Add(new Item { Name = itemName, SellIn = sellIn, Quality = quality });
            
            // Act
            _sut.UpdateQuality();

            // Assert
            Assert.Equal(quality, items[0].Quality);
        }

        [Theory]
        [InlineData("+5 Dexterity Vest", 10)]
        [InlineData("any item", 10)]

        public void UpdateQuality_ShouldDecreaseQualityTwiceFast_WhenItExceededSellInDate(string itemName, int quality)
        {
            // Arrange
            items.Clear();
            items.Add(new Item { Name = itemName, SellIn = 0, Quality = quality });
            
            // Act
            _sut.UpdateQuality();

            // Assert
            Assert.Equal(8, items[0].Quality);
        }
    }
}
