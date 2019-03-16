using System;
using System.Drawing;

namespace Odev_1
{
    public class Ermeydani
    {
        // Log manager
        public Logger Log;

        // Set dimensions
        public Bolge[,] Mapping { get; private set; }
        public Takim[] Teams { get; set; }

        public const int DimensionX = 16;
        public const int DimensionY = 16;

        // Map Mapping[x,y] to new Bolge(x, y) objects
        void InitializeMap()
        {
            this.Mapping = new Bolge[DimensionX, DimensionY];

            for (int x = 0; x < DimensionX; x++)
            {
                for (int y = 0; y < DimensionY; y++)
                {
                    this.Mapping[x, y] = new Bolge(this, x, y);
                    //Console.WriteLine("Mapped index to Bolge object at " + x + ", " + y);
                }
            }
            Log.WriteLine("\t- Map initialized.");
        }

       
        // Initialize hard coded 2 teams
        // With initial locations of first and last 5x5 corners
        void InitializeTeams()
        {
            Log.WriteLine("\nFirst team:");
            Teams[0] = new Takim("A", this, new Point(0, 0), new Point(5, 5));
            Log.WriteLine("\nSecond team:");
            Teams[1] = new Takim("B", this, new Point(DimensionX - 5, DimensionY - 5), new Point(DimensionX, DimensionY));

            Log.WriteLine("\n\t- Teams initialized.");
        }

        void Initialize()
        {
            Log = new Logger();
            Teams = new Takim[2];

            InitializeMap();
            InitializeTeams();
            Log.WriteLine("\t- Initialization completed.");

        }

        void RunSim()
        {

            Log.WriteLine("\t- Starting simulation.\n");
            Asker select = Teams[0].Team[0];

            while(Teams[0].Alive() && Teams[1].Alive())
            {
                Teams[0].Move(); 
                Teams[1].Move();
            }
            Takim winner;
            if (Teams[0].GetCount() > 0) winner = Teams[0];
            else winner = Teams[1];

            Log.WriteLine(String.Format("\n\t- Simulation Ended. Winner is Team {0} with remaining {1} members.",
                winner, winner.GetCount()));

            Log.WritetoFile();
        }

        public void StartSim()
        {
            Initialize();
            RunSim();
        }
    }

}
