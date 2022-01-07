using GildedRoseKata.Model;

namespace GildedRoseKata.Service.ItemService
{
    public interface IItemService
    {
        void UpdateItem(Item item, ItemCategory category);
    }
}