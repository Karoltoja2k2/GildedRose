using GildedRoseKata.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GildedRoseKata.Service.ItemService
{
    public static class ItemUpdateHandlerStorage
    {
        private static readonly IReadOnlyDictionary<ItemCategory, IItemUpdateHandler> storage = LoadHandlers();

        private static Dictionary<ItemCategory, IItemUpdateHandler> LoadHandlers()
        {
            var attrType = typeof(ItemUpdateHandlerAttribute);
            return attrType
                .Assembly
                .ExportedTypes
                .Select(x => ((ItemUpdateHandlerAttribute)Attribute.GetCustomAttribute(x, attrType), x))
                .Where(x => x.Item1 != null)
                .GroupBy(x => x.Item1.Category)
                .ToDictionary(x => x.Key, x => (IItemUpdateHandler)Activator.CreateInstance(x.First().x));
        }

        /// <summary>
        ///     Returns handler for item update, based on provided category
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public static IItemUpdateHandler GetHandler(ItemCategory category)
        {
            return storage.GetValueOrDefault(category, null);
        }
    }
}
