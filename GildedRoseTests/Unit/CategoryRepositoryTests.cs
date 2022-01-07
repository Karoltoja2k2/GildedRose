using GildedRoseKata.DataLayer;
using GildedRoseKata.Model;
using Xunit;

namespace GildedRoseTests.Unit
{
    public class CategoryRepositoryTests
    {
        private readonly ICategoryRepository _sut;

        public CategoryRepositoryTests()
        {
            _sut = new CategoryRepository();
        }

        [Theory]
        [InlineData("Aged Brie", ItemCategory.Aged)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", ItemCategory.Passess)]
        [InlineData("Sulfuras, Hand of Ragnaros", ItemCategory.Legendary)]
        [InlineData("Conjured Mana Cake", ItemCategory.Conjured)]
        public void GetCategory_ShouldReturnValidCateogry(string itemName, ItemCategory validCategory)
        {
            Assert.Equal(validCategory, _sut.GetCategory(itemName));
        }
    }
}
