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

        public ShopMenu(Shop shop)
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
        }

        private void WeaponOption()
        {
            ObjectMenu<Weapon> menu = new ObjectMenu<Weapon>(shop.Weapons);
            menu.Run();
            this.Run();
        }

        private void ArmourOption()
        {
            ObjectMenu<Armour> menu = new ObjectMenu<Armour>(shop.Armours);
            menu.Run();
            this.Run();
        }

        private void PotionOption()
        {
            ObjectMenu<Potion> menu = new ObjectMenu<Potion>(shop.Potions);
            menu.Run();
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
