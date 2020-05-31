using System;
using System.Collections.Generic;
using System.Linq;

namespace OOSE_Assignment.Model.Item
{
    /**
     * Class representing every weapon in the game
     */
    public class Weapon : Item, ICloneable
    {
        public string WeaponType { get; private set; }
        public string DamageType { get; private set; }
        public List<WeaponEnchantment> enchantments = new List<WeaponEnchantment>();

        public Weapon(string name, int cost, int minEffect, int maxEffect, string weaponType, string damageType) : base(name, cost, minEffect, maxEffect)
        {
            WeaponType = weaponType;
            DamageType = damageType;
        }

        public Weapon(Weapon weapon) : base(weapon)
        {
            WeaponType = weapon.WeaponType;
            DamageType = weapon.DamageType;
        }

        // Adds an enchantment to the weapon
        public void AddEnchantment(WeaponEnchantment enchantment) => enchantments.Add(enchantment);

        public int Attack()
        {
            int curDamage = base.GetEffect();

            // Will modify the damage with enchantments
            foreach(WeaponEnchantment enchantment in enchantments)
            {
                curDamage = enchantment.Attack(curDamage);
            }

            return curDamage;
        }

        public override string ToString()
        {
            string outString = String.Format(
                "{0}, Cost: {1}, max Damage: {2}, min Damage: {3}," +
                " WeaponType: {4}, DamageType: {5}",
                Name, Cost, MaxEffect, MinEffect, WeaponType, DamageType);
            if (enchantments.Any())
            {
                outString += " Enchantments: ";
                foreach(WeaponEnchantment enchantment in enchantments)
                {
                    outString += enchantment.Name + " ";
                }
            }
            return outString;
        }

        #region ICloneable Members
        public Weapon Clone() => new Weapon(this);
        object ICloneable.Clone() => this.Clone();
        #endregion
    }
}
