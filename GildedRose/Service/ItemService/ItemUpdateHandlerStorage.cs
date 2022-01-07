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
            var handlers = attrType
                .Assembly
                .ExportedTypes
                .Select(x => ((ItemUpdateHandlerAttribute)Attribute.GetCustomAttribute(x, attrType), x))
                .Where(x => x.Item1 != null);

            var storageLocal = new Dictionary<ItemCategory, IItemUpdateHandler>();
            foreach (var item in handlers)
            {
                storageLocal.TryAdd(item.Item1.Category, (IItemUpdateHandler)Activator.CreateInstance(item.x));
            }

            return storageLocal; 
        }

        public static IItemUpdateHandler GetHandler(ItemCategory category)
        {
            if (!storage.TryGetValue(category, out var handler))
            {
                throw new Exception($"Handler for {category} item category not found");
            }

            return handler;
        }
    }
}
