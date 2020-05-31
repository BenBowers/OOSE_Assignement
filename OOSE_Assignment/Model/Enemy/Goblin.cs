using System;
namespace OOSE_Assignment.Model.Enemy
{
    /**
     * Class representing a goblin enemy
     */
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

        public override string Attack(Character character)
        {
            bool specialAttack = new Random().Next(2) == 1;
            string strOut;
            if(specialAttack)
            {
                strOut = Name + " did a bonus 3 damage! " +
                    DoDamage(GetDamage() + 3, character) +
                    " damage was done to " + character.Name;
            }
            else
            {
                strOut = base.Attack(character);
            }

            return strOut;
        }
    }
}
