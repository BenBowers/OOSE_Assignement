using System;
namespace OOSE_Assignment.Model
{
    public class Weapon : Item
    {
        public string WeaponType { get; }
        public string DamageType { get; }

        public Weapon(string name, int cost, int minEffect, int maxEffect, string weaponType, string damageType) : base(name, cost, minEffect, maxEffect)
        {
            WeaponType = weaponType;
            DamageType = damageType;
        }
    }
}
