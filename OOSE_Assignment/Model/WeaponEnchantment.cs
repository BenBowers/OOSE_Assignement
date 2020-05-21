using System;
namespace OOSE_Assignment.Model
{
    public class WeaponEnchantment
    {
        public int Cost { get; private set; }
        public Func<int, int> Attack { get; private set; }

        public WeaponEnchantment(int cost, Func<int, int> attack)
        {
            Cost = cost;
            Attack = attack;
        }

    }
}
