using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Odev_1
{
    class Er : Asker 
    {
        private List<int> HitPoints = new List<int> { 5, 10, 15 };

        public override void Move()
        {
            double p = Roll();

            // down
            if (p < .1)
            {

            }

            // up
            if (.1 <= p && p < .3)
            {


            }

            // fire [1,1]
            if (.3 <= p && p < .5)
            {

            }

            // wait
            if (.5 <= p && p < 1)
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
