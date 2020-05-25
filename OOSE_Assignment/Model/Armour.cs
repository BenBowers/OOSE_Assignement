using System;
namespace OOSE_Assignment.Model
{
    public class Armour : Item
    {
        private string material;

        public Armour(string name, int cost, int minEffect, int maxEffect, string material) : base(name, cost, minEffect, maxEffect)
        {
            this.material = material;
        }

        public override string ToString()
        {
            return String.Format(
            "{0}, Cost: {1}, max Damage: {2}, min Damage: {3}," +
            " Material: {4}",
            Name, Cost, MaxEffect, MinEffect, material);
        }
    }
}
