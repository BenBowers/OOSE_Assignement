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
        private Shop shop;
        private Player player;

        private string Status => String.Format(STATUS_BAR,
                    player.Gold,
                    player.Inventory.Capacity,
                    Inventory.INVENTORY_SIZE);

        public SellMenu(Player player, Shop shop)
        {
            menuName = NAME;
            options = new List<MenuItem>()
            {
                new MenuItem("Weapons", WeaponOption),
                new MenuItem("Armour", ArmourOption),
                new MenuItem("Potions", PotionOption)
            };

            exit = ExitOption;
            this.shop = shop;
            this.player = player;
        }

        private void WeaponOption()
        {
            ObjectMenu<Weapon> menu = new ObjectMenu<Weapon>(shop.Weapons, Status);
            Weapon weapon = menu.Run();
            player.Inventory.RemoveItem(weapon);
            player.AddGold(weapon.Cost);
            this.Run();
        }

        private void ArmourOption()
        {
            ObjectMenu<Armour> menu = new ObjectMenu<Armour>(shop.Armours, Status);
            Armour armour = menu.Run();
            player.Inventory.RemoveItem(armour);
            player.AddGold(armour.Cost);
            this.Run();
        }

        private void PotionOption()
        {
            ObjectMenu<Potion> menu = new ObjectMenu<Potion>(shop.Potions, Status);
            Potion potion = menu.Run();
            player.Inventory.RemoveItem(potion);
            player.AddGold(potion.Cost);
            this.Run();
        }

        private void ExitOption()
        {

        }


    }
}

