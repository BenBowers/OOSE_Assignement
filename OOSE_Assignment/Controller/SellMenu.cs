//
//  SellMenu.cs
//
//  Author:
//       benjaminbowers <>
//
//
using System;
using System.Collections.Generic;
using OOSE_Assignment.View;
using OOSE_Assignment.Model;
namespace OOSE_Assignment.Controller
{
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
                Console.WriteLine(EQUIPPED_ITEM_ERROR);
            }
            this.Run();
        }

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
                Console.WriteLine(EQUIPPED_ITEM_ERROR);
            }
            this.Run();
        }

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

