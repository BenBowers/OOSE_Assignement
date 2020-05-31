using System;
namespace OOSE_Assignment.Model.Enemy
{
    /**
     * Class representing a dragon
     */
    public class Dragon : Enemy
    {
        private delegate void Special();

        public const string NAME = "Dragon";
        public const int MAX_HEALTH = 100;
        public const int MIN_DAMAGE = 15;
        public const int MAX_DAMAGE = 30;
        public const int MIN_DEFENCE = 15;
        public const int MAX_DEFENCE = 20;
        public const int GOLD = 100;
        public Dragon() : base(
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
            string strOut;
            int rand = new Random().Next(101);
            if (rand <= 10)
            {
                Heal(10);
                strOut = "Dragon Healed 10hp";
            }
            else if (rand <= 35)
            {
                strOut = Name + " did double damage! " +
                    DoDamage(GetDamage() * 2, character) + " damage was done";
            }
            else
            {
                strOut = base.Attack(character);
            }

            return strOut;
        }
    }
}
