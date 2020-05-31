using System;
namespace OOSE_Assignment.Model.Enemy
{
    /**
     * Abstract class representing every enemy in the game
     */
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

        // Returns a string of the attack done
        public virtual string Attack(Character character)
        {
            return Name + " did " + DoDamage(GetDamage(), character) + " damage to " + character.Name;
        }

        // Does the damage to the character returns the amount of damage done
        protected int DoDamage(int damage, Character character)
        {
            int initial = character.CurrentHealth;
            character.WeaponDamage(damage);
            return initial - character.CurrentHealth;
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
