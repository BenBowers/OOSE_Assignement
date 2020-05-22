using System;
using System.Collections.Generic;
using OOSE_Assignment.View;
using OOSE_Assignment.Model;

namespace OOSE_Assignment.Controller
{
    public class MainMenu : Menu
    {
        private Player player;
        private Shop shop;

        public MainMenu(Player player, Shop shop)
        {
            base.options = new List<MenuItem>
            {
                new MenuItem("Go to shop", GoToShop ),
                new MenuItem("Choose Character Name", ChooseCharacterName),
                new MenuItem("Choose Armour", ChooseArmour),
                new MenuItem("Start Battle", StartBattle),
                new MenuItem("Exit Game", ExitGame)
            };

            this.player = player;
            this.shop = shop;
        }

        private void GoToShop()
        {
            Console.WriteLine("Going to shop");
            this.Run();
        }

        private void ChooseCharacterName()
        {
            Console.WriteLine("Changing Character name");
            this.Run();
        }

        private void ChooseArmour()
        {
            Console.WriteLine("Selecting Armour");
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
