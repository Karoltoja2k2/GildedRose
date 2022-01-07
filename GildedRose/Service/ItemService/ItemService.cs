namespace GildedRoseKata.Service.ItemService
{
    public class ItemService : IItemService
    {
        private readonly ItemQualityHandlerStorage _storage;

        public ItemService(ItemQualityHandlerStorage storage)
        {
            _storage = storage;
        }

        public void UpdateItem(Item item)
        {
            var handler = _storage.GetHandler(item.Name);
            handler.UpdateItem(item);
        }
    }
}
