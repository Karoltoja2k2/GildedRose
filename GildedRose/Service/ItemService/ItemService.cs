using GildedRoseKata.DataLayer;
using GildedRoseKata.Model;

namespace GildedRoseKata.Service.ItemService
{
    public class ItemService : IItemService
    {
        public void UpdateItem(Item item, ItemCategory category)
        {
            var handler = ItemUpdateHandlerStorage.GetHandler(category);
            handler.UpdateItem(item);
        }
    }
}
