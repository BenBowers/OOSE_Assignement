using System;
namespace OOSE_Assignment.Model
{
    public class HealingPotion : Potion
    {
        public HealingPotion(string name, int cost, int minEffect, int maxEffect)
            : base(name, cost, minEffect, maxEffect) { }

        public override void Use(Character character)
            => character.Heal(GetEffect());

        public override string ToString()
        {
            return base.ToString() + "Potion Type: Healing";
        }
    }
}
