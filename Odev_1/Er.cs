using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Odev_1
{
    class Er : Asker 
    {
        public readonly int[] HitPoints = { 5, 10, 15 };
        public const int Range = 1;

        public Er() : base()
        {

        }

        public override void Move()
        {
            double p = Roll();

            // down
            if (p < .1)
            {
                Down();
            }

            // up
            if (.1 <= p && p < .3)
            {
                Up();

            }

            // fire [1,1]
            if (.3 <= p && p < .5)
            {
                Fire();
            }

            // wait
            if (.5 <= p && p < 1)
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
