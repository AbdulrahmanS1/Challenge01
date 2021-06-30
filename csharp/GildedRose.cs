using System.Collections.Generic;

namespace csharp
{
    public class GildedRose
    {
        readonly IList<Item> _items;
        public GildedRose(IList<Item> items)
        {
            this._items = items;
        }
        private static bool NameChecker(string name)
        {
            return (name != "Aged Brie" && name != "Backstage passes to a TAFKAL80ETC concert");
        }
        public void UpdateQuality()
        {
            foreach (var t in _items)
            {
                if (NameChecker(t.Name))
                {
                    if (t.Quality > 0)
                    {
                        if (t.Name != "Sulfuras, Hand of Ragnaros")
                        {
                            t.Quality -= 1;
                        }
                    }
                }
                else
                {
                    if (t.Quality < 50)
                    {
                        t.Quality += 1;

                        if (t.Name == "Backstage passes to a TAFKAL80ETC concert" && (t.SellIn < 11) )
                        {
                            t.Quality += 1;
                        }
                    }
                }

                if (t.Name != "Sulfuras, Hand of Ragnaros")
                {
                    t.SellIn -= 1;
                }

                if (t.SellIn >= 0) continue;
                if (t.Name != "Aged Brie")
                {
                    if (t.Name != "Backstage passes to a TAFKAL80ETC concert" && t.Quality > 0 && t.Name != "Sulfuras, Hand of Ragnaros")
                    {  
                        t.Quality -= 1;
                    }
                    else
                    {
                        t.Quality =0;
                    }
                }
                else if (t.Quality < 50)
                {
                    t.Quality += 1;
                }
            }
        }
    }
}
