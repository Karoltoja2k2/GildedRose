using GildedRoseKata.Model;
using GildedRoseKata.Service.ItemService;
using Xunit;

namespace GildedRoseTests.Unit
{
    public class ItemUpdateHandlerStorageTests
    {
        [Theory]
        [InlineData(ItemCategory.Default)]
        [InlineData(ItemCategory.Aged)]
        [InlineData(ItemCategory.Legendary)]
        [InlineData(ItemCategory.Passess)]
        [InlineData(ItemCategory.Conjured)]
        public void GetHandler_ShouldReturnHandlersForAvailableCategories(ItemCategory itemCategory)
        {
            Assert.NotNull(ItemUpdateHandlerStorage.GetHandler(itemCategory));
        }
    }
}
