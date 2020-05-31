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
        private EnemyFactory enemyFactory;

        public MainMenu(Player player, Shop shop, EnemyFactory enemyFactory)
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
            this.enemyFactory = enemyFactory;
        }

        public override void Run()
        {
            Console.WriteLine(player);
            base.Run();
        }

        private void GoToShop()
        {
            Console.WriteLine("Going to shop");
            MethodMenu m = new ShopMenu(player, shop);
            m.Run();
            this.Run();
        }

        private void ChooseCharacterName()
        {
            player.Name = new NamePrompt().GetName();
            this.Run();
        }

        private void ChooseWeapon()
        {
            Weapon weapon = ChooseItem(player.Inventory.Weapons, "Equip Weapon");
            if (weapon != null) { player.EquipItem(weapon); }
            this.Run();
        }

        private void ChooseArmour()
        {
            Armour armour = ChooseItem(player.Inventory.Armours, "Equip Armour");
            if (armour != null) { player.EquipItem(armour); }
            this.Run();
        }

        private E ChooseItem<E>(List<E> list, string prompt) where E : Item
        {
            ObjectMenu<E> m = new ObjectMenu<E>(list, prompt);
            return m.Run(); 
        }

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

        private void ExitGame()
        {
            Console.WriteLine("Exiting game");
        }
    }
}
