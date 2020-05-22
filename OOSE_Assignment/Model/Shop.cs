using System;
using System.Collections.Generic;

namespace OOSE_Assignment.Model
{
    public class Shop
    {
        private List<Armour> armours;
        private List<Weapon> weapons;
        private List<Potion> potions;
        private List<WeaponEnchantment> enchantments;

        public Shop()
        {
            armours = new List<Armour>();
            weapons = new List<Weapon>();
            potions = new List<Potion>();
            enchantments = new List<WeaponEnchantment>();
        }

        public Shop(List<Armour> armours, List<Weapon> weapons, List<Potion> potions, List<WeaponEnchantment> enchantments)
        {
            this.armours = armours ?? throw new ArgumentNullException(nameof(armours));
            this.weapons = weapons ?? throw new ArgumentNullException(nameof(weapons));
            this.potions = potions ?? throw new ArgumentNullException(nameof(potions));
            this.enchantments = enchantments ?? throw new ArgumentNullException(nameof(enchantments));
        }

        public void AddItem(Armour armour) => armours.Add(armour);
        public void AddItem(Weapon weapon) => weapons.Add(weapon);
        public void AddItem(Potion potion) => potions.Add(potion);
        public void AddEnchantment(WeaponEnchantment enchantment) => enchantments.Add(enchantment);

        public void RemoveItem(Armour armour) => armours.Remove(armour);
        public void RemoveItem(Weapon weapon) => weapons.Remove(weapon);
        public void RemoveItem(Potion potion) => potions.Remove(potion);
        public void RemoveEnchantment(WeaponEnchantment enchantment) => enchantments.Remove(enchantment);
    }
}
