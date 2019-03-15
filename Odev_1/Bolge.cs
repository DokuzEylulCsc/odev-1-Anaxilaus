﻿using System;
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
        // Handles MoveOut process of soldier and logs
        public bool MoveIn(Asker soldier)
        {
            if (this.Soldier != null) return false;

            if (soldier.Location != null)
            {
                // MoveOut
                soldier.Location.MoveOut();
                Map.Log.WriteLine(String.Format("{0} from Team {1} changed location from {2} to {3}",
                    Asker.StripType(soldier), soldier.Team.Name, soldier.Location.Coord, this.Coord));
            }
            this.Soldier = soldier;
            soldier.Location = this;
            return true;

        }


    }
}
