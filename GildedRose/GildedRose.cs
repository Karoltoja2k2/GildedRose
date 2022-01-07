using GildedRoseKata.Service.ItemService;
using System.Collections.Generic;
using GildedRoseKata.DataLayer;

namespace GildedRoseKata
{
    public class GildedRose
    {
        public const int NormalItemQualityDecrease = -1;

        public const int NonLegendaryItemMinQuality = 0;

        public const int NonLegendaryItemMaxQuality = 50;

        private readonly IItemService itemService;

        private readonly ICategoryRepository categoryRepository;

        IList<Item> Items;

        public GildedRose(IList<Item> Items,
            IItemService itemService,
            ICategoryRepository categoryRepository)
        {
            this.Items = Items;
            this.itemService = itemService;
            this.categoryRepository = categoryRepository;
        }

        public GildedRose(IList<Item> Items) : this (Items, new ItemService(), new CategoryRepository())
        {
        }

        /// <summary>
        ///     Update quality for every item in gilded rose
        /// </summary>
        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                var category = categoryRepository.GetCategory(item.Name);
                itemService.UpdateItem(item, category);
            }
        }
    }
}
