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
        public Takim Team { get; set; }
        // Location: Using Bolge instead of Point
        public Bolge Location { get; set; }
        public Random Rand { get; set; }


        public Asker()
        {
            Rand = new Random(DateTime.Now.Millisecond);
            Team = null;
            Location = null;
            Health = 100;
            Alive = true;
        }

        // Abstract methods
        public abstract void Move();
        public abstract void Wait();
        public abstract void Fire();

        // Roll between (0, 1)
        public double Roll()
        {
            return Rand.NextDouble();
        }

        // Helper method for move
        private bool LocationValid(int x, int y)
        {
            return ((0 <= x && x < Ermeydani.DimensionX) &&
                (0 <= y && y < Ermeydani.DimensionY));
        }

        // Helper method for move
        // If location is occupied, don't do anything
        private void TryChangeLocation(int x, int y)
        {
            Location.Map.Mapping[x, y].MoveIn(this);
        }

        public List<Asker> GetEnemies(int Range)
        {
            List<Asker> Enemies = new List<Asker>();
            for (int x = Location.Coord.X - Range; x <= Location.Coord.X + Range; x++)
            {
                for (int y = Location.Coord.Y - Range; y < Location.Coord.Y + Range; y++)
                {
                    // Guard for off map locations
                    if (LocationValid(x, y))
                    {
                        Asker soldier = Location.Map.Mapping[x, y].Soldier;
                        if (soldier != null && Team.notEquals(soldier.Team))
                        {
                            Enemies.Add(soldier);
                        }
                    }
                }
            }
            return Enemies;
        }

        // Beautify GetType
        // Converts Odev1.Type to Type
        public static string StripType(Asker obj)
        {
            return obj.GetType().ToString().Split(new char[] { '.' })[1];
        }

        public void GotAttacked(Asker Enemy, int Damage)
        {
            Health -= Damage;
            if (Health <= 0) 
            {
                // Dead
                Location.Map.Log.WriteLine(String.Format("{0} from Team {1} attacked {2} from Team {3} and shot him dead at {4}!",
                    StripType(Enemy), Enemy.Team.Name, StripType(this), Team.Name, Location.Coord));

                Alive = false;
                Location.MoveOut();
                Team.RemoveDead(this);
                Team = null;
            }
            else
            {
                Location.Map.Log.WriteLine(String.Format("{0} from Team {1} attacked {2} from Team {3} and reduced his health by {4} to {5} at {6}.",
                    StripType(Enemy), Enemy.Team.Name, StripType(this), Team.Name, Damage.ToString(), Health.ToString(), Location.Coord));
            }
        }

        // If stuck go Left
        public void Down()
        {
            int new_y = Location.Coord.Y - 1;

            if (LocationValid(Location.Coord.X, new_y)) TryChangeLocation(Location.Coord.X, new_y);
            else Left();
        }

        // If stuck go Right
        public void Up()
        {
            int new_y = Location.Coord.Y + 1;

            if (LocationValid(Location.Coord.X, new_y)) TryChangeLocation(Location.Coord.X, new_y);
            else Right();
        }

        // If stuck go Up
        public void Left()
        {
            int new_x = Location.Coord.X - 1;

            if (LocationValid(new_x, Location.Coord.Y)) TryChangeLocation(new_x, Location.Coord.Y);
            else Up();
        }

        // If stuck go Down
        public void Right()
        {
            int new_x = Location.Coord.X + 1;

            if (LocationValid(new_x, Location.Coord.Y)) TryChangeLocation(new_x, Location.Coord.Y);
            else Down();
        }

        // Cross moves below derives from 4 directional moves
        public void LowerLeft()
        {
            Left();
            Down();
        }

        public void LowerRight()
        {
            Right();
            Down();
        }

        public void UpperLeft()
        {
            Left();
            Up();
        }

        public void UpperRight()
        {
            Right();
            Up();
        }
    }
}