using System;
using System.Collections.Generic;
using OOSE_Assignment.Model;
namespace OOSE_Assignment.View
{
    public class BattleMenu : Menu
    {
        private Player player;
        private Enemy enemny;

        public BattleMenu()
        {
            base.options = new List<MenuItem>
            {
                new MenuItem("Attack", Attack),
                new MenuItem("Use potion", UsePotion)
            };
        }

        public void Attack()
        {

        }

        public void UsePotion()
        {

        }
    }
}
