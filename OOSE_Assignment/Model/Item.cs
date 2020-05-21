using System;
namespace OOSE_Assignment.Model
{
    public abstract class Item
    {
        private string name;
        private int cost;
        private int minEffect;
        private int maxEffect;

        public Item(string name, int cost, int minEffect, int maxEffect)
        {
            this.name = name ?? throw new ArgumentNullException(nameof(name));
            this.cost = cost;
            this.minEffect = minEffect;
            this.maxEffect = maxEffect;
        }

        public int GetEffect()
        {
            Random random = new Random();
            return random.Next(minEffect, maxEffect);
        }
    }
}
