using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Odev_1
{
    class Yuzbasi : Asker
    {
        private List<int> HitPoints = new List<int> { 15, 25, 40 };

        public override void Move()
        {
            double p = Roll();

            // all moves are 6.25%, total: 50%
            // down
            if (p < .0625)
            {

            }

            // lower-left
            if (.0625 <= p && p < .125)
            {

            }

            // lower-right
            if (.125 <= p && p < .1875)
            {

            }

            // up
            if (.1875 <= p && p < .25)
            {

            }

            // upper-left
            if (.25 <= p && p < .3125)
            {

            }

            // upper-right
            if (.3125 <= p && p < .375)
            {

            }

            // left
            if (.375 <= p && p < .4375)
            {

            }

            // right
            if (.4375 <= p && p < .5)
            {

            }

            // fire [3,3]: 25%
            if (.5 <= p && p < .75)
            {

            }

            // wait: 25%
            if (.75 <= p && p < 1)
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
