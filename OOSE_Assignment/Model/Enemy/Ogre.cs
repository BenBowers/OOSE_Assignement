//
//  Ogre.cs
//
//  Author:
//       benjaminbowers <>
//
//
using System;
namespace OOSE_Assignment.Model.Enemy
{
    public class Ogre : Enemy
    {
        public const string NAME = "Ogre";
        public const int MAX_HEALTH = 40;
        public const int MIN_DAMAGE = 5;
        public const int MAX_DAMAGE = 10;
        public const int MIN_DEFENCE = 6;
        public const int MAX_DEFENCE = 12;
        public const int GOLD = 40;
        public Ogre() : base(
            name: NAME,
            maximumHealth: MAX_HEALTH,
            minDefence: MIN_DEFENCE,
            maxDefence: MAX_DEFENCE,
            minAttack: MIN_DAMAGE,
            maxAttack: MAX_DAMAGE,
            gold: GOLD)
        {
        }

        public override void Attack(Character character)
        {
            bool specialAttack = new Random().Next(101) <= 20;
            int damage = GetDamage();
            if (specialAttack)
            {
                character.WeaponDamage(damage);
            }
            character.WeaponDamage(damage);
        }
    }
}
