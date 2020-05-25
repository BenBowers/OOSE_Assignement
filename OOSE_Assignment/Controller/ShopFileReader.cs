using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using OOSE_Assignment.Model;
namespace OOSE_Assignment.Controller
{
    public class ShopFileException : Exception
    {
        public ShopFileException(string m) : base(m) { }
    }
    public static class ShopFileReader
    {
        private class ParserException : Exception
        {
            public ParserException(string s) : base(s) { }
        }


        /**
         * Using a dictionary allows for O(1) access time instead of a
         * a switch statement which is O(n) this may seem trivial for 3 differnt
         * items but is here for future extensibility for when more items are 
         * added.
         */
        private delegate void ItemParser(Shop shop, string[] itemParam);
        private static readonly Dictionary<char, ItemParser> PARSERS = new Dictionary<char, ItemParser>
        {
            // Index the function with a character
            { 'W', ParseWeapon },
            { 'A', ParseArmour },
            { 'P', ParsePotion }
        };


        public static Shop ReadFile(string filename)
        {
            Shop shop = new Shop();
            try
            {
                foreach (string line in File.ReadLines(filename, Encoding.UTF8))
                {
                    ParseLine(shop, line);
                }
            }
            catch (OutOfMemoryException e)
            {
                throw new ShopFileException(e.Message);
            }
            catch (IOException e)
            {
                throw new ShopFileException(e.Message);
            }
            catch (ParserException e)
            {
                throw new ShopFileException(e.Message);
            }

            return shop;
        }

        private static void ParseLine(Shop shop, string line)
        {
            string[] strList = line.Split(new string[] { ", " }, StringSplitOptions.None);
            if(PARSERS.TryGetValue(strList[0][0], out ItemParser parser))
            {
                parser(shop, strList);
            }
            else
            {
                throw new ParserException("Failed to read \"" + line + "\"");
            }
        }

        private static void ParseWeapon(Shop shop, string[] itemParam)
        {
            string name;
            int minDamage;
            int maxDamage;
            int cost;
            string damageType;
            string weaponType;

            if (itemParam.Length == 7)
            {
                try
                {
                    name = itemParam[1];
                    minDamage = Convert.ToInt32(itemParam[2]);
                    maxDamage = Convert.ToInt32(itemParam[3]);
                    cost = Convert.ToInt32(itemParam[4]);
                    damageType = itemParam[5];
                    weaponType = itemParam[6];

                    shop.AddItem(new Weapon(name: name,
                                            cost: cost,
                                            minEffect: minDamage,
                                            maxEffect: maxDamage,
                                            weaponType: weaponType,
                                            damageType: damageType));
                }
                catch (OverflowException e)
                {
                    throw new ParserException("Integer is too large");
                }
                catch (FormatException e)
                {
                    throw new ParserException("Failed to parse integer");
                }
            }
            else
            {
                throw new ParserException("Invalid number of parameters");
            }
        }

        private static void ParseArmour(Shop shop, string[] itemParam)
        {
            string name;
            int minDefence;
            int maxDefence;
            int cost;
            string material;

            if( itemParam.Length == 6)
            {
                try
                {

                    name = itemParam[1];
                    minDefence = Convert.ToInt32(itemParam[2]);
                    maxDefence = Convert.ToInt32(itemParam[3]);
                    cost = Convert.ToInt32(itemParam[4]);
                    material = itemParam[5];
                    shop.AddItem(new Armour(name: name,
                                            cost: cost,
                                            minEffect: minDefence,
                                            maxEffect: maxDefence,
                                            material: material));
                }
                catch (OverflowException e)
                {
                    throw new ParserException("Iteger too large");
                }
                catch (FormatException e)
                {
                    throw new ParserException("Failed to parse integer");
                }
            }
            else
            {
                throw new ParserException("Invalid number of parameters");
            }

        }

        private static void ParsePotion(Shop shop, string[] itemParam)
        {
            string name;
            int minEffect;
            int maxEffect;
            int cost;


            if ( itemParam.Length == 6)
            {
                name = itemParam[1];
                minEffect = Convert.ToInt32(itemParam[2]);
                maxEffect = Convert.ToInt32(itemParam[3]);
                cost = Convert.ToInt32(itemParam[4]);
                if (itemParam[5].Length == 1)
                {
                    try
                    {
                        switch (itemParam[5][0])
                        {

                            case 'H':
                                shop.AddItem(new HealingPotion(
                                    name: name,
                                    cost: cost,
                                    minEffect: minEffect,
                                    maxEffect: maxEffect)); break;
                            case 'D':
                                shop.AddItem(new DamagePotion(
                                    name: name,
                                    cost: cost,
                                    minEffect: minEffect,
                                    maxEffect: maxEffect)); break;
                            default:
                                throw new ParserException(
                                    "Cannot get potion type");
                        }
                    }
                    catch (OverflowException e)
                    {
                        throw new ParserException("Integer too big");
                    }
                    catch (FormatException e)
                    {
                        throw new ParserException("Failed to parse integer");
                    }
                }
                else
                {
                    throw new ParserException("Cannot get potion type");
                }
            }
            else
            {
                throw new ParserException("Invalid number of parameters");
            }
        }

        
    }
}
