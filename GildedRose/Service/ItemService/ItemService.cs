using GildedRoseKata.Model;

namespace GildedRoseKata.Service.ItemService
{
    public class ItemService : IItemService
    {
        public void UpdateItem(Item item)
        {
            var handler = ItemUpdateHandlerStorage.GetHandler(item.Name);
            handler?.UpdateItem(item);
        }
    }
}
