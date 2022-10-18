﻿using System.Collections.Generic;
using GreenStore.interfaces;
using GreenStore.Models;
using GreenStore.Models.Interfaces;

namespace GreenStore
{
    public class QualityUpdater : IQualityUpdater,IItemVisitor
    {
        private readonly IList<IItem> _items;
        public QualityUpdater(IList<IItem> items)
        {
            _items = items;
        }

        public void DoUpdate()
        {
            foreach (var item in _items)
            {
                item.Accept(this);
            }
        }

        public void Visit(LongClawItem item)
        {
            if (item.SellIn < 0 && item.Quality > 0 && typeof(LongClawItem) != item.GetType())
            {
                item.Quality -= 1;
            }
        }
        public void Visit(AgedCheddarItem item)
        {
            if (item.Quality < 50)
            {
                item.Quality += 1;
            }

            item.SellIn -= 1;
            
            if (item.SellIn < 0 &&item.Quality < 50)
            {
                item.Quality += 1;
            }
        }
        public void Visit(Plus3AgilityVestItem item)
        {
            if (item.Quality > 0)
            {
                item.Quality -= 1;
            }

            item.SellIn -= 1;

            if (item.SellIn < 0 && item.Quality > 0 && typeof(LongClawItem) != item.GetType())
            {
                item.Quality -= 1;
            }
        }

        public void Visit(ConjuredCharismaPotionItem item)
        {
            if (item.Quality > 0)
            {
                item.Quality -= 2;
            }
            
            item.SellIn -= 1;
            
            if (item.SellIn < 0 && item.Quality > 0 && typeof(LongClawItem) != item.GetType())
            {
                item.Quality -= 2;
            }

        }

        public void Visit(ElixiroftheBearItem item)
        {
            if (item.Quality > 0)
            {
                item.Quality -= 1;
            }
            
            item.SellIn -= 1;
            
            if (item.SellIn < 0 && item.Quality > 0)
            {
                item.Quality -= 1;
            }

        }
        public void Visit(ViPTicketsToASamuraiConcertItem item)
        {
            if (item.Quality < 50)
            {
                item.Quality += 1;

                if (item.SellIn < 11)
                {
                    if (item.Quality < 50)
                    {
                        item.Quality += 1;
                    }
                }

                if (item.SellIn < 6)
                {
                    if (item.Quality < 50)
                    {
                        item.Quality += 1;
                    }
                }
            }

            item.SellIn -= 1;

            if (item.SellIn < 0)
            {
                item.Quality -= item.Quality;
            }
        }
    }
}
