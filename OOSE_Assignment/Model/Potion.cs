namespace OOSE_Assignment.Model
{
    public abstract class Potion : Item
    {
        public Potion(string name, int cost, int minEffect, int maxEffect) : base(name, cost, minEffect, maxEffect)
        {
        }

        public abstract void Use(Character character);
    }
}
