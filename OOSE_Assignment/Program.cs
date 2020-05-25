using System;
using System.Collections.Generic;
using OOSE_Assignment.Model;
using OOSE_Assignment.View;

namespace OOSE_Assignment.Controller
{
    class MainClass
    {

        public static void Main(string[] args)
        {
            // Read and validate file
            Shop shop;
            MainMenu menu;
            Player player;
            try
            {
                shop = ShopFileReader.ReadFile(args[0]);
                Armour lowestArmour = shop.Armours[0];
                foreach (Armour armour in shop.Armours)
                    if (armour.Cost < lowestArmour.Cost)
                        lowestArmour = armour;
                Weapon lowestWeapon = shop.Weapons[0];
                foreach (Weapon weapon in shop.Weapons)
                    if (weapon.Cost < lowestWeapon.Cost)
                        lowestWeapon = weapon;


                player = new Player(new NamePrompt().GetName());
                player.Inventory.AddItem(lowestArmour);
                player.Inventory.AddItem(lowestWeapon);
                player.EquipItem(lowestArmour);
                player.EquipItem(lowestWeapon);
                menu = new MainMenu(player, shop);
                menu.Run();
            }
            catch (ShopFileException e)
            {
                Console.WriteLine(e.Message);
            }


        }
    }
}
