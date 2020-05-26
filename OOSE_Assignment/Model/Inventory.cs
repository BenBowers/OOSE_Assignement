using System;
using System.Collections.Generic;

namespace OOSE_Assignment.Model
{
    public class InventoryFullException : Exception
    {
        public InventoryFullException() : base("Inventory is full") { }
    }

    public class ItemNotFoundException : Exception
    {
        public ItemNotFoundException() : base("Item not found") { }
    }


    public class Inventory
    {
        public const int INVENTORY_SIZE = 15;

        public List<Weapon> Weapons { get; private set; } = new List<Weapon>();
        public List<Armour> Armours { get; private set; } = new List<Armour>();
        public List<Potion> Potions { get; private set; } = new List<Potion>();
        public int Capacity { get; private set; } = 0;

        public Inventory() { }

        // Adds item to inventory
        public void AddItem(Weapon weapon) => AddItem(Weapons, weapon);
        public void AddItem(Armour armour) => AddItem(Armours, armour);
        public void AddItem(Potion potion) => AddItem(Potions, potion);
        private void AddItem<E>(List<E> list, E item) where E : Item
        {
            if (Capacity < INVENTORY_SIZE)
            {
                list.Add(item);
                Capacity++;
            }
            else
            {
                throw new InventoryFullException();
            }
        }

        // Removes item from inventory
        public void RemoveItem(Weapon weapon) => RemoveItem(Weapons, weapon);
        public void RemoveItem(Armour armour) => RemoveItem(Armours, armour);
        public void RemoveItem(Potion potion) => RemoveItem(Potions, potion);
        private void RemoveItem<E>(List<E> list, E item) where E : Item
        {
            if (!list.Remove(item))
            {
                throw new ItemNotFoundException();
            }

            Capacity--;
        }

        public bool Contains(Weapon weapon) => Weapons.Contains(weapon);
        public bool Contains(Armour armour) => Armours.Contains(armour);
        public bool Contains(Potion potion) => Potions.Contains(potion);
    }
}
