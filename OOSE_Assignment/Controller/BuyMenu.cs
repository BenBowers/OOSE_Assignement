using System;
using System.Collections.Generic;
using OOSE_Assignment.View;
using OOSE_Assignment.Model;
namespace OOSE_Assignment.Controller
{
    public class BuyMenu : MethodMenu
    {
        public const string NAME = "Shop";
        public const string STATUS_BAR = "Current Gold: {0}, Inventory {1}/{2}";
        private const string INSUFFCIENT_FUNDS_PROMPT = "You do not have enough gold to purchase that!!";
        private Shop shop;
        private Player player;

        private string Status => String.Format(STATUS_BAR,
                    player.Gold,
                    player.Inventory.Capacity,
                    Inventory.INVENTORY_SIZE);

        public BuyMenu(Player player, Shop shop)
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
            ObjectMenu<Weapon> menu = new ObjectMenu<Weapon>(shop.Weapons, Status);
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
                    Console.WriteLine(INSUFFCIENT_FUNDS_PROMPT);
                }
            }
            this.Run();
        }

        private void ArmourOption()
        {
            ObjectMenu<Armour> menu = new ObjectMenu<Armour>(shop.Armours, Status);
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
                    Console.WriteLine(INSUFFCIENT_FUNDS_PROMPT);
                }
            }
            this.Run();
        }

        private void PotionOption()
        {
            ObjectMenu<Potion> menu = new ObjectMenu<Potion>(shop.Potions, Status);
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
                    Console.WriteLine(INSUFFCIENT_FUNDS_PROMPT);
                }
            }
            this.Run();
        }


        private void EnchantmentOption()
        {
            ObjectMenu<WeaponEnchantment> menu =
                new ObjectMenu<WeaponEnchantment>(shop.Enchantments, "Enchant weapon");
            WeaponEnchantment enchantment = menu.Run();
            if (enchantment != null)
            {
                if (enchantment.Cost < player.Gold)
                {
                    ObjectMenu<Weapon> weaponMenu = new ObjectMenu<Weapon>(player.Inventory.Weapons, "Select weapon to enchant");
                    Weapon weapon = weaponMenu.Run();
                    if (weapon != null)
                    {
                        player.RemoveGold(enchantment.Cost);
                        weapon.AddEnchantment(enchantment);
                    }
                }
                else
                {
                    Console.WriteLine(INSUFFCIENT_FUNDS_PROMPT);
                }
            }

            this.Run();
        }

        private void ExitOption()
        {

        }


    }
}
