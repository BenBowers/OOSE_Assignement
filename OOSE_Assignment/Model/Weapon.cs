using System;
using System.Collections.Generic;

namespace OOSE_Assignment.Model
{
    public class Weapon : Item
    {
        public string WeaponType { get; private set; }
        public string DamageType { get; private set; }
        public List<WeaponEnchantment> enchantments = new List<WeaponEnchantment>();

        public Weapon(string name, int cost, int minEffect, int maxEffect, string weaponType, string damageType) : base(name, cost, minEffect, maxEffect)
        {
            WeaponType = weaponType;
            DamageType = damageType;
        }

        public void AddEnchantment(WeaponEnchantment enchantment) => enchantments.Add(enchantment);

        public int Attack()
        {
            int curDamage = base.GetEffect();

            foreach(WeaponEnchantment enchantment in enchantments)
            {
                curDamage = enchantment.Attack(curDamage);
            }

            return curDamage;
        }

        public override string ToString()
        {
            return String.Format(
                "{0}, Cost: {1}, max Damage: {2}, min Damage: {3}," +
                " WeaponType: {4}, DamageType: {5}",
                Name, Cost, MaxEffect, MinEffect, WeaponType, DamageType);
        }
    }
}
