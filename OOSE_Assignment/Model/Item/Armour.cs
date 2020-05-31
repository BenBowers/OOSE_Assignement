using System;
namespace OOSE_Assignment.Model.Item
{
    /**
     * Class representing armour
     */
    public class Armour : Item, ICloneable
    {
        private string material;

        public Armour(string name, int cost, int minEffect, int maxEffect, string material) : base(name, cost, minEffect, maxEffect)
        {
            this.material = material;
        }

        public Armour(Armour armour) : base(armour)
        {
            material = armour.material;
        }

        public override string ToString()
        {
            return String.Format(
            "{0}, Cost: {1}, max Damage: {2}, min Damage: {3}," +
            " Material: {4}",
            Name, Cost, MaxEffect, MinEffect, material);
        }

        #region ICloneable Members
        public Armour Clone() => new Armour(this);
        object ICloneable.Clone() => this.Clone();
        #endregion
    }
}
