using System;
using System.Collections.Generic;
using OOSE_Assignment.Controller;
using OOSE_Assignment.Model;
using OOSE_Assignment.Model.Item;
namespace OOSE_Assignment.View
{
    /**
     * Main menu user interacts with
     */
    public class MainMenu : MethodMenu
    {
        private Player player;
        private Shop shop;
        private EnemyFactory enemyFactory;

        public MainMenu(Player player, Shop shop, EnemyFactory enemyFactory)
        {
            base.options = new List<MenuItem>
            {
                new MenuItem("Go to shop", GoToShop ),
                new MenuItem("Choose Character Name", ChooseCharacterName),
                new MenuItem("View Inventory", DisplayInventory),
                new MenuItem("Chose Weapon", ChooseWeapon),
                new MenuItem("Choose Armour", ChooseArmour),
                new MenuItem("Start Battle", StartBattle),
            };

            exit = ExitGame;

            this.shop = shop;
            this.player = player;
            this.enemyFactory = enemyFactory;
        }

        // Run the menu
        public override void Run()
        {
            Console.WriteLine(player);
            base.Run();
        }

        // User selects shop
        private void GoToShop()
        {
            Console.WriteLine("Going to shop");
            MethodMenu m = new ShopMenu(player, shop);
            m.Run();
            this.Run();
        }

        // User selects ChooseCharacterName
        private void ChooseCharacterName()
        {
            player.Name = new NamePrompt().GetName();
            this.Run();
        }

        // User selects Equip Weapon
        private void ChooseWeapon()
        {
            Weapon weapon = ChooseItem(player.Inventory.Weapons, "Equip Weapon");
            if (weapon != null) { player.EquipItem(weapon); }
            this.Run();
        }

        // User selects Equip Armour
        private void ChooseArmour()
        {
            Armour armour = ChooseItem(player.Inventory.Armours, "Equip Armour");
            if (armour != null) { player.EquipItem(armour); }
            this.Run();
        }

        // Generic Item picker returns the item user selects
        private E ChooseItem<E>(List<E> list, string prompt) where E : Item
        {
            ObjectMenu<E> m = new ObjectMenu<E>(list, prompt);
            return m.Run(); 
        }

        // User selects view inventory
        private void DisplayInventory()
        {
            Console.WriteLine("Weapons : ");
            foreach (Weapon weapon in player.Inventory.Weapons)
                Console.WriteLine("    " + weapon);
            Console.WriteLine("Armours : ");
            foreach (Armour armour in player.Inventory.Armours)
                Console.WriteLine("    " + armour);
            Console.WriteLine("Potions : ");
            foreach (Potion potion in player.Inventory.Potions)
                Console.WriteLine("    " + potion);
            this.Run();
        }


        // User selects battle
        private void StartBattle()
        {
            try
            {
                new Battle(player, enemyFactory).Run();
                this.Run();
            }
            catch (DeadPlayerException e)
            {
                Console.WriteLine("You Died");
                ExitGame();
            }
        }

        // User selects exit
        private void ExitGame()
        {
            Console.WriteLine("Exiting game");
        }
    }
}
