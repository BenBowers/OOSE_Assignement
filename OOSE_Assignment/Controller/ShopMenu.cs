using System;
using System.Collections.Generic;
using OOSE_Assignment.View;
using OOSE_Assignment.Model;
namespace OOSE_Assignment.Controller
{
    public class ShopMenu : MethodMenu
    {
        public const string NAME = "Shop";
        Shop shop;
        Player player;

        public ShopMenu(Player player, Shop shop)
        {
            menuName = NAME;
            options = new List<MenuItem>()
            {
                new MenuItem("Weapons", WeaponOption),
                new MenuItem("Armour", ArmourOption),
                new MenuItem("Potions", PotionOption),
                new MenuItem("Enchant", EnchantmentOption)
            };

            exit = ExitOption;
            this.shop = shop;
            this.player = player;
        }

        private void WeaponOption()
        {
            ObjectMenu<Weapon> menu = new ObjectMenu<Weapon>(shop.Weapons);
            Weapon weapon = menu.Run();
            if (weapon != null)
            {
                if (weapon.Cost < player.Gold)
                {
                    player.RemoveGold(weapon.Cost);
                    player.Inventory.AddItem(weapon);
                }
                else
                {
                    Console.WriteLine("You do not have enough gold to purchase that!!");
                }
            }
            this.Run();
        }

        private void ArmourOption()
        {
            ObjectMenu<Armour> menu = new ObjectMenu<Armour>(shop.Armours);
            Armour armour = menu.Run();
            if (armour != null)
            {
                if (armour.Cost < player.Gold)
                {
                    player.RemoveGold(armour.Cost);
                    player.Inventory.AddItem(armour);
                }
                else
                {
                    Console.WriteLine("You do not have enough gold to purchase that!!");
                }
            }
            this.Run();
        }

        private void PotionOption()
        {
            ObjectMenu<Potion> menu = new ObjectMenu<Potion>(shop.Potions);
            Potion potion = menu.Run();
            if (potion != null)
            {
                if (potion.Cost < player.Gold)
                {
                    player.RemoveGold(potion.Cost);
                    player.Inventory.AddItem(potion);
                }
                else
                {
                    Console.WriteLine("You do not have enough gold to purchase that!!");
                }
            }
            this.Run();
        }


        private void EnchantmentOption()
        {

        }

        private void ExitOption()
        {

        }
    }
}
