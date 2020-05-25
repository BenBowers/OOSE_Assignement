using System;
using System.Collections.Generic;
using OOSE_Assignment.View;
using OOSE_Assignment.Model;

namespace OOSE_Assignment.Controller
{
    public class MainMenu : MethodMenu
    {
        private Player player;
        private Shop shop;

        public MainMenu(Player player, Shop shop)
        {
            base.options = new List<MenuItem>
            {
                new MenuItem("Go to shop", GoToShop ),
                new MenuItem("Choose Character Name", ChooseCharacterName),
                new MenuItem("Chose Weapon", ChooseWeapon),
                new MenuItem("Choose Armour", ChooseArmour),
                new MenuItem("Start Battle", StartBattle),
            };

            exit = ExitGame;

            this.shop = shop;
            this.player = player;
        }

        private void GoToShop()
        {
            Console.WriteLine("Going to shop");
            MethodMenu m = new ShopMenu(player, shop);
            m.Run();
            this.Run();
        }

        private void ChooseWeapon()
        {
            ObjectMenu<Weapon> m = new ObjectMenu<Weapon>(player.Inventory.Weapons);
            Weapon w = m.Run();
            if( w != null )
            {
                player.EquipItem(w);
            }
            this.Run();
        }
        private void ChooseCharacterName()
        {
            player.Name = new NamePrompt().GetName();
            this.Run();
        }

        private void ChooseArmour()
        {
            ObjectMenu<Armour> m = new ObjectMenu<Armour>(player.Inventory.Armours);
            Armour item = m.Run();
            if (item != null)
            {
                player.EquipItem(item);
            }
            this.Run();
        }

        private void StartBattle()
        {
            Console.WriteLine("Begining Battle");
            this.Run();
        }

        private void ExitGame()
        {
            Console.WriteLine("Exiting game");
        }
    }
}
