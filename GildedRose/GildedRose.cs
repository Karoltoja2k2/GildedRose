using System.Collections.Generic;

namespace GildedRoseKata
{
    public class GildedRose
    {
        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }



        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                var item = Items[i];

                if (item.Name != "Sulfuras, Hand of Ragnaros")
                {
                    item.SellIn = item.SellIn - 1;
                }

                if (item.Name == "Aged Brie")
                {
                    item.Quality = item.Quality + 1;
                    if (item.SellIn < 0)
                    {
                        item.Quality += 1;
                    }
                    
                    if (item.Quality > 50)
                    {
                        item.Quality = 50;
                    }
                }
                else if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
                {
                    if (item.SellIn < 0)
                    {
                        item.Quality = 0;
                    }
                    else
                    {
                        if (item.Quality < 50)
                        {
                            item.Quality = item.Quality + 1;
                            if (item.SellIn < 11)
                            {
                                item.Quality = item.Quality + 1;
                            }

                            if (item.SellIn < 6)
                            {
                                item.Quality = item.Quality + 1;
                            }

                            if (item.Quality > 50)
                            {
                                item.Quality = 50;
                            }
                        }
                    }
                }
                else if (item.Name == "Sulfuras, Hand of Ragnaros")
                {

                }
                else
                {
                    item.Quality = item.Quality - 1;
                    if (item.SellIn < 0)
                    {
                        item.Quality = item.Quality - 1;

                    }

                    if (item.Quality < 0)
                    {
                        item.Quality = 0;
                    }
                }
            }
        }
    }
}
