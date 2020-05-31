//
//  ShopMenu.cs
//
//  Author:
//       benjaminbowers <>
//
//
using System;
using System.Collections.Generic;
using OOSE_Assignment.Model;
using OOSE_Assignment.View;

namespace OOSE_Assignment.Controller
{
    public class ShopMenu : MethodMenu
    {
        private Player player;
        private Shop shop;
        public ShopMenu(Player player, Shop shop)
        {
            options = new List<MenuItem>
            {
                new MenuItem("Buy", Buy),
                new MenuItem("Sell", Sell)
            };
            exit = Exit;

            this.player = player;
            this.shop = shop;
        }

        private void Buy()
        {
            new BuyMenu(player, shop).Run();
            this.Run();
        }

        private void Sell()
        {
            new SellMenu(player).Run();
            this.Run();
        }

        private void Exit()
        {

        }
    }
}
