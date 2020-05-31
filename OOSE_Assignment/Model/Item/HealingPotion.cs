using System;
namespace OOSE_Assignment.Model.Item
{
    // Class that represents a potion that heals
    public class HealingPotion : Potion
    {
        public HealingPotion(string name, int cost, int minEffect, int maxEffect)
            : base(name, cost, minEffect, maxEffect) { }
        public HealingPotion(HealingPotion healingPotion) : base(healingPotion) { }

        public override void Use(Character character)
            => character.Heal(GetEffect());

        public override string ToString()
        {
            return base.ToString() + "Potion Type: Healing";
        }

        public override Potion Clone() => new HealingPotion(this);
    }
}
