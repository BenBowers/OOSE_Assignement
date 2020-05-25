using System;
namespace OOSE_Assignment.Model
{
    public abstract class Item
    {
        public string Name { get; protected set; }
        public int Cost { get; protected set; }
        public int MinEffect { get; protected set; }
        public int MaxEffect { get; protected set; }

        public Item(string name, int cost, int minEffect, int maxEffect)
        {
            this.Name = name ?? throw new ArgumentNullException(nameof(name));
            this.Cost = cost;
            this.MinEffect = minEffect;
            this.MaxEffect = maxEffect;
        }

        public int GetEffect()
        {
            Random random = new Random();
            return random.Next(MinEffect, MaxEffect);
        }
    }
}
