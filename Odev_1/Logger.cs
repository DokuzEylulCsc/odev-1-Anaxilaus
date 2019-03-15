using System;
using System.IO;
using System.Collections.Generic;

namespace Odev_1
{
    public class Logger
    {
        // Writes log file to where program is executed
        // Prints log file's absolute path to Console
        
        private bool Echo { get; }
        private List<string> Logs { get; }
        private string Filename { get; }

        public Logger(string filename="SimulationLogs.txt", bool echo=true)
        {
            Echo = echo;
            Filename = filename;

            Logs = new List<string>();
        }

        // Add logs and write to console
        public void WriteLine(string line)
        {
            Console.WriteLine(line);
            Logs.Add(line);

        }

        public void WritetoFile()
        {
            using (StreamWriter File = new StreamWriter(Filename))
            {
                foreach (string line in Logs)
                {
                    if (Echo) Console.WriteLine(line);
                    File.WriteLine(line);
                }
            }
            Console.WriteLine("\nLog file written at: " + Path.Combine(Environment.CurrentDirectory, Filename));
        }
    }
}
