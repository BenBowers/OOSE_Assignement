using System;
using System.Collections.Generic;
using OOSE_Assignment.Model;
using OOSE_Assignment.Model.Item;
namespace OOSE_Assignment.View
{
    /**
     * Menu that is displayed when a user wants to sell an item
     */
    public class SellMenu : MethodMenu
    {
        public const string NAME = "Shop";
        public const string STATUS_BAR = "Current Gold: {0}, Inventory {1}/{2}";
        private const string EQUIPPED_ITEM_ERROR = "Cannot sell equiped item";
        private Player player;

        private string Status => String.Format(STATUS_BAR,
                    player.Gold,
                    player.Inventory.Capacity,
                    Inventory.INVENTORY_SIZE);

        public SellMenu(Player player)
        {
            menuName = NAME;
            options = new List<MenuItem>()
            {
                new MenuItem("Weapons", WeaponOption),
                new MenuItem("Armour", ArmourOption),
                new MenuItem("Potions", PotionOption)
            };

            exit = ExitOption;
            this.player = player;
        }

        // User selects weapons
        private void WeaponOption()
        {
            ObjectMenu<Weapon> menu = new ObjectMenu<Weapon>(player.Inventory.Weapons, Status);
            Weapon weapon = menu.Run();
            if (weapon != player.EquippedWeapon)
            {
                player.Inventory.RemoveItem(weapon);
                player.AddGold(weapon.Cost);
            }
            else
            {
                Console.WriteLine(EQUIPPED_ITEM_ERROR); // If the item is equipped
            }
            this.Run(); // Run the menu again
        }

        // User selects armours
        private void ArmourOption()
        {
            ObjectMenu<Armour> menu = new ObjectMenu<Armour>(player.Inventory.Armours, Status);
            Armour armour = menu.Run();
            if (armour != player.EquippedArmour)
            {
                player.Inventory.RemoveItem(armour);
                player.AddGold(armour.Cost);
            }
            else
            {
                Console.WriteLine(EQUIPPED_ITEM_ERROR); // user has the item equipped
            }
            this.Run();// run the menu again
        }

        // User selects potions
        private void PotionOption()
        {
            ObjectMenu<Potion> menu = new ObjectMenu<Potion>(player.Inventory.Potions, Status);
            Potion potion = menu.Run();
            if (potion != null)
            {
                player.Inventory.RemoveItem(potion);
                player.AddGold(potion.Cost);
            }
            this.Run();
        }
        
        private void ExitOption()
        {

        }


    }
}

