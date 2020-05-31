using System;
using System.Collections.Generic;

namespace OOSE_Assignment.Model
{
    public class Player : Character
    {
        private class OwnershipException : Exception
        {
            public OwnershipException() : base("Player does not own this item") { }
        }

        private class InsufficientFundsException : Exception
        {
            public InsufficientFundsException() : base("Player does not have enough gold") { }
        }

        public const int DEFAULT_HEALTH = 30;
        public const int STARTING_GOLD = 100;
        public Weapon EquippedWeapon { get; private set; } = null;
        public Armour EquippedArmour { get; private set; } = null;
        public Inventory Inventory { get; private set; }


        public Player(string name, Inventory inventory)
            : base(name, DEFAULT_HEALTH, DEFAULT_HEALTH, STARTING_GOLD)
        {
            Inventory = inventory;
        }

        public Player(string name)
            : base(name, DEFAULT_HEALTH, DEFAULT_HEALTH, STARTING_GOLD)
        {
            Inventory = new Inventory();
        }

        public void EquipItem(Weapon weapon)
        {
            if (Inventory.Contains(weapon))
            {
                EquippedWeapon = weapon;
            }
            else
            {
                throw new OwnershipException();
            }
        }

        public void EquipItem(Armour armour)
        {
            if (Inventory.Contains(armour))
            {
                EquippedArmour = armour;
            }
            else
            {
                throw new OwnershipException();
            }
        }

        public void DequipWeapon() => EquippedWeapon = null;
        public void DequipArmour() => EquippedArmour = null;

        public void AddGold(int gold) => Gold += gold;
        public void RemoveGold(int amount)
        {
            if(Gold - amount < 0)
            {
                throw new InsufficientFundsException();
            }
            else
            {
                Gold -= amount;
            }
        }


        public override void WeaponDamage(int damage)
        {
            CurrentHealth = Math.Max(0, CurrentHealth - Defend(damage));
        }

        public override string ToString()
        {
            return base.ToString() +" Weapon: " + EquippedWeapon + " Armour: " + EquippedArmour;
        }

        private int Defend(int damage)
        {
            return Math.Max(0, damage - EquippedArmour.GetEffect());
        }
    }
}
