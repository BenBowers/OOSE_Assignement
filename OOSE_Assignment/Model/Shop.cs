using System;
using System.Collections.Generic;
using OOSE_Assignment.Model.Item;
namespace OOSE_Assignment.Model
{
    // Class representing the data needed for the games shop
    public class Shop
    {
        public List<Armour> Armours { get; private set; }
        public List<Weapon> Weapons { get; private set; }
        public List<Potion> Potions { get; private set; }
        public List<WeaponEnchantment> Enchantments { get; private set; }

        public Shop()
        {
            Armours = new List<Armour>();
            Weapons = new List<Weapon>();
            Potions = new List<Potion>();
            Enchantments = new List<WeaponEnchantment>();
        }

        public Shop(List<Armour> armours, List<Weapon> weapons, List<Potion> potions, List<WeaponEnchantment> enchantments)
        {
            this.Armours = armours ?? throw new ArgumentNullException(nameof(armours));
            this.Weapons = weapons ?? throw new ArgumentNullException(nameof(weapons));
            this.Potions = potions ?? throw new ArgumentNullException(nameof(potions));
            this.Enchantments = enchantments ?? throw new ArgumentNullException(nameof(enchantments));
        }

        public void AddItem(Armour armour) => Armours.Add(armour);
        public void AddItem(Weapon weapon) => Weapons.Add(weapon);
        public void AddItem(Potion potion) => Potions.Add(potion);
        public void AddEnchantment(WeaponEnchantment enchantment) => Enchantments.Add(enchantment);

        public void RemoveItem(Armour armour) => Armours.Remove(armour);
        public void RemoveItem(Weapon weapon) => Weapons.Remove(weapon);
        public void RemoveItem(Potion potion) => Potions.Remove(potion);
        public void RemoveEnchantment(WeaponEnchantment enchantment) => Enchantments.Remove(enchantment);
    }
}
