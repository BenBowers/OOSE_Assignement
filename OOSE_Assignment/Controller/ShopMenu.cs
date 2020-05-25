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

        public ShopMenu()
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
        }

        private void WeaponOption()
        {

        }

        private void ArmourOption()
        {

        }

        private void PotionOption()
        {

        }

        private void EnchantmentOption()
        {

        }

        private void ExitOption()
        {

        }
    }
}
