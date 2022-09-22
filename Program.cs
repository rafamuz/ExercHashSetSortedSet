using ExercHashSetSortedSet.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercHashSetSortedSet
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Read a file with users log.
            Console.Write("Enter the file full path: ");
            string path = Console.ReadLine();

            try
            {
                HashSet<LogRecord> logRecords = new HashSet<LogRecord>();
                using (StreamReader sr = File.OpenText(path)) {
                    while(!sr.EndOfStream)
                    {                        
                        string[] vectLine = sr.ReadLine().Split(' ');
                        //Gets only the user from the line that was read.
                        string username = vectLine[0];
                        DateTime instant = DateTime.Parse(vectLine[1]);                        
                        logRecords.Add(new LogRecord() { Username = username, Instant = instant });                        
                    }
                }
                Console.WriteLine("Total users: " + logRecords.Count);
            }
            catch(IOException e)
            {
                Console.WriteLine("Error during file access: " + e.Message);
            }
        }
    }
}
