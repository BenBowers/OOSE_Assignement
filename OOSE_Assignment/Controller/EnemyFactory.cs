//
//  EnemyFactory.cs
//
//  Author:
//       benjaminbowers <>
//
//
using System;
using OOSE_Assignment.Model.Enemy;

namespace OOSE_Assignment.Controller
{
    public class EnemyFactory
    {
        private delegate Enemy Constructor();
        public const int INIT_SLIME_PROB = 50;
        public const int INIT_GOBLIN_PROB = 30;
        public const int INIT_OGRE_PROB = 20;

        private int curSlimeProb = INIT_SLIME_PROB;
        private int curGoblinProb = INIT_GOBLIN_PROB;
        private int curOgreProb = INIT_OGRE_PROB;




        public EnemyFactory()
        {
        }

        public Enemy GetEnemy()
        {
            Random r = new Random();
            int randomNum = r.Next(101);
            Enemy enemy;
            if (randomNum <= curSlimeProb)
            {
                enemy = new Slime();
            }
            else if (randomNum <= curSlimeProb + curGoblinProb)
            {
                enemy = new Goblin();
            }
            else if (randomNum <= curSlimeProb + curGoblinProb + curOgreProb)
            {
                enemy = new Ogre();
            }
            else
            {
                enemy = new Dragon();
            }

            curSlimeProb = Math.Max(0, curSlimeProb - 5);
            curGoblinProb = Math.Max(0, curGoblinProb - 5);
            curOgreProb = Math.Max(0, curOgreProb - 5);

            return enemy;
        }

    }
}
