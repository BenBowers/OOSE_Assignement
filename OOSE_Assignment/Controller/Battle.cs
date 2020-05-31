using System;
using OOSE_Assignment.Model;
using OOSE_Assignment.Model.Enemy;
namespace OOSE_Assignment.Controller
{
    public class Battle
    {
        public const string SUCCESS_BATTLE = "{0} Defeats {1} and will recieve {2} gold and {3} health";
        private Player player;
        private Enemy enemy;
        private BattleMenu menu;
        public bool Finished { get; private set; } = false;
        public Battle(Player player, EnemyFactory enemyFactory)
        {
            this.player = player;
            this.enemy = enemyFactory.GetEnemy();
            menu = new BattleMenu(player, enemy);

        }

        public void Run()
        {
            while (!enemy.Dead)
            {
                DisplayBattleDetails();
                menu.Run(); // Players turn
                if( !enemy.Dead)
                {
                    Console.WriteLine(enemy.Attack(player));
                    if (player.Dead) { throw new DeadPlayerException(); }
                }
            }
            DisplayBattleResult();
        }

        private void DisplayBattleDetails()
        {
            Console.WriteLine(player);
            Console.WriteLine(enemy);
        }

        private void DisplayBattleResult()
        {
            int incHealth = Math.Min((int)(player.CurrentHealth * 1.5), player.MaximumHealth) - player.CurrentHealth;
            player.Heal(incHealth);
            player.AddGold(enemy.Gold);
            Console.WriteLine(SUCCESS_BATTLE, player.Name, enemy.Name, enemy.Gold, incHealth);
        }
    }
}
