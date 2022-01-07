namespace GildedRoseKata.Service.ItemService
{

    public class ItemQualityHandlerStorage
    {
        public IItemQualityHandler GetHandler(string itemName)
        {
            return itemName switch
            {
                "Aged Brie" => new BrieLikeItemQualityHandler(),
                "Backstage passes to a TAFKAL80ETC concert" => new ConcertRelatedItemQualityHandler(),
                "Sulfuras, Hand of Ragnaros" => new LegendaryItemQualityHandler(),
                "Conjured Mana Cake" => new ConjuredItemQualityHandler(),
                _ => new DefaultItemQualityHandler()
            };
        }
    }
}
