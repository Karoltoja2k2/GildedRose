using GildedRoseKata.Model;

namespace GildedRoseKata.DataLayer
{
    public class CategoryRepository : ICategoryRepository
    {
        public ItemCategory GetCategory(string itemName)
        {
            return itemName switch
            {
                "Aged Brie" => ItemCategory.Aged,
                "Backstage passes to a TAFKAL80ETC concert" => ItemCategory.Passess,
                "Sulfuras, Hand of Ragnaros" => ItemCategory.Legendary,
                "Conjured Mana Cake" => ItemCategory.Conjured,
                _ => ItemCategory.Default,
            };
        }

    }
}
