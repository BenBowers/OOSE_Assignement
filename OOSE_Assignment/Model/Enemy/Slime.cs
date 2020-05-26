//
//  Slime.cs
//
//  Author:
//       benjaminbowers <>
//
//
using System;
namespace OOSE_Assignment.Model.Enemy
{
    public class Slime : Enemy
    {
        public const string NAME = "Slime";
        public const int MAX_HEALTH = 10;
        public const int MIN_DAMAGE = 3;
        public const int MAX_DAMAGE = 5;
        public const int MIN_DEFENCE = 0;
        public const int MAX_DEFENCE = 2;
        public const int GOLD = 10;
        public Slime() : base(
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
            if (!specialAttack)
            {
                character.WeaponDamage(damage);
            }
        }
    }
}
