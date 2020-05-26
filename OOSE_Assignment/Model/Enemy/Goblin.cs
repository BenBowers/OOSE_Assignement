//
//  Goblin.cs
//
//  Author:
//       benjaminbowers <>
//
//
using System;
namespace OOSE_Assignment.Model.Enemy
{
    public class Goblin : Enemy
    {
        public const string NAME = "Goblin";
        public const int MAX_HEALTH = 30;
        public const int MIN_DAMAGE = 3;
        public const int MAX_DAMAGE = 8;
        public const int MIN_DEFENCE = 4;
        public const int MAX_DEFENCE = 8;
        public const int GOLD = 20;
        public Goblin(): base(
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
            bool specialAttack = new Random().Next(2) == 1;
            int damage = GetDamage();
            if(specialAttack)
            {
                damage += 3;
            }
            character.WeaponDamage(damage);
        }
    }
}
