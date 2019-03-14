using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Odev_1
{
    public class Bolge
    {
        public Asker Soldier { get; set; }
        public Point Coord { get; }
        public Ermeydani Map { get; }

        public Bolge(Ermeydani map, int x, int y)
        {
            Soldier = null;
            Coord = new Point(x, y);
            Map = map;
        }

        public void MoveOut()
        {
            this.Soldier = null;
        }

        // Returns true if MoveIn successful
        // Otherwise returns false
        // Handles MoveOut process of soldier too.
        public bool MoveIn(Asker soldier)
        {
            if (this.Soldier != null) return false;

            if (soldier.Location != null) soldier.Location.MoveOut();
            this.Soldier = soldier;
            soldier.Location = this;
            return true;

        }


    }
}
