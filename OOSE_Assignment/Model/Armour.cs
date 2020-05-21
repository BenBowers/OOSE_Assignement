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
    }
}
