using System;
using System.Collections.Generic;
using OOSE_Assignment.Model;
using OOSE_Assignment.Model.Enemy;
using OOSE_Assignment.Model.Item;
namespace OOSE_Assignment.View
{
    /**
     * This is a menu where the user selects what they are going to do on their
     * turn
     */
    public class BattleMenu : MethodMenu
    {
        private Player player;
        private Enemy enemy;

        public BattleMenu(Player player, Enemy enemy)
        {
            base.options = new List<MenuItem>
            {
                new MenuItem("Attack", Attack),
                new MenuItem("Use potion", UsePotion)
            };

            this.player = player;
            this.enemy = enemy;
        }

        // User selects attack
        public void Attack()
        {
            int attack = player.EquippedWeapon.Attack();
            int initHealth = enemy.CurrentHealth;
            enemy.WeaponDamage(attack);
            Console.WriteLine(player.Name + " did " + (initHealth - enemy.CurrentHealth) + " damage to " + enemy.Name);
        }

        // User selects use potion
        public void UsePotion()
        {
            Potion potion = new ObjectMenu<Potion>(player.Inventory.Potions , "Select Potion").Run();
            if (potion != null)
            {
                Character character = new ObjectMenu<Character>(new List<Character> { player, enemy }, "Select character to effect").Run();
                if(character != null)
                {
                    potion.Use(character);
                    player.Inventory.RemoveItem(potion);
                    Console.WriteLine(player.Name + " used " + potion + " on " + character.Name);
                }
            }
            else
            {
                this.Run(); // If the user goes back
            }

        }
    }
}
