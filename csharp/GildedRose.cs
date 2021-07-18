using System.Collections.Generic;

namespace csharp
{
    public class GildedRose
    {
        private const string AgedBrie = "Aged Brie";
        private const string BackStagePasses = "Backstage passes to a TAFKAL80ETC concert";
        private const string Sulfuras = "Sulfuras, Hand of Ragnaros";
        private const string Conjured = "Conjured Mana Cake";
        private const int MaxQuality = 50;
        private const int MinQuality = 0;
        private int _qualityRate = 1;
        

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

                if (item.Name == Conjured)
                    _qualityRate = 2;
                
                if (item.Name != AgedBrie && item.Name != BackStagePasses)
                {
                    DecreaseQuality(item);
                }
                else
                {
                    IncreaseQuality(item);

                        if (item.Name == BackStagePasses)
                        {
                            if (item.SellIn < 10)
                            {
                                IncreaseQuality(item);
                            }

                            if (item.SellIn < 5)
                            {
                                IncreaseQuality(item);
                            }
                        }
                }

                if (item.Quality <= 0)
                    item.Quality = 0;

                if (item.SellIn >= 0) continue;

                if (item.Name != AgedBrie)
                {
                    if (item.Name != BackStagePasses)
                    {
                            DecreaseQuality(item);
                    }
                    else
                    {
                        item.Quality = 0;
                    }
                }
                else
                {
                    IncreaseQuality(item);
                }
            }
        }

        private void IncreaseQuality(Item item)
        {
            if (item.Quality < MaxQuality)
            {
                item.Quality += _qualityRate;
            }
        }
        
        private void DecreaseQuality(Item item)
        {
            if (item.Quality > MinQuality)
            {
                item.Quality -= _qualityRate;
            }
        }
    }
}
