using System;
namespace OOSE_Assignment.Model.Enemy
{
    public abstract class Enemy : Character
    {
        private int minDefence;
        private int maxDefence;
        private int minAttack;
        private int maxAttack;

        public Enemy(string name,
                     int maximumHealth,
                     int minDefence,
                     int maxDefence,
                     int minAttack,
                     int maxAttack,
                     int gold)
            : base(name, maximumHealth, maximumHealth, gold)
        {
            this.minDefence = minDefence;
            this.maxDefence = maxDefence;
            this.minAttack = minAttack;
            this.maxAttack = maxAttack;
        }

        public virtual void Attack(Character character)
        {
            character.WeaponDamage(GetDamage());
        }

        public override void PotionDamage(int damage)
        {
            base.CurrentHealth = Math.Max(0, CurrentHealth - damage);
        }

        public override void WeaponDamage(int damage)
        {
            CurrentHealth = Math.Max(0, CurrentHealth - Defend(damage));
        }

        protected int Defend(int damage)
        {
            return Math.Max(0, damage - new Random().Next(minDefence, maxDefence));
        }

        protected int GetDamage()
        {
            return new Random().Next(minAttack, maxAttack);
        }

    }
}
