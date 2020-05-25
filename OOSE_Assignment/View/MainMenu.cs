using System;
using System.Collections.Generic;

namespace OOSE_Assignment.View
{
    public class MainMenu : Menu
    {

        public MainMenu()
        {
            base.options = new List<MenuItem>
            {
                new MenuItem("Go to shop", GoToShop ),
                new MenuItem("Choose Character Name", ChooseCharacterName),
                new MenuItem("Choose Armour", ChooseArmour),
                new MenuItem("Start Battle", StartBattle),
                new MenuItem("Exit Game", ExitGame)
            };
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
