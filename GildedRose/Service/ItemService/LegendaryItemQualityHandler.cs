using GildedRoseKata.Model;

namespace GildedRoseKata.Service.ItemService
{
    [ItemUpdateHandler(ItemCategory.Legendary)]
    public class LegendaryItemQualityHandler : IItemUpdateHandler
    {
        public void UpdateItem(Item item)
        {
        }
    }
}
