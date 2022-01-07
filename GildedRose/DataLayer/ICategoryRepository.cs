using GildedRoseKata.Model;

namespace GildedRoseKata.DataLayer
{
    public interface ICategoryRepository
    {
        ItemCategory GetCategory(string itemName);
    }
}
