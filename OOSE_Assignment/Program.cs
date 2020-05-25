using System;
using System.Collections.Generic;
using OOSE_Assignment.Model;
using OOSE_Assignment.View;

namespace OOSE_Assignment.Controller
{
    class MainClass
    {

        public static void Main(string[] args)
        {
            // Read and validate file
            Shop shop;
            MainMenu menu;
            try
            {
                shop = ShopFileReader.ReadFile(args[0]);
                menu = new MainMenu(shop);
                menu.Run();
            }
            catch (ShopFileException e)
            {
                Console.WriteLine(e.Message);
            }


        }
    }
}
