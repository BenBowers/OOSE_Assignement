using System;
namespace OOSE_Assignment.Model
{
    public abstract class Enemy : Character
    {
        private int minDefence;
        private int maxDefence;
        private int minAttack;
        private int maxAttack;

        public Enemy(string name, int maximumHealth, int gold) : base(name, maximumHealth, maximumHealth, gold)
        {
        }
    }
}
