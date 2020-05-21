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
        public IEnumerable<Weapon> Weapons { get { return weapons; } }
        public IEnumerable<Armour> Armours { get { return armours; } }
        public IEnumerable<Potion> Potions { get { return potions; } }

        private readonly List<Weapon> weapons = new List<Weapon>();
        private readonly List<Armour> armours = new List<Armour>();
        private readonly List<Potion> potions = new List<Potion>();
        private int counter = 0;

        public Inventory() { }

        // Adds item to inventory
        public void AddItem(Weapon weapon) => AddItem(weapons, weapon);
        public void AddItem(Armour armour) => AddItem(armours, armour);
        public void AddItem(Potion potion) => AddItem(potions, potion);
        private void AddItem<E>(List<E> list, E item) where E : Item
        {
            if (counter < INVENTORY_SIZE)
            {
                list.Add(item);
                counter++;
            }
            else
            {
                throw new InventoryFullException();
            }
        }

        // Removes item from inventory
        public void RemoveItem(Weapon weapon) => RemoveItem(weapons, weapon);
        public void RemoveItem(Armour armour) => RemoveItem(armours, armour);
        public void RemoveItem(Potion potion) => RemoveItem(potions, potion);
        private void RemoveItem<E>(List<E> list, E item) where E : Item
        {
            if (!list.Remove(item))
            {
                throw new ItemNotFoundException();
            }

            counter--;
        }

        public bool Contains(Weapon weapon) => weapons.Contains(weapon);
        public bool Contains(Armour armour) => armours.Contains(armour);
        public bool Contains(Potion potion) => potions.Contains(potion);
    }
}
