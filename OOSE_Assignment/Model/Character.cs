using System;
namespace OOSE_Assignment.Model
{
    /**
     * Abstract class representing every character in the name that can be damaged
     * and healed
     */
    public abstract class Character
    {
        public const string FORMAT_STRING = "Name: {0}, Health: {1}/{2}";
        public string Name { get; set; }
        public int MaximumHealth { get; protected set; }
        public int CurrentHealth { get; protected set; }
        public int Gold { get; protected set; }
        public bool Dead { get { return CurrentHealth <= 0; } }

        protected Character(string name, int maximumHealth, int currentHealth, int gold)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            MaximumHealth = maximumHealth;
            CurrentHealth = currentHealth;
            Gold = gold;
        }

        public void Heal(int healAmount) =>
            CurrentHealth = Math.Max(CurrentHealth + healAmount, MaximumHealth);

        public virtual void PotionDamage(int damage)
        {
            CurrentHealth = Math.Max(0, CurrentHealth - damage);
        }
        public abstract void WeaponDamage(int damage);

        public override string ToString()
        {
            return String.Format(FORMAT_STRING, Name, CurrentHealth, MaximumHealth);
        }
    }  
}
