using System;
using System.IO;

namespace A4___Movie_Library___Eric_Peppin.Models
{
    public class Movie : Media
    {
        public string? Genres { get; set; }

        public override void Display(string file)
        {
            StreamReader sr = new StreamReader(file);
            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                Console.WriteLine(line);
            }sr.Close();
        }
    }
}
