using System;

namespace OOSE_Assignment.Model
{
    public abstract class Potion : Item, ICloneable
    {
        public Potion(string name, int cost, int minEffect, int maxEffect) : base(name, cost, minEffect, maxEffect)
        {
        }

        public Potion(Potion potion) : base(potion)
        { 
        }

        public abstract void Use(Character character);

        public override string ToString()
        {
            return String.Format(
                "{0}, Cost: {1}, max Effect: {2}, min Effect: {3},",
                Name, Cost, MaxEffect, MinEffect);
        }

        #region ICloneable Members
        public abstract Potion Clone();
        object ICloneable.Clone() => this.Clone();
        #endregion
    }
}
