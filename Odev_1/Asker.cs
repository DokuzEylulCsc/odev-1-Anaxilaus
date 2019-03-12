using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Odev_1
{
    public abstract class Asker
    {
        public int Health { get; set; }
        public bool Alive { get; set; }
        private Takim Team { get; set; }
        // Location: Using Bolge instead of Point
        private Bolge Location { get; set; }

        // Abstract methods
        public abstract void Move();
        public abstract void Wait();
        public abstract void Fire(Asker enemy);

        // Roll between (0, 1)
        Random rand = new Random(DateTime.Now.Millisecond);
        public double Roll()
        {
            return rand.NextDouble();
        }

    }
}