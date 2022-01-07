namespace GildedRoseKata.Service.ItemService
{
    public interface IItemService
    {
        /// <summary>
        ///     Updates item properties
        /// </summary>
        /// <param name="item"></param>
        void UpdateItem(Item item);
    }
}