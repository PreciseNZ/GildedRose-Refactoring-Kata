using System.Collections.Generic;

namespace csharp
{
    public class GildedRose
    {
        private const string AgedBrie = "Aged Brie";

        private const string BackStagePasses = "Backstage passes to a TAFKAL80ETC concert";

        private const string Sulfuras = "Sulfuras, Hand of Ragnaros";

        private readonly IList<Item> _items;
        public GildedRose(IList<Item> items)
        {
            this._items = items;
        }

        public void UpdateQuality()
        {
            foreach (var item in _items)
            {
                if (item.Name == Sulfuras)
                    continue;

                item.SellIn -= 1;
                
                if (item.Name != AgedBrie && item.Name != BackStagePasses)
                {
                    if (item.Quality > 0)
                    {
                        item.Quality -= 1;
                    }
                }
                else
                {
                    if (item.Quality < 50)
                    {
                        item.Quality += 1;

                        if (item.Name == BackStagePasses)
                        {
                            if (item.SellIn < 10)
                            {
                                if (item.Quality < 50)
                                {
                                    item.Quality += 1;
                                }
                            }

                            if (item.SellIn < 5)
                            {
                                if (item.Quality < 50)
                                {
                                    item.Quality += 1;
                                }
                            }
                        }
                    }
                }
                
                

                if (item.SellIn < 0)
                {
                    if (item.Name != AgedBrie)
                    {
                        if (item.Name != BackStagePasses)
                        {
                            if (item.Quality > 0)
                            {
                                item.Quality -= 1;
                            }
                        }
                        else
                        {
                            item.Quality -= item.Quality;
                        }
                    }
                    else
                    {
                        if (item.Quality < 50)
                        {
                            item.Quality += 1;
                        }
                    }
                }
            }
        }
    }
}
