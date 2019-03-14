using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Odev_1
{
    class Yuzbasi : Asker
    {
        public readonly int[] HitPoints = { 15, 25, 40 };
        public const int Range = 3;

        public Yuzbasi() : base()
        {

        }

        public override void Move()
        {
            double p = Roll();

            // all moves are 6.25%, total: 50%
            // down
            if (p < .0625)
            {
                Down();
            }
             
            // lower-left
            if (.0625 <= p && p < .125)
            {
                LowerLeft();
            }

            // lower-right
            if (.125 <= p && p < .1875)
            {
                LowerRight();
            }

            // up
            if (.1875 <= p && p < .25)
            {
                Up();
            }

            // upper-left
            if (.25 <= p && p < .3125)
            {
                UpperLeft();
            }

            // upper-right
            if (.3125 <= p && p < .375)
            {
                UpperRight();
            }

            // left
            if (.375 <= p && p < .4375)
            {
                Left();
            }

            // right
            if (.4375 <= p && p < .5)
            {
                Right();
            }

            // fire [3,3]: 25%
            if (.5 <= p && p < .75)
            {
                Fire();
            }

            // wait: 25%
            if (.75 <= p && p < 1)
            {
                Wait();
            }
        }

        // Do nothing
        public override void Wait() { }

        public override void Fire()
        {
            List<Asker> Enemies = GetEnemies(Range);
            if (Enemies.Count > 0)
            {
                Asker RandomEnemy = Enemies[Rand.Next(Enemies.Count)];
                // 3 is HitPoints' count
                RandomEnemy.GotAttacked(this, HitPoints[Rand.Next(3)]);

            }
        }
    }
}
