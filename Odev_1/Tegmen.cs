using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Odev_1
{
    class Tegmen : Asker
    {
        private readonly int[] HitPoints = { 10, 20, 25 };
        private const int Range = 2;

        public Tegmen() : base()
        {

        }

        public override void Move()
        {

            double p = Roll();

            // all moves are 10%, total: 40%
            // down
            if (p < .1)
            {
                Down();
            }

            // up
            if (.1 <= p && p < .2)
            {
                Up();
            }

            // left
            if (.2 <= p && p < .3)
            {
                Left();
            }

            // right
            if (.3 <= p && p < .4)
            {
                Right();
            }

            // fire [2,2]: 30%
            if (.4 <= p && p < .7)
            {
                Fire();
            }

            // wait: 30%
            if (.7 <= p && p < 1)
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