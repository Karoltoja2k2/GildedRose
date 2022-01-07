using GildedRoseKata.Service.ItemService;
using Xunit;

namespace GildedRoseTests.Unit
{
    public class ItemUpdateHandlerStorageTests
    {
        [Theory]
        [InlineData("Aged Brie")]
        [InlineData("Backstage passes to a TAFKAL80ETC concert")]
        [InlineData("Sulfuras, Hand of Ragnaros")]
        [InlineData("Conjured Mana Cake")]
        [InlineData("Anything +5")]
        public void GetHandler_ShouldReturnHandlersForAnyItem(string itemName)
        {
            Assert.NotNull(ItemUpdateHandlerStorage.GetHandler(itemName));
        }
    }
}
