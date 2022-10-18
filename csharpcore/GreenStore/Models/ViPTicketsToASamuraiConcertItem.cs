﻿using GreenStore.interfaces;
using GreenStore.Models.Interfaces;

namespace GreenStore.Models
{
    public class ViPTicketsToASamuraiConcertItem : Item, IItem
    {
        public new string Name => "VIP tickets to a Samurai concert";
        public void Accept(IItemVisitor qualityUpdater)
        {
            qualityUpdater.Visit(this);
        }
    }
}
