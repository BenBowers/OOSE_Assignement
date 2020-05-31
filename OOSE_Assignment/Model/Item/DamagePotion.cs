using System;
namespace OOSE_Assignment.Model.Item
{
    // Class representing a potion that deals damage
    public class DamagePotion : Potion
    {
        public DamagePotion(string name, int cost, int minEffect, int maxEffect)
            : base(name, cost, minEffect, maxEffect) { }
        public DamagePotion(DamagePotion damagePotion) : base(damagePotion) { }

        public override void Use(Character character) =>
            character.PotionDamage(GetEffect());

        public override string ToString()
        {
            return base.ToString() + "Potion Type: Damaging";
        }

        public override Potion Clone() => new DamagePotion(this);
    }
}
