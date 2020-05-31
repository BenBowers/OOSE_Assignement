using System;
using System.Collections.Generic;
using OOSE_Assignment.Model;
using OOSE_Assignment.View;
using OOSE_Assignment.Model.Item;
namespace OOSE_Assignment.Controller
{
    class MainClass
    {
        // Entry point for the program
        public static void Main(string[] args)
        {
            Shop shop;
            MainMenu menu;
            Player player;
            EnemyFactory enemyFactory;
            try
            {
                shop = ShopFileReader.ReadFile(args[0]); // Validate the shop file
                foreach (WeaponEnchantment e in Enchantements.WeaponEnchantments) // Retrieve enchantments
                {
                    shop.AddEnchantment(e);
                }

                // Get the lowest value armour and weapon
                Armour lowestArmour = ExtractLowest(shop.Armours);
                Weapon lowestWeapon = ExtractLowest(shop.Weapons);


                // Create the player then add and equip items
                player = new Player(new NamePrompt().GetName());
                player.Inventory.AddItem(lowestArmour);
                player.Inventory.AddItem(lowestWeapon);
                player.EquipItem(lowestArmour);
                player.EquipItem(lowestWeapon);

                enemyFactory = new EnemyFactory(); // Get a factory for the enemys

                menu = new MainMenu(player, shop, enemyFactory); // Launch the main menu
                menu.Run();
            }
            catch (ShopFileException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /**
         * Removes the lowest value Item in the list
         */
        private static E ExtractLowest<E>(List<E> list) where E : Item
        {
            E lowest = list[0];
            foreach (E item in list)
                if (item.Cost < lowest.Cost)
                    lowest = item;
            return lowest;
        }
    }
}
