using System;
using System.Collections.Generic;

namespace OOSE_Assignment.Model
{
    public class WeaponEnchantment
    {
        public const string FORMAT_STRING = "Name: {0}, Cost: {1}";
        public string Name { get; }
        public int Cost { get; }
        public Func<int, int> Attack { get; }

        public WeaponEnchantment(string name, int cost, Func<int, int> attack)
        {
            Name = name;
            Cost = cost;
            Attack = attack;
        }

        public override string ToString()
        {
            return String.Format(FORMAT_STRING, Name, Cost);
        }
    }

    public static class Enchantements
    {
        public static WeaponEnchantment DamagePlus2 =
            new WeaponEnchantment("Damage +2", 5, x => x + 2);
        public static WeaponEnchantment DamagePlus5 =
            new WeaponEnchantment("Damage +5", 10, x => x + 5);
        public static WeaponEnchantment FireDamage =
            new WeaponEnchantment("Fire Damage", 20, x => x + new Random().Next(5, 10));
        public static WeaponEnchantment PowerUp =
            new WeaponEnchantment("Power Up", 10, x => (int)(x * 1.1));

        public static readonly WeaponEnchantment[] WeaponEnchantments = new WeaponEnchantment[]
            {
                DamagePlus2,
                DamagePlus5,
                FireDamage,
                PowerUp
            };
    }
}
