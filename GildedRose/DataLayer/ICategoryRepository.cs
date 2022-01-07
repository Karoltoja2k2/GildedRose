using GildedRoseKata.Model;

namespace GildedRoseKata.DataLayer
{
    public interface ICategoryRepository
    {
        /// <summary>
        ///     Returns category for item by it's name
        /// </summary>
        /// <param name="itemName"></param>
        /// <returns>Item category</returns>
        ItemCategory GetCategory(string itemName);
    }
}
