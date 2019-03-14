using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Odev_1
{
    public class Takim
    {

        public Ermeydani Map { get; set; }
        public List<Asker> Team { get; set; }
        public int Size = 7;
        public int Id { get; set; }
        public string Name { get; set; }

        public Takim(string name, Ermeydani map, Point start, Point end)
        {
            Name = name;
            Map = map;
            Initialize(start, end);
        }

        // Create team members and set their locations 
        void Initialize(Point start, Point end)
        {
            Random rand = new Random(DateTime.Now.Millisecond);
            Id = rand.Next();
            this.Team = new List<Asker>();
            int num_Er = 0, num_Tegmen = 0, num_Yuzbasi = 0;
            int x, y;

            Asker soldier;
            for (int c = 0; c < Size; c++)
            {
                soldier = null;
                while (soldier == null)
                {
                    double roll = rand.NextDouble();

                    // 20% Yuzbasi
                    if (.0 < roll && roll <= .2 && num_Yuzbasi < 1)
                    {
                        soldier = new Yuzbasi();
                        num_Yuzbasi += 1;
                    }

                    // 20% Tegmen
                    if (.2 < roll && roll <= .4 && num_Tegmen < 2)
                    {
                        soldier = new Tegmen();
                        num_Tegmen += 1;
                    }

                    // 60% Er
                    if (.4 < roll && roll <= 1)
                    {
                        soldier = new Er();
                        num_Er += 1;
                    }
                }
                
                // Set initial location
                while (soldier.Location == null)
                {
                    x = rand.Next(start.X, end.X);
                    y = rand.Next(start.Y, end.Y);
                    Map.Mapping[x, y].MoveIn(soldier);
                }

                Console.WriteLine((c + 1).ToString() + " - " + soldier.GetType().ToString().Split(new char[] { '.' })[1] + " at " + soldier.Location.Coord);
                Team.Add(soldier);
                soldier.Team = this;
            }

        }

        public bool notEquals(Takim other)
        {
            return Id != other.Id;
        }

        public bool Alive()
        {
            return Team.Count != 0;
        }

        public int GetCount()
        {
            return Team.Count;
        }

        public void RemoveDead(Asker soldier)
        {
            Team.Remove(soldier);
        }

        public void Move()
        {
            for (int s = 0; s < GetCount(); s++) Team[s].Move();
        }

        public string GetName()
        {
            return Name;
        }
    }
}
