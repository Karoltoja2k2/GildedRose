using GildedRoseKata.Model;

namespace GildedRoseKata.Service.ItemService
{
    public interface IItemService
    {
        /// <summary>
        ///     Updates item properties based on it's category
        /// </summary>
        /// <param name="item"></param>
        /// <param name="category"></param>
        void UpdateItem(Item item, ItemCategory category);
    }
}