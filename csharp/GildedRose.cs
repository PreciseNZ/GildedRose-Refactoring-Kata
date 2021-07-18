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
        private int _qualityAdjustmentAmount = -1;

        private readonly IList<Item> _items;

        public GildedRose(IList<Item> items)
        {
            _items = items;
        }

        public void UpdateQuality()
        {
            foreach (var item in _items)
            {
                if (item.Name == Sulfuras)
                    continue;

                item.SellIn -= 1;

                if (item.Name == Conjured)
                    _qualityAdjustmentAmount = -2;

                if (item.Name == AgedBrie)
                    _qualityAdjustmentAmount = 1;

                if (item.Name == BackStagePasses)
                {
                    _qualityAdjustmentAmount = 1;
                    AdjustQuality(item);
                    if (item.SellIn < 10) AdjustQuality(item);
                    if (item.SellIn < 5) AdjustQuality(item);
                    if (item.SellIn < 0) item.Quality = 0;
                    continue;
                }

                AdjustQuality(item);

                if (item.SellIn < 0)
                    AdjustQuality(item);
            }
        }

        private void AdjustQuality(Item item)
        {
            item.Quality += _qualityAdjustmentAmount;
            if (item.Quality <= MinQuality) item.Quality = MinQuality;
            if (item.Quality >= MaxQuality) item.Quality = MaxQuality;
        }
    }
}