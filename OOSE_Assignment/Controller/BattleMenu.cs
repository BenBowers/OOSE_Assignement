using System;
using System.Collections.Generic;
using OOSE_Assignment.Model;
using OOSE_Assignment.Model.Enemy;
using OOSE_Assignment.View;
namespace OOSE_Assignment.Controller
{
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

        public void Attack()
        {
            int attack = player.EquippedWeapon.Attack();
            enemy.WeaponDamage(attack);
        }

        public void UsePotion()
        {
            Potion potion = new ObjectMenu<Potion>(player.Inventory.Potions , "Select Potion").Run();
            if (potion != null)
            {
                Character character = new ObjectMenu<Character>(new List<Character> { player, enemy }, "Select character to effect").Run();
                if(character != null)
                {
                    potion.Use(character);
                    Console.WriteLine(player + " used " + potion + " on " + character);
                }
            }
            else
            {
                this.Run();
            }

        }
    }
}
