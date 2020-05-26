using System;
namespace OOSE_Assignment.Model
{
    public abstract class Character
    {
        public string Name { get; set; }
        public int MaximumHealth { get; protected set; }
        public int CurrentHealth { get; protected set; }
        public int Gold { get; protected set; }

        protected Character(string name, int maximumHealth, int currentHealth, int gold)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            MaximumHealth = maximumHealth;
            CurrentHealth = currentHealth;
            Gold = gold;
        }

        public void Heal(int healAmount) =>
            CurrentHealth = Math.Max(CurrentHealth + healAmount, MaximumHealth);

        public abstract void PotionDamage(int damage);
        public abstract void WeaponDamage(int damage);
    }
}
