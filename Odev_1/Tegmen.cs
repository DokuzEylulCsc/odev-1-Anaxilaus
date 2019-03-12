using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Odev_1
{
    class Tegmen : Asker
    {
        private List<int> HitPoints = new List<int> { 10, 20, 25 };

        public override void Move()
        {

            double p = Roll();

            // all moves are 10%, total: 40%
            // down
            if (p < .1)
            {

            }

            // up
            if (.1 <= p && p < .2)
            {

            }

            // left
            if (.2 <= p && p < .3)
            {

            }

            // right
            if (.3 <= p && p < .4)
            {

            }

            // fire [2,2]: 30%
            if (.4 <= p && p < .7)
            {

            }

            // wait: 30%
            if (.7 <= p && p < 1)
            {

            }
        }

        // Do nothing
        public override void Wait() { }

        public override void Fire(Asker enemy)
        {
            throw new NotImplementedException();
        }
    }
}