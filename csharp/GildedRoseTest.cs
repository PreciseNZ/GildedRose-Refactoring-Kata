using NUnit.Framework;
using System.Collections.Generic;

namespace csharp
{
    [TestFixture]
    public class GildedRoseTest
    {
        [Test]
        public void BaseItem_WhenExpired_DecreasesByTwo()
        {
            var items = new List<Item> {new Item {Name = "Potion", SellIn = 0, Quality = 4}};
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.That(items[0].Quality, Is.EqualTo(2));
        }
        
        [Test]
        public void BaseItem_WhenNotExpired_DecreasesByOne()
        {
            var items = new List<Item> {new Item {Name = "Potion", SellIn = 2, Quality = 4}};
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.That(items[0].Quality, Is.EqualTo(3));
        }
        
        [Test]
        public void BaseItem_ZeroQuality_DoesNotGoNegative()
        {
            var items = new List<Item> {new Item {Name = "Potion", SellIn = 2, Quality = 0}};
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.That(items[0].Quality, Is.EqualTo(0));
        }

        [Test]
        public void AgedBrie_WhenNotExpired_IncreasesInQualityByOne()
        {
            var items = new List<Item> {new Item {Name = "Aged Brie", SellIn = 2, Quality = 0}};
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.That(items[0].Quality, Is.EqualTo(1));
        }
        
        [Test]
        public void AgedBrie_WhenExpired_IncreasesInQualityByTwo()
        {
            var items = new List<Item> {new Item {Name = "Aged Brie", SellIn = 0, Quality = 0}};
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.That(items[0].Quality, Is.EqualTo(2));
        }
        
        [Test]
        public void AgedBrie_DoesNotGoAbove50()
        {
            var items = new List<Item> {new Item {Name = "Aged Brie", SellIn = 5, Quality = 50}};
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.That(items[0].Quality, Is.EqualTo(50));
        }
        
        [Test]
        public void Sulfuras_Expired_QualityDoesntChange()
        {
            
            var items = new List<Item> {new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80}};
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.That(items[0].Quality, Is.EqualTo(80));
        }
        
        [Test]
        public void Sulfuras_NotExpired_QualityDoesntChange()
        {
            
            var items = new List<Item> {new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 2, Quality = 80}};
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.That(items[0].Quality, Is.EqualTo(80));
        }
        
        [Test]
        public void BackStagePass_ExpiresIn5Days_IncreaseInQualityByThree()
        {
            var items = new List<Item> {new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 40}};
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.That(items[0].Quality, Is.EqualTo(43));
        }

        [Test]
        public void BackStagePass_ExpiresIn10Days_IncreaseInQualityByTwo()
        {
            var items = new List<Item> {new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 40}};
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.That(items[0].Quality, Is.EqualTo(42));
        }
        
        [Test]
        public void BackStagePass_ExpiresIn20Days_IncreaseInQualityByOne()
        {
            var items = new List<Item> {new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 20, Quality = 40}};
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.That(items[0].Quality, Is.EqualTo(41));
        }

        [Test]
        public void BackStagePass_Expired_QualityIsZero()
        {
            
            var items = new List<Item> {new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 40}};
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.That(items[0].Quality, Is.EqualTo(0));
        }
        
        // [Test]
        // public void ConjuredManaCake_NotExpired_QualityDecreasesByTwo()
        // {
        //     
        //     var items = new List<Item> {new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}};
        //     var app = new GildedRose(items);
        //     app.UpdateQuality();
        //     Assert.That(items[0].Quality, Is.EqualTo(4));
        // }
    }
}
