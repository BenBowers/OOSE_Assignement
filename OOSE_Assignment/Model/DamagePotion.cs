using System;
namespace OOSE_Assignment.Model
{
    public class DamagePotion : Potion
    {
        public DamagePotion(string name, int cost, int minEffect, int maxEffect)
            : base(name, cost, minEffect, maxEffect) { }

        public override void Use(Character character) =>
            character.Damage(GetEffect());
    }
}
